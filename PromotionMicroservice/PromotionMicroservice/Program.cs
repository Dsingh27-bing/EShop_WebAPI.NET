using Microsoft.EntityFrameworkCore;
using PromotionApplicationCore.Contracts.Repository;
using PromotionApplicationCore.Contracts.Services;
using PromotionApplicationCore.Helper;
using PromotionInfrastructure.Data;
using PromotionInfrastructure.Repository;
using PromotionInfrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PromotionDbContext>(options =>
{
    // options.UseSqlServer(builder.Configuration.GetConnectionString("PromotionDB"));
    options.UseSqlServer(Environment.GetEnvironmentVariable("PromotionDB"));
});

builder.Services.AddScoped<IPromotionServiceAsync, PromotionServiceAsync>();
builder.Services.AddScoped<IPromotionRepositoryAsync, PromotionRepositoryAsync>();

builder.Services.AddAutoMapper(typeof(ApplicationMapper));

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

app.MapControllers();

app.Run();