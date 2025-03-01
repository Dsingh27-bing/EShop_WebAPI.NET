using Microsoft.EntityFrameworkCore;
using ReviewsApplicationCore.Contracts.Repository;
using ReviewsApplicationCore.Entity;
using ReviewsInfrastructure.Data;

namespace ReviewsInfrastructure.Repositories;

public class ReviewsRepositoryAsync:BaseRepositoryAsync<Reviews>, IReviewsRepositoryAsync
{
    private readonly ReviewsDbContext _reviewsDbContext;

    public ReviewsRepositoryAsync(ReviewsDbContext dbContext): base(dbContext)
    {
        _reviewsDbContext = dbContext;
    }
    
    public async Task<IEnumerable<Reviews>> GetReviewsByProductId(int productId)
    {
        return await _reviewsDbContext.Reviews.AsNoTracking()
            .Where(r => r.ProductId == productId)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Reviews>> GetReviewsByUserId(int userId)
    {
        return await _reviewsDbContext.Reviews.AsNoTracking()
            .Where(r => r.CustomerId == userId)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Reviews>> GetReviewsByYear(int year)
    {
        return await _reviewsDbContext.Reviews.AsNoTracking()
            .Where(r => r.ReviewDate.Year == year)
            .ToListAsync();
    }
    
    
}
