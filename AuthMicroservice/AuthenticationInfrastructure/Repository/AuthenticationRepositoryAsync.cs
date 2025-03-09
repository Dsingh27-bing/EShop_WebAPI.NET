using AuthenticationApplicationCore.Contracts.Repository;
using AuthenticationApplicationCore.Entities;
using AuthenticationInfrastructure.Data;

namespace AuthenticationInfrastructure.Repository;

public class AuthenticationRepositoryAsync:BaseRepositoryAsync<User>,IAuthenticationRepositoryAsync
{
    public AuthenticationRepositoryAsync(AuthenticationDbContext dbContext) : base(dbContext)
    {
    }
}