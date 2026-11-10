using Microsoft.EntityFrameworkCore.Storage;
using WarehouseManagement.API.Data;
using WarehouseManagement.API.Repositories.Interfaces;

namespace WarehouseManagement.API.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IDbContextTransaction? _transaction;

    // Khai báo properties
    public IUserRepository Users { get; private set; }
    public IRoleRepository Roles { get; private set; }
    public IPermissionRepository Permissions { get; private set; }
    public IFileRepository Files { get; private set; }
    public IAuditLogRepository AuditLogs { get; private set; }
    public INotificationRepository Notifications { get; private set; }

    public IProductRepository Products { get; private set; }
    public ICategoryRepository Categories { get; private set; }
    public IUnitRepository Units { get; private set; }
    public ISupplierRepository Suppliers { get; private set; }
    public ICustomerRepository Customers { get; private set; }

    public IWarehouseRepository Warehouses { get; private set; }
    public IWarehouseLocationRepository WarehouseLocations { get; private set; }
    public IInventoryRepository Inventories { get; private set; }
    public IStockMovementRepository StockMovements { get; private set; }

    public IGoodsReceiptRepository GoodsReceipts { get; private set; }
    public IGoodsIssueRepository GoodsIssues { get; private set; }
    public IStockTransferRepository StockTransfers { get; private set; }

    public IInventoryAdjustmentRepository InventoryAdjustments { get; private set; }
    public IStocktakeRepository Stocktakes { get; private set; }
    public IBatchRepository Batches { get; private set; }
    public ISerialNumberRepository SerialNumbers { get; private set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        // Khởi tạo các Repository
        Users = new UserRepository(_context);
        Roles = new RoleRepository(_context);
        Permissions = new PermissionRepository(_context);
        Files = new FileRepository(_context);
        AuditLogs = new AuditLogRepository(_context);
        Notifications = new NotificationRepository(_context);

        Products = new ProductRepository(_context);
        Categories = new CategoryRepository(_context);
        Units = new UnitRepository(_context);
        Suppliers = new SupplierRepository(_context);
        Customers = new CustomerRepository(_context);

        Warehouses = new WarehouseRepository(_context);
        WarehouseLocations = new WarehouseLocationRepository(_context);
        Inventories = new InventoryRepository(_context);
        StockMovements = new StockMovementRepository(_context);

        GoodsReceipts = new GoodsReceiptRepository(_context);
        GoodsIssues = new GoodsIssueRepository(_context);
        StockTransfers = new StockTransferRepository(_context);

        InventoryAdjustments = new InventoryAdjustmentRepository(_context);
        Stocktakes = new StocktakeRepository(_context);
        Batches = new BatchRepository(_context);
        SerialNumbers = new SerialNumberRepository(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await SaveChangesAsync();
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
        finally
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}