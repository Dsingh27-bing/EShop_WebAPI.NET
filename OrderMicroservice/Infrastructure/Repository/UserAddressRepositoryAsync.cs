using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class UserAddressRepositoryAsync:BaseRepositoryAsync<UserAddress>, IUserAddressRepositoryAsync
{
    public UserAddressRepositoryAsync(ECommerceDbContext dbContext) : base(dbContext)
    {
    }
}