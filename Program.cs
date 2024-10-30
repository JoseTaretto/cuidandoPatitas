using AppCuidandoPatitas.Datos;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    // Direccion del login
    option.LoginPath = "/Home/IndexLogIn";
    //Vencimiento del tiempo de Sesion
    option.ExpireTimeSpan = TimeSpan.FromHours(12);
    // Al no tener acceso a una vista redirigo al index central
    option.AccessDeniedPath = "/Home/Index";
});

// Registrar DatosAnimales en el contenedor de servicios
builder.Services.AddScoped<DatosAnimales>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
