using Microsoft.EntityFrameworkCore;
using SalesManagement.Domain.Customers;

namespace SalesManagement.Infrastructure;

public class SalesManagementDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public SalesManagementDbContext(DbContextOptions<SalesManagementDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}