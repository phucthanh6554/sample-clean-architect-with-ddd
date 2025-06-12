using Microsoft.EntityFrameworkCore;
using SalesManagement.Domain.Customers;
using SalesManagement.Domain.Orders;

namespace SalesManagement.Infrastructure;

public class SalesManagementDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<Order> Orders { get; set; }

    public SalesManagementDbContext(DbContextOptions<SalesManagementDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}