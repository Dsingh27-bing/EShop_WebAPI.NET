using ApplicationCore.Entities;
using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;

namespace ApplicationCore.Contracts.Services;

public interface ICustomerServiceAsync
{
    Task<IEnumerable<Customer>> GetCustomerAddressByUserId(int userId);
    Task<int> SaveCustomerAddress(CustomerRequestModel requestModel); //insert
    Task<int> InsertAsync(CustomerRequestModel reqModel);
    

}