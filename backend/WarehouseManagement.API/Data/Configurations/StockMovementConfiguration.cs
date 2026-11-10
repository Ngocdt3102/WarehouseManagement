using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
{
    public void Configure(EntityTypeBuilder<StockMovement> builder)
    {
        builder.ToTable("StockMovements");

        builder.HasKey(sm => sm.Id);

        builder.Property(sm => sm.MovementType)
               .HasConversion<string>()
               .HasMaxLength(50); // vd: IMPORT, EXPORT, TRANSFER

        builder.Property(sm => sm.ReferenceType).HasMaxLength(50); // vd: GOODS_RECEIPT

        // Ràng buộc Sản phẩm
        builder.HasOne(sm => sm.Product)
               .WithMany()
               .HasForeignKey(sm => sm.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

        // Ràng buộc Kho
        builder.HasOne(sm => sm.Warehouse)
               .WithMany()
               .HasForeignKey(sm => sm.WarehouseId)
               .OnDelete(DeleteBehavior.Restrict);

        // Ràng buộc Vị trí
        builder.HasOne(sm => sm.Location)
               .WithMany()
               .HasForeignKey(sm => sm.LocationId)
               .OnDelete(DeleteBehavior.Restrict);

        // Ràng buộc Người thực hiện
        builder.HasOne(sm => sm.User)
               .WithMany()
               .HasForeignKey(sm => sm.UserId)
               .OnDelete(DeleteBehavior.Restrict); // Không cho phép xóa User nếu họ đã từng thực hiện biến động kho
    }
}