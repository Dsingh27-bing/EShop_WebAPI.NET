using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;
using AutoMapper;

namespace Infrastructure.Services;

public class PaymentServiceAsync: IPaymentServiceAsync
{
    private readonly IMapper _mapper;
    private readonly IPaymentMethodRepositoryAsync _paymentMethodRepositoryAsync;
    private readonly IOrderRepositoryAsync _orderRepositoryAsync;

    public PaymentServiceAsync(IPaymentMethodRepositoryAsync paymentMethodRepositoryAsync, IMapper mapper, IOrderRepositoryAsync orderRepositoryAsync)
    {
        _mapper = mapper;
        _paymentMethodRepositoryAsync = paymentMethodRepositoryAsync;
        _orderRepositoryAsync = orderRepositoryAsync;
    }
    
    public async Task<IEnumerable<PaymentMethod>> GetPaymentByCustomerId(int customerId)
    {
        var payments = await _orderRepositoryAsync.GetPaymentsByCustomerIdAsync(customerId);
        var responseModels = _mapper.Map<IEnumerable<PaymentMethod>>(payments);
        return responseModels;
    }

    public Task<int> SavePayment(PaymentMethodRequestModel requestModel)
    {
        var paymentMethodIn = _mapper.Map<PaymentMethod>(requestModel);
        return _paymentMethodRepositoryAsync.InsertAsync(paymentMethodIn);
    }

    public Task<int> UpdatePayment(PaymentMethodRequestModel requestModel)
    {
        var paymentMethodIn = _mapper.Map<PaymentMethod>(requestModel);
        return _paymentMethodRepositoryAsync.UpdateAsync(paymentMethodIn);
    }

    public Task<int> DeletePayment(int paymentId)
    {
        return _paymentMethodRepositoryAsync.DeleteAsync(paymentId);
    }

    public async Task<PaymentMethod> GetByIdAsync(int id)
    {
        var paymentMethod = await _paymentMethodRepositoryAsync.GetByIdAsync(id);
        var responseModel = _mapper.Map<PaymentMethod>(paymentMethod);
        return responseModel;
    }

    public async Task<IEnumerable<PaymentMethodResponseModel>> GetAllAsync()
    {
        var responseModels = _mapper.Map<IEnumerable<PaymentMethodResponseModel>>(await _paymentMethodRepositoryAsync.GetAllAsync());
        return responseModels;
    }

    public Task<int> InsertAsync(PaymentMethodRequestModel requestModel)
    {
        var paymentMethodIn = _mapper.Map<PaymentMethod>(requestModel);
        return _paymentMethodRepositoryAsync.InsertAsync(paymentMethodIn);
    }

    public Task<int> UpdateAsync(PaymentMethodRequestModel requestModel)
    {
        var paymentMethodIn = _mapper.Map<PaymentMethod>(requestModel);
        return _paymentMethodRepositoryAsync.UpdateAsync(paymentMethodIn);
    }

    public Task<int> DeleteAsync(int id)
    {
        return _paymentMethodRepositoryAsync.DeleteAsync(id);
    }
}