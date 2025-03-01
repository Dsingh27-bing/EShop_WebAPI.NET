using ReviewsApplicationCore.Entity;

namespace ReviewsApplicationCore.Contracts.Repository;

public interface IReviewsRepositoryAsync:IRepositoryAsync<Reviews>
{
    public Task<IEnumerable<Reviews>> GetReviewsByProductId(int productId);
    public Task<IEnumerable<Reviews>> GetReviewsByUserId(int userId);

    public Task<IEnumerable<Reviews>> GetReviewsByYear(int year);
}