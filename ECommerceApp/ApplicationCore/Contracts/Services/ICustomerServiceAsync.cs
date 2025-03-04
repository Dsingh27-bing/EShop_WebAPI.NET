using ApplicationCore.Entities;
using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;

namespace ApplicationCore.Contracts.Services;

public interface ICustomerServiceAsync
{
    Task<IEnumerable<Customer>> GetCustomerAddressByUserId(int userId);
    Task<UserAddressResponseModel> SaveCustomerAddress(AddressRequestModel requestModel); //insert of address
    Task<int> InsertAsync(CustomerRequestModel reqModel);
    

}