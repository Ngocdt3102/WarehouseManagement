using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // ==========================================
    // 1. SYSTEM & AUTHENTICATION
    // ==========================================
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Permission> Permissions { get; set; } = null!;
    public DbSet<UserRole> UserRoles { get; set; } = null!; // Bảng trung gian
    public DbSet<RolePermission> RolePermissions { get; set; } = null!; // Bảng trung gian

    public DbSet<File> Files { get; set; } = null!;
    public DbSet<AuditLog> AuditLogs { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!; // [MỚI] Thông báo hệ thống

    // ==========================================
    // 2. MASTER DATA
    // ==========================================
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Unit> Units { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Supplier> Suppliers { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;

    // ==========================================
    // 3. WAREHOUSE & INVENTORY
    // ==========================================
    public DbSet<Warehouse> Warehouses { get; set; } = null!;
    public DbSet<WarehouseLocation> WarehouseLocations { get; set; } = null!;
    public DbSet<Inventory> Inventories { get; set; } = null!;
    public DbSet<StockMovement> StockMovements { get; set; } = null!;

    // ==========================================
    // 4. TRANSACTIONS (NHẬP - XUẤT - CHUYỂN KHO)
    // ==========================================
    // Phiếu nhập
    public DbSet<GoodsReceipt> GoodsReceipts { get; set; } = null!;
    public DbSet<GoodsReceiptDetail> GoodsReceiptDetails { get; set; } = null!;

    // Phiếu xuất
    public DbSet<GoodsIssue> GoodsIssues { get; set; } = null!;
    public DbSet<GoodsIssueDetail> GoodsIssueDetails { get; set; } = null!;

    // Phiếu chuyển kho
    public DbSet<StockTransfer> StockTransfers { get; set; } = null!;
    public DbSet<StockTransferDetail> StockTransferDetails { get; set; } = null!;

    // ==========================================
    // 5. ADVANCED WMS (QUẢN LÝ NÂNG CAO)
    // ==========================================
    public DbSet<Batch> Batches { get; set; } = null!; // [MỚI] Quản lý Lô
    public DbSet<SerialNumber> SerialNumbers { get; set; } = null!; // [MỚI] Quản lý Serial
    public DbSet<InventoryAdjustment> InventoryAdjustments { get; set; } = null!; // [MỚI] Phiếu điều chỉnh tồn kho
    public DbSet<Stocktake> Stocktakes { get; set; } = null!; // [MỚI] Phiếu kiểm kê

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Lệnh này cực kỳ mạnh mẽ: Nó sẽ quét toàn bộ project và tự động tìm tất cả 
        // các class kế thừa từ IEntityTypeConfiguration<T> (nằm trong thư mục Data/Configurations/)
        // để apply vào database. Bạn không cần phải gọi thủ công từng file cấu hình nữa.
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}