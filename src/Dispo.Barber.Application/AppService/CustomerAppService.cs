﻿using Dispo.Barber.Application.AppService.Interface;
using Dispo.Barber.Application.Repository;
using Dispo.Barber.Application.Service.Interface;
using Dispo.Barber.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Dispo.Barber.Application.AppService
{
    public class CustomerAppService(ILogger<CustomerAppService> logger, IUnitOfWork unitOfWork, ICustomerService service) : ICustomerAppService
    {
        public async Task<List<Customer>> GetForAppointment(CancellationToken cancellationToken, string search)
        {
			try
			{
                return await unitOfWork.QueryUnderTransactionAsync(cancellationToken, async () => await service.GetForAppointment(cancellationToken, search));
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error getting customers.");
                throw;
            }
        }
    }
}
