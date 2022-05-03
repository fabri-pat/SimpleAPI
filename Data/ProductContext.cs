using Microsoft.EntityFrameworkCore;
using SimpleAPI.Models;

namespace SimpleAPI.Data;

public class ProductContext : DbContext
{
    public ProductContext (DbContextOptions<ProductContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
}