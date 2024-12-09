using ChartsAPI.Models;
using Microsoft.EntityFrameworkCore;

public class MovieStoreContext : DbContext
{
    public MovieStoreContext(DbContextOptions<MovieStoreContext> options)
        : base(options)
    {
    }

    public DbSet<DirectorViewReport> DirectorViewReports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<DirectorViewReport>()
            .HasNoKey() 
            .ToView("DirectorViewReport"); 
    }
}
