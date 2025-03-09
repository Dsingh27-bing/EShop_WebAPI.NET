using AuthenticationApplicationCore.Contracts.Repository;
using AuthenticationApplicationCore.Contracts.Service;
using AuthenticationApplicationCore.Helper;
using AuthenticationInfrastructure.Data;
using AuthenticationInfrastructure.Repository;
using AuthenticationInfrastructure.Service;
using JwtAuthenticationManager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AuthenticationDbContext>(options =>
{
    options.UseSqlServer(Environment.GetEnvironmentVariable("AuthenticationDb"));
});


builder.Services.AddScoped<IAuthenticationServiceAsync, AuthenticationServiceAsync>();
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();

builder.Services.AddScoped<IAuthenticationRepositoryAsync, AuthenticationRepositoryAsync>();
builder.Services.AddAutoMapper(typeof(ApplicationMapper));



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<JWTTokenHandler>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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