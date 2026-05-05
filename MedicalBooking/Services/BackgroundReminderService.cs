using MedicalBooking.API.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MedicalBooking.API.Services
{
    public class BackgroundReminderService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public BackgroundReminderService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var appointmentService = scope.ServiceProvider
                        .GetRequiredService<IAppointmentService>();

                    var reminderService = scope.ServiceProvider
                        .GetRequiredService<IReminderService>();

                    var appointments = appointmentService.GetAppointments();

                    var upcoming = appointments.Where(a =>
                        !a.Attended &&
                        !a.ReminderSent &&
                        a.AppointmentDate > DateTime.Now &&
                        a.AppointmentDate <= DateTime.Now.AddMinutes(30));

                    foreach (var appt in upcoming)
                    {
                        reminderService.SendReminder(appt);
                        appt.ReminderSent = true; // mark as sent
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}