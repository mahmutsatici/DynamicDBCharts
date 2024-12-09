using Microsoft.AspNetCore.Mvc;
using ChartsAPI.Models;
using ChartsAPI.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ChartsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService ProductService;
        private readonly ConnectionService _connectionService;

        public ProductController(ProductService ProductService, ConnectionService connectionService)
        {
            this.ProductService = ProductService;
            _connectionService = connectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductListAsync(string serverName, string dbName, string connType)
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
                // Bağlantı bilgilerini güncelledim
                _connectionService.UpdateConnection(serverName, dbName, connType.ToLower() == "true");

                // Ürün listesini alıyorum
                var productList = await ProductService.GetProductListAsync();
                return Ok(productList);
            }
            catch (Exception ex)
            {
                // Hata durumunda genel bir hata mesajı döndürür
                return StatusCode(500, $"An error occurred while fetching the product list: {ex.Message}");
            }
        }
    }
}
