using Microsoft.EntityFrameworkCore;
using PromotionApplicationCore.Entities;

namespace PromotionInfrastructure.Data;

public class PromotionDbContext:DbContext
{
    public PromotionDbContext(DbContextOptions<PromotionDbContext> options): base(options)
    {
        
    }
    
    public DbSet<PromotionSale> Promotions { get; set; }
    public DbSet<PromotionDetails> PromotionDetails { get; set; }   
    
    
}