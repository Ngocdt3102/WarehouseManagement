using WarehouseManagement.API.DTOs.Inventory;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;
using WarehouseManagement.API.Services.Interfaces;

namespace WarehouseManagement.API.Services.Implementations;

public class InventoryService : IInventoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public InventoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<InventoryListDto>> GetInventoriesAsync(InventoryFilterDto filter)
    {
        // 1. Gọi Repo để lấy Data đã được lọc và nối bảng (SQL Server xử lý tối ưu)
        var inventories = await _unitOfWork.Inventories.GetFilteredInventoriesAsync(filter);

        // 2. Map sang InventoryListDto (Mạng dữ liệu nhẹ nhất gửi về Frontend)
        return inventories.Select(i => new InventoryListDto
        {
            Id = i.Id,
            ProductSKU = i.Product?.SKU ?? "N/A",
            ProductName = i.Product?.Name ?? "N/A",
            WarehouseName = i.Warehouse?.Name ?? "N/A",
            LocationCode = i.Location?.Code ?? "N/A",
            Quantity = i.Quantity,
            ReservedQuantity = i.ReservedQuantity,
            AvailableQuantity = i.AvailableQuantity
        });
    }

    public async Task<InventoryResponseDto?> GetInventoryDetailAsync(int productId, int warehouseId, int? locationId)
    {
        // 1. Lấy chi tiết Tồn kho (Có sẵn thông tin Unit, Category...)
        var i = await _unitOfWork.Inventories.GetExactInventoryWithDetailsAsync(productId, warehouseId, locationId);
        if (i == null) return null;

        // 2. Map sang DTO chi tiết
        return new InventoryResponseDto
        {
            Id = i.Id,
            ProductId = i.ProductId,
            ProductSKU = i.Product?.SKU ?? "N/A",
            ProductName = i.Product?.Name ?? "N/A",
            UnitName = i.Product?.Unit?.Name ?? "N/A",
            WarehouseId = i.WarehouseId,
            WarehouseName = i.Warehouse?.Name ?? "N/A",
            LocationId = i.LocationId ?? 0,
            LocationCode = i.Location?.Code ?? "N/A",
            Quantity = i.Quantity,
            ReservedQuantity = i.ReservedQuantity,
            AvailableQuantity = i.AvailableQuantity,
            LastUpdatedAt = i.LastUpdatedAt
        };
    }

    // =========================================================================
    // CÁC HÀM XỬ LÝ LOGIC NGHIỆP VỤ BÊN DƯỚI (Không gọi SaveChanges)
    // =========================================================================

    public async Task AddStockAsync(int productId, int warehouseId, int? locationId, int quantity)
    {
        if (quantity <= 0) throw new ArgumentException("Số lượng nhập phải lớn hơn 0.");

        var inventory = await _unitOfWork.Inventories.GetExactInventoryAsync(productId, warehouseId, locationId);

        if (inventory == null)
        {
            inventory = new Inventory
            {
                ProductId = productId,
                WarehouseId = warehouseId,
                LocationId = locationId,
                Quantity = quantity,
                AvailableQuantity = quantity,
                ReservedQuantity = 0,
                LastUpdatedAt = DateTime.UtcNow
            };
            await _unitOfWork.Inventories.AddAsync(inventory);
        }
        else
        {
            inventory.Quantity += quantity;
            inventory.AvailableQuantity += quantity;
            inventory.LastUpdatedAt = DateTime.UtcNow;
            _unitOfWork.Inventories.Update(inventory);
        }
    }

    public async Task RemoveStockAsync(int productId, int warehouseId, int? locationId, int quantity)
    {
        if (quantity <= 0) throw new ArgumentException("Số lượng xuất phải lớn hơn 0.");
        var inventory = await _unitOfWork.Inventories.GetExactInventoryAsync(productId, warehouseId, locationId);

        if (inventory == null || inventory.AvailableQuantity < quantity)
            throw new InvalidOperationException($"Tồn kho khả dụng không đủ. (Sản phẩm ID: {productId})");

        inventory.Quantity -= quantity;
        inventory.AvailableQuantity -= quantity;
        inventory.LastUpdatedAt = DateTime.UtcNow;
        _unitOfWork.Inventories.Update(inventory);
    }

    public async Task ReserveStockAsync(int productId, int warehouseId, int? locationId, int quantity)
    {
        var inventory = await _unitOfWork.Inventories.GetExactInventoryAsync(productId, warehouseId, locationId);

        if (inventory == null || inventory.AvailableQuantity < quantity)
            throw new InvalidOperationException($"Tồn kho khả dụng không đủ giữ chỗ. (Sản phẩm ID: {productId})");

        inventory.AvailableQuantity -= quantity;
        inventory.ReservedQuantity += quantity;
        inventory.LastUpdatedAt = DateTime.UtcNow;
        _unitOfWork.Inventories.Update(inventory);
    }

    public async Task ReleaseReservedStockAsync(int productId, int warehouseId, int? locationId, int quantity)
    {
        var inventory = await _unitOfWork.Inventories.GetExactInventoryAsync(productId, warehouseId, locationId);

        if (inventory == null || inventory.ReservedQuantity < quantity)
            throw new InvalidOperationException("Số lượng giải phóng lớn hơn số lượng đang giữ chỗ.");

        inventory.ReservedQuantity -= quantity;
        inventory.AvailableQuantity += quantity;
        inventory.LastUpdatedAt = DateTime.UtcNow;
        _unitOfWork.Inventories.Update(inventory);
    }
}