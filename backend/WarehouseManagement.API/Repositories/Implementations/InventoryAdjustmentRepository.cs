using WarehouseManagement.API.Data;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;

namespace WarehouseManagement.API.Repositories.Implementations;

public class InventoryAdjustmentRepository : Repository<InventoryAdjustment>, IInventoryAdjustmentRepository
{
    public InventoryAdjustmentRepository(AppDbContext context) : base(context) { }
}