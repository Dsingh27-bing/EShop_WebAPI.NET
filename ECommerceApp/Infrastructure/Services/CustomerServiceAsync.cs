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

    public CustomerServiceAsync(ICustomerRepositoryAsync customerRepositoryAsync, IMapper mapper)
    {
        _mapper = mapper;
        _customerRepositoryAsync = customerRepositoryAsync;
        
    }
    
    public async Task<IEnumerable<Customer>> GetCustomerAddressByUserId(int userId)
    {
        var customer = await _customerRepositoryAsync.GetCustomerAddressByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<Customer>>(customer);
    }

    public Task<int> SaveCustomerAddress(CustomerRequestModel requestModel)
    {
        var customerIn = _mapper.Map<Customer>(requestModel);
        return _customerRepositoryAsync.InsertAsync(customerIn);
    }

    public Task<int> InsertAsync(CustomerRequestModel reqModel)
    {
        var customerIn = _mapper.Map<Customer>(reqModel);
        return _customerRepositoryAsync.InsertAsync(customerIn);
    }
}