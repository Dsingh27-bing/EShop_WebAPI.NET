using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;
using AutoMapper;
using Infrastructure.Repository;

namespace Infrastructure.Services;

public class CustomerServiceAsync:ICustomerServiceAsync
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepositoryAsync _customerRepositoryAsync;
    private readonly IAddressRepositoryAsync _addressRepositoryAsync;
    private readonly IUserAddressRepositoryAsync _userAddressRepositoryAsync;

    public CustomerServiceAsync(ICustomerRepositoryAsync customerRepositoryAsync, IMapper mapper, IAddressRepositoryAsync addressRepositoryAsync, IUserAddressRepositoryAsync userAddressRepositoryAsync)
    {
        _mapper = mapper;
        _customerRepositoryAsync = customerRepositoryAsync;
        _addressRepositoryAsync = addressRepositoryAsync;
        _userAddressRepositoryAsync = userAddressRepositoryAsync;
        
    }
    
    public async Task<IEnumerable<Customer>> GetCustomerAddressByUserId(int userId)
    {
        var customer = await _customerRepositoryAsync.GetCustomerAddressByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<Customer>>(customer);
    }

    public async Task<UserAddressResponseModel> SaveCustomerAddress(AddressRequestModel requestModel)
    {
        var address = _mapper.Map<Address>(requestModel);
        var addressId = (await _addressRepositoryAsync.InsertAsync(address));
        var userAddress = new UserAddress()
        {
            AddressId = addressId,
            CustomerId = requestModel.CustomerId,
            IsDefaultAddress = requestModel.IsDefaultAddress
        };
        
        return _mapper.Map<UserAddressResponseModel>(await _userAddressRepositoryAsync.InsertAsync(userAddress));
    }

    public Task<int> InsertAsync(CustomerRequestModel reqModel)
    {
        var customerIn = _mapper.Map<Customer>(reqModel);
        return _customerRepositoryAsync.InsertAsync(customerIn);
    }
}