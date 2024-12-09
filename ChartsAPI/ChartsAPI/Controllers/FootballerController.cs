using Microsoft.AspNetCore.Mvc;
using ChartsAPI.Models;
using ChartsAPI.Services;

namespace ChartsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballerController : ControllerBase
    {
        private readonly FootballerService FootballerService;
        private readonly ConnectionService _connectionService;


        public FootballerController(FootballerService FootballerService, ConnectionService connectionService)
        {
            this.FootballerService = FootballerService;
            _connectionService = connectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFootballerListAsync(string serverName, string dbName, string connType)
        {
            
            if (string.IsNullOrEmpty(serverName))
            {
                return BadRequest("Server name cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(dbName))
            {
                return BadRequest("Database name cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(connType))
            {
                return BadRequest("Connection type cannot be null or empty.");
            }

            
            if (connType.ToLower() != "true" && connType.ToLower() != "false")
            {
                return BadRequest("Connection type must be 'true' or 'false'.");
            }

            try
            {
                
                _connectionService.UpdateConnection(serverName, dbName, connType.ToLower() == "true");

                
                var footballerList = await FootballerService.GetFootballerListAsync();
                return Ok(footballerList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the product list: {ex.Message}");
            }
        }
    }
}
