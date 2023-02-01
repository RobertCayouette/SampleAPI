using SampleEmployeeAPI.Implementation.Class;
using SampleEmployeeAPI.Implementation.Factory;
using SampleEmployeeAPI.Infrastructure.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<HourlyService>().AddScoped<IEmployeeService, HourlyService>(s => s.GetService<HourlyService>());
builder.Services.AddScoped<SalariedService>().AddScoped<IEmployeeService, SalariedService>(s => s.GetService<SalariedService>());
builder.Services.AddScoped<EmployeeService>().AddScoped<IEmployeeService, EmployeeService>(s => s.GetService<EmployeeService>());
builder.Services.AddScoped<ManagersService>().AddScoped<IEmployeeService, ManagersService>(s => s.GetService<ManagersService>());

EmployeeList.ListOfEmployee();

builder.Services.AddScoped<EmployeeFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
