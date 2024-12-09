﻿using Dispo.Barber.Domain.DTO.Appointment;
using Dispo.Barber.Domain.Entities;

namespace Dispo.Barber.Application.Service.Interface
{
    public interface IAppointmentService
    {
        Task CreateAsync(CancellationToken cancellationToken, CreateAppointmentDTO createAppointmentDTO);

        Task InformProblemAsync(CancellationToken cancellationToken, long id, InformAppointmentProblemDTO informAppointmentProblemDTO);

        Task<Appointment> GetAsync(CancellationToken cancellationToken, long id);

        Task CancelAppointmentAsync(CancellationToken cancellationToken, long id);

        Task CancelAllTodayAsync(CancellationToken cancellationToken, long userId);

        Task<List<Appointment>> GetNextAppointmentsAsync(CancellationToken cancellationToken, long userId);
    }
}
