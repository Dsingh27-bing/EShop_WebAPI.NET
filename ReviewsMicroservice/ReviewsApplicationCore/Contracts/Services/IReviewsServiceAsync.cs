using ReviewsApplicationCore.Model;

namespace ReviewsApplicationCore.Contracts.Services;

public interface IReviewsServiceAsync
{
    public Task<IEnumerable<ReviewsResponseModel>> GetAllAsync();
    public Task<ReviewsResponseModel> GetByIdAsync(int id);
    public Task<int> InsertAsync(ReviewsRequestModel requestModel);
    public Task<int> UpdateAsync(ReviewsRequestModel requestModel);
    public Task<int> DeleteAsync(int id);
    public Task<IEnumerable<ReviewsResponseModel>> GetReviewsByProductId(int productId);
    public Task<IEnumerable<ReviewsResponseModel>> GetReviewsByUserId(int userId);
    public Task<IEnumerable<ReviewsResponseModel>> GetReviewsByYear(int year);

    public Task<ReviewsResponseModel> ApproveReview(int id);

    public Task<ReviewsResponseModel> RejectReview(int id);

}