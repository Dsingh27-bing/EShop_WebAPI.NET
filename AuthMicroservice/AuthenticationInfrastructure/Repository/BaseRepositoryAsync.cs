using AuthenticationApplicationCore.Contracts.Repository;
using AuthenticationInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationInfrastructure.Repository;

public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
{
    private readonly AuthenticationDbContext authenticateDb;

    public BaseRepositoryAsync(AuthenticationDbContext dbContext)
    {
        authenticateDb = dbContext;
    }
    
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await authenticateDb.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await authenticateDb.Set<T>().FindAsync(id);
    }

    public async Task<int> InsertAsync(T entity)
    {
        await authenticateDb.Set<T>().AddAsync(entity);
        return await authenticateDb.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        authenticateDb.Set<T>().Entry(entity).State = EntityState.Modified;
        return await authenticateDb.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var result = GetByIdAsync(id).Result;
        authenticateDb.Remove(result);
        return await authenticateDb.SaveChangesAsync();
    }
}