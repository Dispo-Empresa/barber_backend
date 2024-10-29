﻿using Dispo.Barber.Application.Repository;
using Dispo.Barber.Domain.Entities;
using Dispo.Barber.Domain.Enum;
using Dispo.Barber.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Dispo.Barber.Infrastructure.Repository
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        private readonly ApplicationContext context;
        public AppointmentRepository(ApplicationContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Appointment>> GetAppointmentByUserIdSync(CancellationToken cancellationToken, long userId)
        {
                return await context.Appointments.Where(x => x.AcceptedUserId == userId && x.Date >= DateTime.UtcNow && x.Status != AppointmentStatus.Completed)
                                          .ToListAsync(cancellationToken);
        }              
    }
}
