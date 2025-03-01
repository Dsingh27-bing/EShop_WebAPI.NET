using Microsoft.EntityFrameworkCore;
using ReviewsApplicationCore.Contracts.Repository;
using ReviewsInfrastructure.Data;

namespace ReviewsInfrastructure.Repositories;

public class BaseRepositoryAsync<T>:IRepositoryAsync<T> where T:class
{
    private readonly ReviewsDbContext _dbContext;

    public BaseRepositoryAsync(ReviewsDbContext dbContext)
    {
        _dbContext = dbContext;
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
        var result = await _dbContext.Set<T>().AddAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var result = await GetByIdAsync(id);
        _dbContext.Remove(result);
        return await _dbContext.SaveChangesAsync();
    }
}