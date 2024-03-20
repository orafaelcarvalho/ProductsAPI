using Dapper;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Domain.Entities;
using ProductsAPI.Domain.Enums;
using ProductsAPI.Infra.DataContext;
using ProductsAPI.Infra.DbSession;
using ProductsAPI.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDataContext _db;
        private readonly DbSet<Product> _dbSet;
        private IDbSessionDapper _conn;

        public ProductRepository(ProductsDataContext dbContext, IDbSessionDapper context)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext), "Falha ao acessar o banco de dados.");
            }
            _db = dbContext;
            _dbSet = _db.Set<Product>();
            _conn = context;
        }

        public async Task<Product> GetByCodeAsync(int code)
        {
            return await _dbSet.Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetPaginatedAsync(int quantity, int page)
        {
            int selectedPage = (page - 1) * quantity;
            List<Product> list = await _dbSet
                .AsNoTracking()
                .Where(p => p.Status == ProductStatus.Active)
                .Skip(selectedPage)
                .Take(quantity)
                .ToListAsync();
            return list;
        }

        public async Task AddAsync(Product product)
        {
            _dbSet.Add(product);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _dbSet.Update(product);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _dbSet.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task<Product> GetByCodeDapperAsync(int code)
        {
            using (var conn = _conn.Connection)
            {
                string query = "SELECT * FROM PRODUCT WHERE CODE = @code";
                Product product = await conn.QueryFirstOrDefaultAsync<Product>(sql: query, param: new { code });

                return product;
            }
        }
    }
}
