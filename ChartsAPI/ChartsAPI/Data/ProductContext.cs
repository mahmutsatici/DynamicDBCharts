using Microsoft.EntityFrameworkCore;
using ChartsAPI.Models;
using ChartsAPI.Services;
using Microsoft.Extensions.Configuration;

namespace ChartsAPI.Data
{
    public class ProductContext : DbContext
    {
        private readonly ConnectionService _connectionService;

        public ProductContext(ConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
            var connection = _connectionService.GetConnection();

            
            var connectionString = $"Server={connection.ServerName};Database={connection.DatabaseName};Trusted_Connection=True;";
               

            options.UseSqlServer(connectionString);
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasNoKey(); 
                entity.ToTable("Product"); 
            });
        }
    }
}
