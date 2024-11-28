﻿using Dispo.Barber.Domain.DTO.Appointment;
using Dispo.Barber.Domain.DTO.Customer;
using Dispo.Barber.Domain.Entities;
namespace Dispo.Barber.Application.Service.Interface
{
    public interface ICustomerService
    {
        Task<CustomerDTO> CreateAsync(CustomerDTO customerDTO);

        Task<CustomerDTO> GetByPhoneAsync(string phone);

        Task<List<Customer>> GetForAppointment(CancellationToken cancellationToken, string search);

        Task<List<CustomerDetailDTO>> GetUserCustomersAsync(CancellationToken cancellationToken, long userId);

        Task<List<AppointmentDetailDTO>> GetCustomerAppointmentsAsync(CancellationToken cancellationToken, long id);

        Task<List<CustomerDetailDTO>> GetCustomersAsync(CancellationToken cancellationToken);
    }
}
