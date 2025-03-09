using AuthenticationApplicationCore.Model;

namespace AuthenticationApplicationCore.Contracts.Service;

public interface IAuthenticationServiceAsync
{
    public Task<IEnumerable<UserResponseModel>> GetAllAsync();
    public Task<UserResponseModel> GetByIdAsync(int id);
    public Task<int> InsertAsync(UserRequestModel reqModel);
    public Task<int> UpdateAsync(UserRequestModel reqModel);
    public Task<int> DeleteAsync(int id);
}