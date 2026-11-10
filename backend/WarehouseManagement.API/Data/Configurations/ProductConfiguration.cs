using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        // Đánh Index cho SKU và Barcode để tìm kiếm (Scan mã vạch) nhanh nhất
        builder.HasIndex(p => p.SKU).IsUnique();
        builder.HasIndex(p => p.Barcode);

        builder.Property(p => p.SKU).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Brand).HasMaxLength(100);
        builder.Property(p => p.Barcode).HasMaxLength(100);
        builder.Property(p => p.Description).HasMaxLength(1000);

        // Ràng buộc liên kết với Category (Ngăn xóa Category nếu có Product)
        builder.HasOne(p => p.Category)
               .WithMany()
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        // Ràng buộc liên kết với Unit (Ngăn xóa Unit nếu có Product)
        builder.HasOne(p => p.Unit)
               .WithMany()
               .HasForeignKey(p => p.UnitId)
               .OnDelete(DeleteBehavior.Restrict);

        // Ràng buộc với Supplier (Có thể nullable)
        builder.HasOne(p => p.Supplier)
               .WithMany()
               .HasForeignKey(p => p.SupplierId)
               .OnDelete(DeleteBehavior.SetNull);

        // Ràng buộc hình ảnh sản phẩm
        builder.HasOne(p => p.Image)
               .WithMany()
               .HasForeignKey(p => p.ImageId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}