using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication4.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TituloContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TituloContext") ?? throw new InvalidOperationException("Connection string 'TituloContext' not found.")));
builder.Services.AddDbContext<HabilidadContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HabilidadContext") ?? throw new InvalidOperationException("Connection string 'HabilidadContext' not found.")));
builder.Services.AddDbContext<EventoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventoContext") ?? throw new InvalidOperationException("Connection string 'EventoContext' not found.")));
builder.Services.AddDbContext<PruebaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PruebaContext") ?? throw new InvalidOperationException("Connection string 'PruebaContext' not found.")));

    
builder.Services.AddDbContext<ExperienciaLaboralContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExperienciaLaboralContext") ?? throw new InvalidOperationException("Connection string 'ExperienciaLaboralContext' not found.")));

builder.Services.AddDbContext<OfertasLaboralesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OfertasLaboralesContext") ?? throw new InvalidOperationException("Connection string 'OfertasLaboralesContext' not found.")));
 builder.Services.AddDbContext<EmpresaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmpresaContext") ?? throw new InvalidOperationException("Connection string 'EmpresaContext' not found.")));
builder.Services.AddDbContext<UsuarioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UsuarioContext") ?? throw new InvalidOperationException("Connection string 'UsuarioContext' not found.")));
builder.Services.AddDbContext<CandidatoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CandidatoContext") ?? throw new InvalidOperationException("Connection string 'CandidatoContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
