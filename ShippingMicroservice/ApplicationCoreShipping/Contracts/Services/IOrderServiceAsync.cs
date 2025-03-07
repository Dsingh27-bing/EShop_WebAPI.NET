using ApplicationCoreShipping.Model;

namespace ApplicationCoreShipping.Contracts.Services;

public interface IOrderServiceAsync
{
    public Task<bool> UpdateOrderStatusAsync(int orderId, OrderState status);
}