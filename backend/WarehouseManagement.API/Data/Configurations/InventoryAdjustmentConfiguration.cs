using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class InventoryAdjustmentConfiguration : IEntityTypeConfiguration<InventoryAdjustment>
{
    public void Configure(EntityTypeBuilder<InventoryAdjustment> builder)
    {
        builder.ToTable("InventoryAdjustments");
        builder.HasKey(ia => ia.Id);

        builder.HasIndex(ia => ia.AdjustmentCode).IsUnique();
        builder.Property(ia => ia.AdjustmentCode).HasMaxLength(50).IsRequired();

        builder.Property(ia => ia.Reason).HasMaxLength(500).IsRequired();
        builder.Property(ia => ia.Status).HasMaxLength(20).IsRequired();

        // Ràng buộc các khóa ngoại
        builder.HasOne(ia => ia.Product)
               .WithMany()
               .HasForeignKey(ia => ia.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ia => ia.Warehouse)
               .WithMany()
               .HasForeignKey(ia => ia.WarehouseId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ia => ia.Location)
               .WithMany()
               .HasForeignKey(ia => ia.LocationId)
               .OnDelete(DeleteBehavior.Restrict);

        // Không cho phép xóa nhân viên nếu họ đã từng lập phiếu điều chỉnh
        builder.HasOne(ia => ia.Employee)
               .WithMany()
               .HasForeignKey(ia => ia.EmployeeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}