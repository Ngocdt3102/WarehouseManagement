using WarehouseManagement.API.DTOs.Inventory;

namespace WarehouseManagement.API.Services.Interfaces;

public interface IInventoryService
{
    // Cập nhật DTO trả về cho hàm Get Danh sách và Chi tiết
    Task<IEnumerable<InventoryListDto>> GetInventoriesAsync(InventoryFilterDto filter);
    Task<InventoryResponseDto?> GetInventoryDetailAsync(int productId, int warehouseId, int? locationId);

    // Các hàm Logic nghiệp vụ cốt lõi giữ nguyên
    Task AddStockAsync(int productId, int warehouseId, int? locationId, int quantity);
    Task RemoveStockAsync(int productId, int warehouseId, int? locationId, int quantity);
    Task ReserveStockAsync(int productId, int warehouseId, int? locationId, int quantity);
    Task ReleaseReservedStockAsync(int productId, int warehouseId, int? locationId, int quantity);
}