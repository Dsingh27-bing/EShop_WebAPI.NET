using Microsoft.EntityFrameworkCore;
using ProductApplicationCore.Contracts.Repository;
using ProductApplicationCore.Entities;
using ProductInfrastructure.Data;

namespace ProductInfrastructure.Repositories;

public class ProductRepositoryAsync:BaseRepositoryAsync<Product>, IProductRepositoryAsync

{
    
    private readonly ProductDbContext _dbContext;
    
    public ProductRepositoryAsync(ProductDbContext dbContext): base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Product>> GetProductByCategoryId(int categoryId)
    {
        return await _dbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
    }
    
    public async Task<IEnumerable<Product>> GetProductByName(string name)
    {
        return await _dbContext.Products.Where(p => p.Name.Contains(name)).ToListAsync();
    }
    
}
