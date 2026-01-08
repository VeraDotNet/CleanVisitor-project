using Microsoft.EntityFrameworkCore;
using CleanVisitor.Core.Interfaces;
using CleanVisitor.Infrastructure.Data;
using CleanVisitor.Infrastructure.Repositories;
using CleanVisitor.Application.UseCases.Visitors.Commands.AddVisitor;
using CleanVisitor.Application.UseCases.Visitors.Queries.ListVisitors;
using CleanVisitor.Application.UseCases.Visitors.Queries.GetVisitorById;
using CleanVisitor.Application.UseCases.Visitors.Commands.UpdateVisitor;
using CleanVisitor.Application.UseCases.Visitors.Commands.DeleteVisitor;
using CleanVisitor.Application.UseCases.Visits.Commands.AddVisit;
using CleanVisitor.Application.UseCases.Visits.Commands.CheckOutVisit;
using CleanVisitor.Application.UseCases.Visits.Queries.ListVisits;
using CleanVisitor.Application.UseCases.Visits.Queries.GetVisitById;
using CleanVisitor.Application.UseCases.Departments.Commands.AddDepartment;
using CleanVisitor.Application.UseCases.Departments.Queries.ListDepartments;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
builder.Services.AddScoped<IVisitRepository, VisitRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

// Use cases - Visitors
builder.Services.AddScoped<AddVisitorHandler>();
builder.Services.AddScoped<UpdateVisitorHandler>();
builder.Services.AddScoped<DeleteVisitorHandler>();
builder.Services.AddScoped<ListVisitorsHandler>();
builder.Services.AddScoped<GetVisitorByIdHandler>();

// Use cases - Visits
builder.Services.AddScoped<AddVisitHandler>();
builder.Services.AddScoped<ListVisitsHandler>();
builder.Services.AddScoped<CheckOutVisitHandler>();
builder.Services.AddScoped<GetVisitByIdHandler>();

// Use cases - Departments
builder.Services.AddScoped<AddDepartmentHandler>();
builder.Services.AddScoped<ListDepartmentsHandler>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();








// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
