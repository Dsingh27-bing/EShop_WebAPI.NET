using AuthenticationApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationInfrastructure.Data;

public class AuthenticationDbContext:DbContext
{
    public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
}
