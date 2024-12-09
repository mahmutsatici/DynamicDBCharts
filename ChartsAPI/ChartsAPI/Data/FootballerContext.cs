using ChartsAPI.Models;
using ChartsAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace ChartsAPI.Data
{
    public class FootballerContext : DbContext
    {
        private readonly ConnectionService _connectionService;

        public FootballerContext(ConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
            var connection = _connectionService.GetConnection();

            
            var connectionString = $"Server={connection.ServerName};Database={connection.DatabaseName};Trusted_Connection=True;";


            options.UseSqlServer(connectionString);
        }

        public DbSet<Footballer> Footballer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Footballer>(entity =>
            {
                entity.HasNoKey(); 
                entity.ToTable("Footballer"); 
            });
        }
    }
}

