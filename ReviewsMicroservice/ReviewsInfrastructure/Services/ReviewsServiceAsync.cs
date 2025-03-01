using AutoMapper;
using ReviewsApplicationCore.Contracts.Repository;
using ReviewsApplicationCore.Contracts.Services;
using ReviewsApplicationCore.Entity;
using ReviewsApplicationCore.Model;

namespace ReviewsInfrastructure.Services;

public class ReviewsServiceAsync:IReviewsServiceAsync
{
    private readonly IReviewsRepositoryAsync _reviewsRepository;
    private readonly IMapper _mapper;

    public ReviewsServiceAsync(IReviewsRepositoryAsync reviewsRepository, IMapper mapper)
    {
        _reviewsRepository = reviewsRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ReviewsResponseModel>> GetAllAsync()
    {
        var reviews = await _reviewsRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ReviewsResponseModel>>(reviews);
    }
    
    public async Task<ReviewsResponseModel> GetByIdAsync(int id)
    {
        var review = await _reviewsRepository.GetByIdAsync(id);
        return _mapper.Map<ReviewsResponseModel>(review);
    }
    
    public async Task<int> InsertAsync(ReviewsRequestModel requestModel)
    {
        var review = _mapper.Map<Reviews>(requestModel);
        return await _reviewsRepository.InsertAsync(review);
    }
    
    public async Task<int> UpdateAsync(ReviewsRequestModel requestModel)
    {
        var review = _mapper.Map<Reviews>(requestModel);
        return await _reviewsRepository.UpdateAsync(review);
    }
    
    public async Task<int> DeleteAsync(int id)
    {
        return await _reviewsRepository.DeleteAsync(id);
    }
    
    public async Task<IEnumerable<ReviewsResponseModel>> GetReviewsByProductId(int productId)
    {
        var reviews = await _reviewsRepository.GetReviewsByProductId(productId);
        return _mapper.Map<IEnumerable<ReviewsResponseModel>>(reviews);
    }
    
    public async Task<IEnumerable<ReviewsResponseModel>> GetReviewsByUserId(int userId)
    {
        var reviews = await _reviewsRepository.GetReviewsByUserId(userId);
        return _mapper.Map<IEnumerable<ReviewsResponseModel>>(reviews);
    }
    
    public async Task<IEnumerable<ReviewsResponseModel>> GetReviewsByYear(int year)
    {
        var reviews = await _reviewsRepository.GetReviewsByYear(year);
        return _mapper.Map<IEnumerable<ReviewsResponseModel>>(reviews);
    }
    
    public async Task<ReviewsResponseModel> ApproveReview(int id)
    {
        var review = await _reviewsRepository.GetByIdAsync(id);
        review.IsApproved = true;
        await _reviewsRepository.UpdateAsync(review);
        return _mapper.Map<ReviewsResponseModel>(review);
    }
    
    public async Task<ReviewsResponseModel> RejectReview(int id)
    {
        var review = await _reviewsRepository.GetByIdAsync(id);
        review.IsApproved = false;
        await _reviewsRepository.UpdateAsync(review);
        return _mapper.Map<ReviewsResponseModel>(review);
    }
    
}