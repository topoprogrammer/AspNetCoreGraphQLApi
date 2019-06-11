using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreGraphQLApi.Data;
using AspNetCoreGraphQLApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreGraphQLApi.Repositories
{
    public class ProductRepository
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Product>> GetAll()
        {
            return _dbContext.Products.ToListAsync();
        }

        public Task<Product> GetOne(int id)
        {
            return _dbContext.Products.SingleAsync(p => p.Id == id);
        }
    }
}
