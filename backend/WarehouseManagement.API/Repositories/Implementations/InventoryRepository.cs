using Microsoft.EntityFrameworkCore;
using WarehouseManagement.API.Data;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;

namespace WarehouseManagement.API.Repositories.Implementations;

public class InventoryRepository : Repository<Inventory>, IInventoryRepository
{
    public InventoryRepository(AppDbContext context) : base(context) { }

    public async Task<Inventory?> GetExactInventoryAsync(int productId, int warehouseId, int? locationId) =>
        await _dbSet.FirstOrDefaultAsync(i => i.ProductId == productId && i.WarehouseId == warehouseId && i.LocationId == locationId);
    public async Task<IEnumerable<Inventory>> GetFilteredInventoriesAsync(InventoryFilterDto filter)
    {
        var query = _dbSet
            .Include(i => i.Product)
                .ThenInclude(p => p.Category)
            .Include(i => i.Warehouse)
            .Include(i => i.Location)
            .AsQueryable();

        // Chỉ sinh ra câu lệnh WHERE trong SQL cho những trường có giá trị (HasValue)
        if (filter.WarehouseId.HasValue)
            query = query.Where(i => i.WarehouseId == filter.WarehouseId.Value);

        if (filter.ProductId.HasValue)
            query = query.Where(i => i.ProductId == filter.ProductId.Value);

        if (filter.LocationId.HasValue)
            query = query.Where(i => i.LocationId == filter.LocationId.Value);

        if (filter.InStockOnly == true)
            query = query.Where(i => i.AvailableQuantity > 0);

        if (filter.CategoryId.HasValue)
            query = query.Where(i => i.Product != null && i.Product.CategoryId == filter.CategoryId.Value);

        return await query.ToListAsync();
    }

    public async Task<Inventory?> GetExactInventoryWithDetailsAsync(int productId, int warehouseId, int? locationId)
    {
        return await _dbSet
            .Include(i => i.Product).ThenInclude(p => p.Unit)
            .Include(i => i.Warehouse)
            .Include(i => i.Location)
            .FirstOrDefaultAsync(i => i.ProductId == productId && i.WarehouseId == warehouseId && i.LocationId == locationId);
    }
}