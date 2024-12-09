using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.Data.SqlClient;
using ChartsAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class CarSalesController : ControllerBase
{
    private readonly DbContextOptions<CarSalesContext> _options;
    private readonly ConnectionService _connectionService;

    public CarSalesController(DbContextOptions<CarSalesContext> options, ConnectionService connectionService)
    {
        _options = options;
        _connectionService = connectionService;
    }

    [HttpGet]
    public IActionResult GetCarSalesReports(string serverName, string dbName, string connType)
    {
        
        if (string.IsNullOrEmpty(serverName) || string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(connType))
        {
            return BadRequest("Geçersiz parametreler.");
        }

        
        var connectionString = $"Server={serverName};Database={dbName};";
        _connectionService.UpdateConnection(serverName, dbName, connType.ToLower() == "true");


        
        if (connType == "true")
        {
            connectionString += "Trusted_Connection=True;";
        }
        else if (connType == "false")
        {
            connectionString += "Trusted_Connection=False;";
        }
        else
        {
            return BadRequest("Geçersiz bağlantı türü. Lütfen 'true' ya da 'false' girin.");
        }

        try
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<CarSalesContext>();
            optionsBuilder.UseSqlServer(connectionString);

          
            using (var context = new CarSalesContext(optionsBuilder.Options))
            {
                var carSalesReports = context.CarSalesReports.ToList();
                return Ok(carSalesReports);
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
