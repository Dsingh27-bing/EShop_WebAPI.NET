namespace ApplicationCore.Contracts.Repository;

public interface IRepositoryAsync<T> where T:class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<int> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);

    Task<bool> PutAsync(int id, T entity);

}