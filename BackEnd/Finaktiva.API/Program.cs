using Finaktiva.Aplication.Interfaces;
using Finaktiva.Aplication.Services;
using Finaktiva.Infrastructur.DataAccess.Context;
using Finaktiva.Infrastructur.DataAccess.Repository;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Finaktiva.API.Models.Validators;
using Finaktiva.API.Hubs;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Finaktiva",
        Description = "Prueba Tecnica ",
        Contact = new OpenApiContact
        {
            Name = "Daniel Stiven Londoño Ortega",
            Email = "daniel.londono.ortega@gmail.com"
        }
    });

});
builder.Services.AddDbContext<EntityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FinaktivaBDConnection"))
);
builder.Services.AddScoped<IEventLogsService, EventLogsService>();
builder.Services.AddScoped<ITypeEventLogsService, TypeEventLogsService>();
builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<EventLogsModelValidator>();
builder.Services.AddSignalR(o =>
{
    o.EnableDetailedErrors = true;
}); ;

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()  // Allow all HTTP methods (GET, POST, etc.)
            .AllowAnyHeader()  // Allow all headers (like Content-Type, Authorization)
            .AllowCredentials(); // Allow credentials if necessary (e.g., cookies or auth tokens)
    });
});

var app = builder.Build();
app.MapHub<EventLogsHub>("/current-time");
app.UseCors("AllowReactApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
