using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services
    .AddControllersWithViews()
    .ConfigureApplicationPartManager(manager =>
    {
        // Safety fix:
        // Prevent MedicalBooking.Web from discovering API controllers
        // if the Web project accidentally references MedicalBooking.API.
        var apiAssembly = manager.ApplicationParts
            .FirstOrDefault(part => part.Name == "MedicalBooking.API");

        if (apiAssembly != null)
        {
            manager.ApplicationParts.Remove(apiAssembly);
        }
    });

// HttpClient connection to API
var apiUrl = builder.Configuration["API_BASE_URL"] ?? "https://localhost:7163/";

builder.Services.AddHttpClient("MedicalAPI", client =>
{
    client.BaseAddress = new Uri(apiUrl);
});

// Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/Login";
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}"
);

app.Run();