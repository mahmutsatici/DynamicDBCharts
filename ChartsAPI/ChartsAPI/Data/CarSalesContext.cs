using ChartsAPI.Models;
using Microsoft.EntityFrameworkCore;

public class CarSalesContext : DbContext
{
    public CarSalesContext(DbContextOptions<CarSalesContext> options)
        : base(options)
    {
    }

    public DbSet<CarSalesReport> CarSalesReports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<CarSalesReport>()
            .HasNoKey() 
            .ToView("BrandSalesReport"); 
    }
}
