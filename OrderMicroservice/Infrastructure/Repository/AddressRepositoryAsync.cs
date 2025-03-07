using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class AddressRepositoryAsync:BaseRepositoryAsync<Address>, IAddressRepositoryAsync
{
    public AddressRepositoryAsync(ECommerceDbContext dbContext): base(dbContext)
    {
    }
}