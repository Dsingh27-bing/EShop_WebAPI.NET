using System.Collections;
using ApplicationCore.Entities;
using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;

namespace ApplicationCore.Contracts.Services;

public interface IPaymentServiceAsync
{
    Task<IEnumerable<PaymentMethod>> GetPaymentByCustomerId(int customerId);
    Task<int> SavePayment(PaymentMethodRequestModel requestModel); //insert
    Task<int> UpdatePayment(PaymentMethodRequestModel requestModel); //update
    Task<int> DeletePayment(int paymentId); //delete
    
    Task<PaymentMethod> GetByIdAsync(int id);
    Task<IEnumerable<PaymentMethodResponseModel>> GetAllAsync();
    Task<int> InsertAsync(PaymentMethodRequestModel requestModel);
    Task<int> UpdateAsync(PaymentMethodRequestModel requestModel);
    Task<int> DeleteAsync(int id);
    
}