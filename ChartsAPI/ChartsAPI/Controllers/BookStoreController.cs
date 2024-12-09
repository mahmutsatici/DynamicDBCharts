using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.Data.SqlClient;
using ChartsAPI.Models;
using ChartsAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class BookStoreController : ControllerBase
{
    private readonly DbContextOptions<BookStoreContext> _options;
    private readonly ConnectionService _connectionService;

    
    public BookStoreController(DbContextOptions<BookStoreContext> options, ConnectionService connectionService)
    {
        _options = options;
        _connectionService = connectionService;
    }


    [HttpGet]
    public IActionResult GetAuthorSales(string serverName, string dbName, string connType)
    {
        
        if (string.IsNullOrEmpty(serverName) || string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(connType))
        {
            return BadRequest("Geçersiz parametreler.");
        }

        
        
        var connectionString = $"Server={serverName};Database={dbName};";
        _connectionService.UpdateConnection(serverName, dbName, connType.ToLower() == "true");

       
        if (connType.ToLower() == "true")
        {
            connectionString += "Trusted_Connection=True;";
        }
        else if (connType.ToLower() == "false")
        {
            
            connectionString += "Trusted_Connection=True;";
        }
        else
        {
            return BadRequest("Geçersiz bağlantı türü. Lütfen 'true' ya da 'false' girin.");
        }

        try
        {   
           
            var optionsBuilder = new DbContextOptionsBuilder<BookStoreContext>();
            optionsBuilder.UseSqlServer(connectionString);

           
            using (var context = new BookStoreContext(optionsBuilder.Options))
            {
                var authorSales = context.AuthorSalesReports.ToList(); // DbSet adı güncellendi
                return Ok(authorSales);
            }
        }
        catch (SqlException ex)
        {
            
            return BadRequest($"Veritabanı bağlantı hatası: {ex.Message}");
        }
        catch (Exception ex)
        {
            
            return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
        }
    }
}
