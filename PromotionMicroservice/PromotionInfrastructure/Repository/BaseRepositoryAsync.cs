using Microsoft.EntityFrameworkCore;
using PromotionApplicationCore.Contracts.Repository;
using PromotionInfrastructure.Data;

namespace PromotionInfrastructure.Repository;

public class BaseRepositoryAsync<T>:IRepositoryAsync<T> where T:class
{
    protected readonly PromotionDbContext _promotionDbContext;

    public BaseRepositoryAsync(PromotionDbContext dbContext)
    {
        _promotionDbContext = dbContext;
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
       return await  _promotionDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _promotionDbContext.Set<T>().FindAsync(id);
    }

    public async Task<int> InsertAsync(T entity)
    {
        var result = await  _promotionDbContext.Set<T>().AddAsync(entity);
        return await _promotionDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
         _promotionDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return await _promotionDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var result = await GetByIdAsync(id);
        _promotionDbContext.Remove(result);
        return await _promotionDbContext.SaveChangesAsync();
    }
}