using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;

namespace ApplicationCore.Contracts.Services;

public interface IOrderServiceAsync
{
    Task<IEnumerable<OrderResponseModel>> GetAllAsync();
    Task<IEnumerable<OrderResponseModel>> GetOrderByCustomerId(int customerId);
    Task<OrderResponseModel> GetByIdAsync(int id);
    Task<int> InsertAsync(OrderRequestModel reqModel);
    Task<int> UpdateAsync(OrderRequestModel reqModel);

    Task<int> DeleteByIdAsync(int id);
    Task<int> SaveOrder(OrderRequestModel reqModel); //new insert
    Task<OrderDetailsResponseModel> CheckOrderHistory(int customerId, int orderId); //new get by id
    Task<OrderResponseModel> CheckOrderStatus(int id);//new get by id
    Task<int> CancelOrder(int orderId);//new delete
    Task<int> OrderCompleted(OrderRequestModel requestModel);//new update
    Task<int> UpdateOrder(OrderRequestModel reqModel);//new update
    
}