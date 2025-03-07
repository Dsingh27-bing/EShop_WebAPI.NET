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
    private readonly IOrderDetailsRepositoryAsync _orderDetailsRepositoryAsync;

    public OrderServiceAsync(IOrderRepositoryAsync orderRepositoryAsync, IMapper mapper, IOrderDetailsRepositoryAsync orderDetailsRepositoryAsync)
    {
        _orderRepositoryAsync = orderRepositoryAsync;
        _mapper = mapper;
        _orderDetailsRepositoryAsync = orderDetailsRepositoryAsync;
    }
  
    public async Task<IEnumerable<OrderResponseModel>> GetAllAsync()
    {
        var responseModels = _mapper.Map<IEnumerable<OrderResponseModel>>(await _orderRepositoryAsync.GetAllAsync());
        return (responseModels);
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

    public async Task<IEnumerable<OrderDetailsResponseModel>> CheckOrderHistory(int orderId)
    {
        var orderDetails = await _orderDetailsRepositoryAsync.GetOrderDetailsByOrderIdAsync(orderId);
        return _mapper.Map<IEnumerable<OrderDetailsResponseModel>>(orderDetails);
    }

    public async Task<string> CheckOrderStatus(int id)
    {
        return (await _orderRepositoryAsync.GetByIdAsync(id))?.OrderStatus.ToString()?? "Order not found";
    }

    public async Task<OrderResponseModel> CancelOrder(int orderId)
    {
        var order = await _orderRepositoryAsync.GetByIdAsync(orderId);
        if (order == null)
        {
            throw new Exception("Cannot Cancel Order, Not Found");
        }
        order.OrderStatus = OrderStatus.Canceled;
        var updatedOrder = await _orderRepositoryAsync.UpdateAsync(order);
        return _mapper.Map<OrderResponseModel>(updatedOrder);
    }

    public async Task<Order> OrderCompleted(int orderId)
    {
        var order = await _orderRepositoryAsync.GetByIdAsync(orderId);
        if (order == null)
        {
            throw new Exception("Cannot Complete Order, Not Found");
        }
        order.OrderStatus = OrderStatus.Completed;
        var updatedOrder = await _orderRepositoryAsync.UpdateAsync(order);
        return order;
    }

    public Task<int> UpdateOrder(OrderRequestModel reqModel)
    {
        var orderIn = _mapper.Map<Order>(reqModel);
        return _orderRepositoryAsync.UpdateAsync(orderIn);
    }
    
    public async Task<bool> UpdateOrderStatus(int orderId, OrderStatus status)
    {
        var order = await _orderRepositoryAsync.GetByIdAsync(orderId);
        if (order == null)
        {
            throw new Exception("Order not found");
        }
        order.OrderStatus = status;
        var orderUpdate = _mapper.Map<Order>(order);
        return await _orderRepositoryAsync.PutAsync(orderId,order);
    }
}