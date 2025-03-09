using AuthenticationApplicationCore.Contracts.Repository;
using AuthenticationApplicationCore.Contracts.Service;
using AuthenticationApplicationCore.Entities;
using AuthenticationApplicationCore.Model;
using AutoMapper;

namespace AuthenticationInfrastructure.Service;

public class AuthenticationServiceAsync: IAuthenticationServiceAsync
{
    private readonly IAuthenticationRepositoryAsync _authenticationRepository;
    private readonly IMapper _mapper;

    public AuthenticationServiceAsync(IAuthenticationRepositoryAsync authenticationRepository, IMapper mapper)
    {
        _authenticationRepository = authenticationRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<UserResponseModel>> GetAllAsync()
    {
        var users = await _authenticationRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserResponseModel>>(users);
    }
    
    public async Task<UserResponseModel> GetByIdAsync(int id)
    {
        var user = await _authenticationRepository.GetByIdAsync(id);
        return _mapper.Map<UserResponseModel>(user);
    }
    
    public async Task<int> InsertAsync(UserRequestModel reqModel)
    {
        var user = _mapper.Map<User>(reqModel);
        return await _authenticationRepository.InsertAsync(user);
    }
    
    public async Task<int> UpdateAsync(UserRequestModel reqModel)
    {
        var user = _mapper.Map<User>(reqModel);
        return await _authenticationRepository.UpdateAsync(user);
    }
    
    public async Task<int> DeleteAsync(int id)
    {
        return await _authenticationRepository.DeleteAsync(id);
    }
}
