using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.Data.SqlClient;
using ChartsAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class MovieStoreController : ControllerBase
{
    private readonly DbContextOptions<MovieStoreContext> _options;
    private readonly ConnectionService _connectionService;

    public MovieStoreController(DbContextOptions<MovieStoreContext> options, ConnectionService connectionService)
    {
        _options = options;
        _connectionService = connectionService;
    }

    [HttpGet]
    public IActionResult GetDirectorViews(string serverName, string dbName, string connType)
    {
        
        if (string.IsNullOrEmpty(serverName) || string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(connType))
        {
            return BadRequest("Geçersiz parametreler.");
        }

        //Connection dinamik olarak kullanıcıdan gelen parametrelere göre burda değişiyor.
        var connectionString = $"Server={serverName};Database={dbName};";
        _connectionService.UpdateConnection(serverName, dbName, connType.ToLower() == "true");


        
        if (connType.ToLower() == "true")
        {
            connectionString += "Trusted_Connection=True;";
        }
        else if (connType.ToLower() == "false")
        {
            
            connectionString += "Trusted_Connection=False;";
        }
        else
        {
            return BadRequest("Geçersiz bağlantı türü. Lütfen 'true' ya da 'false' girin.");
        }

        try
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<MovieStoreContext>();
            optionsBuilder.UseSqlServer(connectionString);

           
            using (var context = new MovieStoreContext(optionsBuilder.Options))
            {
                var directorViews = context.DirectorViewReports.ToList();
                return Ok(directorViews);
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
