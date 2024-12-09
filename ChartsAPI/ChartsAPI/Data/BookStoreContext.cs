using Microsoft.EntityFrameworkCore;
using ChartsAPI.Models;

public class BookStoreContext : DbContext
{
    public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
    {
    }

    public DbSet<AuthorSalesReport> AuthorSalesReports { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<AuthorSalesReport>()
            .HasNoKey() 
            .ToView("AuthorSalesReport");
    }
}
