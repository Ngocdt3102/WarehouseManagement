using Microsoft.EntityFrameworkCore;
using WarehouseManagement.API.Data;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;

namespace WarehouseManagement.API.Repositories.Implementations;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context) { }

    public async Task<Product?> GetProductWithDetailsAsync(int id) =>
        await _dbSet.Include(p => p.Category).Include(p => p.Unit).Include(p => p.Supplier).Include(p => p.Image)
        .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<bool> IsSkuExistsAsync(string sku) => await _dbSet.AnyAsync(p => p.SKU == sku);
}