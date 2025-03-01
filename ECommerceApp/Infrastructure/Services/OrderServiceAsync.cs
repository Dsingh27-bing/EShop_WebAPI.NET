using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;
using AutoMapper;
using Infrastructure.Repository;

namespace Infrastructure.Services;

public class OrderServiceAsync:IOrderServiceAsync
{
    private readonly IOrderRepositoryAsync _orderRepositoryAsync;
    private readonly IMapper _mapper;

    public OrderServiceAsync(IOrderRepositoryAsync orderRepositoryAsync, IMapper mapper)
    {
        _orderRepositoryAsync = orderRepositoryAsync;
        _mapper = mapper;
    }
  
    public async Task<IEnumerable<OrderResponseModel>> GetAllAsync()
    {
        var responseModels = _mapper.Map<IEnumerable<OrderResponseModel>>(await _orderRepositoryAsync.GetAllAsync());
        return (responseModels);
    }

    public Task<IEnumerable<OrderResponseModel>> GetOrderByCustomerId(int customerId)
    {
        throw new NotImplementedException();
        
    }

    public async Task<OrderResponseModel> GetByIdAsync(int id)
    {
        var order = await _orderRepositoryAsync.GetByIdAsync(id);
        var responseModel = _mapper.Map<OrderResponseModel>(order);
        return responseModel;
    }

    public Task<int> InsertAsync(OrderRequestModel reqModel)
    {
        var orderIn= _mapper.Map<Order>(reqModel);
        return _orderRepositoryAsync.InsertAsync(orderIn);
    }

    public Task<int> UpdateAsync(OrderRequestModel reqModel)
    {
        var orderIn = _mapper.Map<Order>(reqModel);
        return _orderRepositoryAsync.UpdateAsync(orderIn);
    }

    public Task<int> DeleteByIdAsync(int id)
    {
        return _orderRepositoryAsync.DeleteAsync(id);
    }

    public Task<int> SaveOrder(OrderRequestModel reqModel)
    {
        var orderIn= _mapper.Map<Order>(reqModel);
        return _orderRepositoryAsync.InsertAsync(orderIn);
    }

    public Task<OrderDetailsResponseModel> CheckOrderHistory(int customerId, int orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderResponseModel> CheckOrderStatus(int id)
    {
        var order = await _orderRepositoryAsync.GetByIdAsync(id);
        var responseModel = _mapper.Map<OrderResponseModel>(order);
        return responseModel;
    }

    public Task<int> CancelOrder(int orderId)
    {
        return _orderRepositoryAsync.DeleteAsync(orderId);
    }

    public Task<int> OrderCompleted(OrderRequestModel requestModel)
    {
        var orderIn = _mapper.Map<Order>(requestModel);
        return _orderRepositoryAsync.UpdateAsync(orderIn);
    }

    public Task<int> UpdateOrder(OrderRequestModel reqModel)
    {
        var orderIn = _mapper.Map<Order>(reqModel);
        return _orderRepositoryAsync.UpdateAsync(orderIn);
    }
}