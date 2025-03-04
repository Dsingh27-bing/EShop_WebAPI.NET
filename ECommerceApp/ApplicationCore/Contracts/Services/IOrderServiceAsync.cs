using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;

namespace ApplicationCore.Contracts.Services;

public interface IOrderServiceAsync
{
    Task<IEnumerable<OrderResponseModel>> GetAllAsync();
    Task<OrderResponseModel> GetByIdAsync(int id);
    Task<int> InsertAsync(OrderRequestModel reqModel);
    Task<int> UpdateAsync(OrderRequestModel reqModel);

    Task<int> DeleteByIdAsync(int id);
    Task<int> SaveOrder(OrderRequestModel reqModel); //new insert
    Task<IEnumerable<OrderDetailsResponseModel>> CheckOrderHistory( int orderId); //new get by id
    Task<string> CheckOrderStatus(int id);//new get by id
    Task<OrderResponseModel> CancelOrder(int orderId);//new update status
    Task<OrderResponseModel> OrderCompleted(int orderId);//new update
    Task<int> UpdateOrder(OrderRequestModel reqModel);//new update
    
}