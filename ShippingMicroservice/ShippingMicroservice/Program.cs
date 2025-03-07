using ApplicationCoreShipping.Contracts.Repository;
using ApplicationCoreShipping.Contracts.Services;
using ApplicationCoreShipping.Helper;
using InfrastructureShipping.Data;
using InfrastructureShipping.Repository;
using InfrastructureShipping.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShippingDbContext>(options =>
{
    // options.UseSqlServer(builder.Configuration.GetConnectionString("ShippingDb"));
    options.UseSqlServer(Environment.GetEnvironmentVariable("ShippingDb"));
});


// Add services to the container.
builder.Services.AddScoped<IShipperServiceAsync, ShipperServiceAsync>();
builder.Services.AddScoped<IShipperRegionServiceAsync, ShipperRegionServiceAsync>();

builder.Services.AddScoped<IShipperRegionRepositoryAsync, ShipperRegionRepositoryAsync>();
builder.Services.AddScoped<IShippingRepositoryAsync, ShippingRepositoryAsync>();


builder.Services.AddAutoMapper(typeof(ApplicationMapper));
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(p =>
    {
        p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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
app.UseCors();
app.MapControllers();

app.Run();