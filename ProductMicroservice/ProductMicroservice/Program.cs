

using Microsoft.EntityFrameworkCore;
using ProductApplicationCore.Contracts.Repository;
using ProductApplicationCore.Contracts.Service;
using ProductApplicationCore.Helper;
using ProductInfrastructure.Data;
using ProductInfrastructure.Repositories;
using ProductInfrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductMicroservice"));
});
// Add services to the container.

builder.Services.AddScoped<IProductServiceAsync, ProductServiceAsync>();
builder.Services.AddScoped<IProductVariationServiceAsync, ProductVariationServiceAsync>();
builder.Services.AddScoped<ICategoryServiceAsync, CategoryServiceAsync>();
builder.Services.AddScoped<ICategoryVariationServiceAsync, CategoryVariationServiceAsync>();


builder.Services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();
builder.Services.AddScoped<ICategoryVariationRepositoryAsync, CategoryVariationRepositoryAsync>();
builder.Services.AddScoped<IProductCategoryRepositoryAsync, ProductCategoryRepositoryAsync>();
builder.Services.AddScoped<IProductVariationValueRepositoryAsync, ProductVariationValueRepositoryAsync>();
builder.Services.AddScoped<IVariationValueRepositoryAsync, VariationValueRepositoryAsync>();

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