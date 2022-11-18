using DDD.Infrastructure.Repositories;
using DDD.Infrastructure;
using Microsoft.EntityFrameworkCore;
using DDD.Core.Interfaces;
using DDD.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin();
        });
});

string connString = builder.Configuration.GetConnectionString("DDDCosmos");

builder.Services.AddDbContext<DddDbContext>(o => o.UseCosmos(connString, "ddd1"));
builder.Services.AddTransient<CustomerService>();
builder.Services.AddTransient<InvoiceService>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
app.UseCors("CORSPolicy");

app.Run();
