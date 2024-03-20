using Microsoft.EntityFrameworkCore;
using ProductsAPI.Domain.Entities;
using ProductsAPI.Infra.DataContext;
using ProductsAPI.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplierAPI.Infra.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ProductsDataContext _db;
        private readonly DbSet<Supplier> _dbSet;

        public SupplierRepository(ProductsDataContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext), "Failed to access the database.");
            }
            _db = dbContext;
            _dbSet = _db.Set<Supplier>();
        }

        public async Task<Supplier> GetByCodeAsync(int code)
        {
            return await _dbSet.Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(Supplier supplier)
        {
            _dbSet.Add(supplier);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            _dbSet.Update(supplier);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Supplier supplier)
        {
            _dbSet.Remove(supplier);
            await _db.SaveChangesAsync();
        }
    }
}
