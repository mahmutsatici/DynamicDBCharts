using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ChartsAPI.Models;
using ChartsAPI.Data;

namespace ChartsAPI.Services
{
    public class ProductService
    {
        private readonly ProductContext _dbContext;

        public ProductService(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProductListAsync()
        {
            return await _dbContext.Product
                .FromSqlRaw<Product>("GetPrductList")
                .ToListAsync();
        }
    }
}
