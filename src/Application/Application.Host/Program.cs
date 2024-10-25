using Microsoft.EntityFrameworkCore;
using Serilog;
using Template.Service.Api.Rest.Application.Host.Extensions;
using Template.Service.Api.Rest.Application.Host.Midellwares;
using Template.Service.Api.Rest.DrivenAdapter.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Metodo de extension para agregar los servicios de la aplicacion
builder.Services.AddApplicationServices();
builder.Services.AddAuthentication(builder.Configuration);

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#region Serilog

builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

#endregion

var app = builder.Build();

// Este codigo es simplemente un ejemplo por favor eliminarlo cuando se empiece a trabajar en el proyecto

#region Ejemplo

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<Context>();

    // Asegúrate de que la base de datos esté creada.
    context.Database.EnsureCreated();
}

#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();