using Microsoft.EntityFrameworkCore;
using ReviewsApplicationCore.Contracts.Repository;
using ReviewsApplicationCore.Contracts.Services;
using ReviewsApplicationCore.Helper;
using ReviewsInfrastructure.Data;
using ReviewsInfrastructure.Repositories;
using ReviewsInfrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ReviewsDbContext>(options =>
{
    // options.UseSqlServer(builder.Configuration.GetConnectionString("ReviewDB"));
    options.UseSqlServer(Environment.GetEnvironmentVariable("ReviewDB"));
});


builder.Services.AddScoped<IReviewsServiceAsync, ReviewsServiceAsync>();
builder.Services.AddScoped<IReviewsRepositoryAsync, ReviewsRepositoryAsync>();

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