using ApplicationCoreShipping.Contracts.Repository;
using InfrastructureShipping.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureShipping.Repository;

public class BaseRepositoryAsync<T>:IRepositoryAsync<T> where T:class
{
    private readonly ShippingDbContext _dbContext;

    public BaseRepositoryAsync(ShippingDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<int> InsertAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public Task<int> UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return _dbContext.SaveChangesAsync();
    }

    public Task<int> DeleteAsync(int id)
    {
        var result = GetByIdAsync(id).Result;
        _dbContext.Remove(result);
        return _dbContext.SaveChangesAsync();
    }
}