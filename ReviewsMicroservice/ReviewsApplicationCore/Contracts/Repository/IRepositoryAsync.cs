namespace ReviewsApplicationCore.Contracts.Repository;

public interface IRepositoryAsync<T> where T: class
{
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T> GetByIdAsync(int id);
    public Task<int> InsertAsync(T entity);
    public Task<int> UpdateAsync(T entity);
    public Task<int> DeleteAsync(int id);
    
}