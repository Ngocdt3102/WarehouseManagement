using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventories");

        builder.HasKey(i => i.Id);

        // Ràng buộc duy nhất: 1 Sản phẩm - 1 Kho - 1 Vị trí chỉ có 1 record tồn kho
        builder.HasIndex(i => new { i.ProductId, i.WarehouseId, i.LocationId }).IsUnique();

        // Ràng buộc Sản phẩm
        builder.HasOne(i => i.Product)
               .WithMany()
               .HasForeignKey(i => i.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

        // Ràng buộc Kho
        builder.HasOne(i => i.Warehouse)
               .WithMany()
               .HasForeignKey(i => i.WarehouseId)
               .OnDelete(DeleteBehavior.Restrict);

        // Ràng buộc Vị trí (Có thể null nếu thiết lập kho không quản lý chi tiết đến vị trí)
        builder.HasOne(i => i.Location)
               .WithMany()
               .HasForeignKey(i => i.LocationId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}