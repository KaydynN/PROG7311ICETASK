using MedicalBooking.API.Interfaces;
using MedicalBooking.API.Repositories;
using MedicalBooking.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<IPractitionerScheduleRepository, PractitionerScheduleRepository>();

builder.Services.AddScoped<IReminderService, ReminderService>();
builder.Services.AddScoped<IReportingService, ReportingService>();

// Background reminder checker
builder.Services.AddHostedService<BackgroundReminderService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();