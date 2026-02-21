using AbarrotesPOS.App.Components;
using AbarrotesPOS.Data;
using AbarrotesPOS.Services; // <--- 1. IMPORTANTE: Agregar este using
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configuración de la Base de Datos
// (Le agregué lo de MigrationsAssembly por si acaso vuelves a tener problemas con las migraciones)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("AbarrotesPOS.Data")
    ));

// --- 2. IMPORTANTE: REGISTRAR EL SERVICIO DE SESIÓN ---
// Esto permite que la app "recuerde" quién se logueó
builder.Services.AddScoped<UserSessionService>();
// -----------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();