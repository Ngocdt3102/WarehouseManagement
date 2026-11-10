using WarehouseManagement.API.DTOs.Inventory;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Repositories.Interfaces;

public interface IInventoryRepository : IRepository<Inventory>
{
    Task<Inventory?> GetExactInventoryAsync(int productId, int warehouseId, int? locationId);
    Task<IEnumerable<Inventory>> GetInventoryByWarehouseAsync(int warehouseId);

    // [MỚI BỔ SUNG] Dùng cho tính năng Lọc (Filter)
    Task<IEnumerable<Inventory>> GetFilteredInventoriesAsync(InventoryFilterDto filter);

    // [MỚI BỔ SUNG] Lấy chi tiết tồn kho có Include tên Sản phẩm, Đơn vị, Kho
    Task<Inventory?> GetExactInventoryWithDetailsAsync(int productId, int warehouseId, int? locationId);
}