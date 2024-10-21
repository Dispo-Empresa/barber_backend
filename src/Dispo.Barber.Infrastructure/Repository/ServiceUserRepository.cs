﻿using Dispo.Barber.Application.Repository;
using Dispo.Barber.Domain.Entities;
using Dispo.Barber.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Dispo.Barber.Infrastructure.Repository
{
    public class ServiceUserRepository : RepositoryBase<ServiceUser>, IServiceUserRepository
    {
        private readonly ApplicationContext context;
        public ServiceUserRepository(ApplicationContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<List<Service>> GetServicesByUserId(long UserId)
        {
            var services = await context.UserServices
               .Where(us => us.UserId == UserId)
               .Select(us => us.Service)
               .ToListAsync();

            return services;
        }

        public async Task<List<User>> GetUsersByServiceId(List<long> serviceIds)
        {
            if (serviceIds == null || !serviceIds.Any())
            {
                return new List<User>();
            }

            var users = await context.UserServices
                .Where(us => serviceIds.Contains(us.ServiceId))
                .GroupBy(us => us.UserId) 
                .Select(g => new
                {
                    UserId = g.Key, 
                    ServiceCount = g.Count() 
                })
                .Where(x => x.ServiceCount == serviceIds.Count) 
                .Select(x => x.UserId) 
                .ToListAsync();

            return await context.Users
                .Where(u => users.Contains(u.Id)) 
                .ToListAsync();
        }

    }
}
