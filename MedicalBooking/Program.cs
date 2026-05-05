using MedicalBooking.API.Interfaces;
using MedicalBooking.API.Repositories;
using MedicalBooking.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IPractitionerScheduleRepository, PractitionerScheduleRepository>();
builder.Services.AddScoped<IReminderService, ReminderService>();
builder.Services.AddHostedService<BackgroundReminderService>();
builder.Services.AddScoped<IReportingService, ReportingService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}"
);

app.Run();