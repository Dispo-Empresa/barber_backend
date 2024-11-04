﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dispo.Barber.Application.AppService.Interface;
using Dispo.Barber.Application.Repository;
using Dispo.Barber.Domain.DTO.Authentication;
using Dispo.Barber.Domain.Entities;
using Dispo.Barber.Domain.Exception;
using Microsoft.IdentityModel.Tokens;

namespace Dispo.Barber.Application.AppService
{
    public class AuthAppService(IUnitOfWork unitOfWork) : IAuthAppService
    {
        public async Task<AuthenticationResult> AuthenticateAsync(CancellationToken cancellationToken, string phone, string password)
        {
            return await unitOfWork.QueryUnderTransactionAsync(cancellationToken, async () =>
            {
                var userRepository = unitOfWork.GetRepository<IUserRepository>();
                var user = await userRepository.GetByPhoneWithBusinessUnitiesAsync(cancellationToken, phone);
                if (user == null)
                {
                    throw new NotFoundException("Usuário não encontrado.");
                }

                if (!PasswordEncryptor.VerifyPassword(password, user.Password))
                {
                    throw new NotFoundException("Usuário não encontrado.");
                }

                return CreateToken(user);
            });
        }

        private AuthenticationResult CreateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("phone", user.Phone),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            return new AuthenticationResult(tokenHandler.WriteToken(new JwtSecurityToken(
                issuer: Environment.GetEnvironmentVariable("JWT_ISSUER"),
                audience: Environment.GetEnvironmentVariable("JWT_ISSUER"),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: credentials
            )), user);
        }
    }
}
