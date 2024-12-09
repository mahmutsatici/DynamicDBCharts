using ChartsAPI.Data;
using ChartsAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ChartsAPI.Services
{
    public class FootballerService
    {
        private readonly FootballerContext _dbContext;

        public FootballerService(FootballerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Footballer>> GetFootballerListAsync()
        {
            return await _dbContext.Footballer
                .FromSqlRaw<Footballer>("GetFootballerList")
                .ToListAsync();
        }
    }
}
