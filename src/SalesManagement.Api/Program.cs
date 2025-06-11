using Microsoft.EntityFrameworkCore;
using SalesManagement.Application.Commons.Attributes;
using SalesManagement.Application.Commons.MappingProfiles;
using SalesManagement.Domain.Customers;
using SalesManagement.Infrastructure;
using SalesManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(config =>
{
    config.AddMaps(typeof(CustomerMappingProfile).Assembly);
});

builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddDbContext<SalesManagementDbContext>(config =>
{
    //config.UseSqlServer();
    config.UseInMemoryDatabase("SalesManagement");
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.Scan(scan =>
{
    scan.FromAssemblies(typeof(CustomerMappingProfile).Assembly)
        .AddClasses(c => c.WithAttribute<UseCaseAttribute>())
        .AsImplementedInterfaces();
});

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();