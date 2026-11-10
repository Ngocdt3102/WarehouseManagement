namespace WarehouseManagement.API.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    // Auth & System
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    IPermissionRepository Permissions { get; }
    IFileRepository Files { get; }
    IAuditLogRepository AuditLogs { get; }
    INotificationRepository Notifications { get; }

    // Master Data
    IProductRepository Products { get; }
    ICategoryRepository Categories { get; }
    IUnitRepository Units { get; }
    ISupplierRepository Suppliers { get; }
    ICustomerRepository Customers { get; }

    // Warehouse & Inventory
    IWarehouseRepository Warehouses { get; }
    IWarehouseLocationRepository WarehouseLocations { get; }
    IInventoryRepository Inventories { get; }
    IStockMovementRepository StockMovements { get; }

    // Transactions
    IGoodsReceiptRepository GoodsReceipts { get; }
    IGoodsIssueRepository GoodsIssues { get; }
    IStockTransferRepository StockTransfers { get; }

    // Advanced WMS
    IInventoryAdjustmentRepository InventoryAdjustments { get; }
    IStocktakeRepository Stocktakes { get; }
    IBatchRepository Batches { get; }
    ISerialNumberRepository SerialNumbers { get; }

    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}