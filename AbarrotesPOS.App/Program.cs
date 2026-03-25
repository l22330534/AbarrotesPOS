using AbarrotesPOS.App.Components;
using AbarrotesPOS.Data;
using AbarrotesPOS.Data.Repositories;
using AbarrotesPOS.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("AbarrotesPOS.Data")
    ));

builder.Services.AddScoped<UserSessionService>();

// ?? Nuevos servicios ??????????????????????????????????????????
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
// ?????????????????????????????????????????????????????????????

var app = builder.Build();

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