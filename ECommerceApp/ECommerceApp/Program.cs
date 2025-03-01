using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Helper;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("ECommerceDB");
Console.WriteLine($"Connection String: {connectionString}");
builder.Services.AddDbContext<ECommerceDbContext>(options =>
{
    // options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceApp"));

    options.UseSqlServer(connectionString);
});
// Add services to the container.

builder.Services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();
builder.Services.AddScoped<IPaymentServiceAsync, PaymentServiceAsync>();
builder.Services.AddScoped<IShoppingServiceAsync, ShoppingServiceAsync>();
builder.Services.AddScoped<IShoppingCartItemServiceAsync, ShoppingCartItemServiceAsync>();


builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
builder.Services.AddScoped<IPaymentMethodRepositoryAsync, PaymentMethodRepositoryAsync>();
builder.Services.AddScoped<IShoppingCartRepositoryAsync, ShoppingCartRepositoryAsync>();
builder.Services.AddScoped<IShoppingCartItemRepositoryAsync, ShoppingCartItemRepositoryAsync>();
builder.Services.AddScoped<IOrderDetailsRepositoryAsync, OrderDetailsRepositoryAsync>();
builder.Services.AddScoped<IAddressRepositoryAsync, AddressRepositoryAsync>();
builder.Services.AddScoped<IPaymentTypeRepositoryAsync, PaymentTypeRepositoryAsync>();

builder.Services.AddAutoMapper(typeof(ApplicationMapper));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();