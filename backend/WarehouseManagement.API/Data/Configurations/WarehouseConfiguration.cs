using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable("Warehouses");

        builder.HasKey(w => w.Id);

        builder.HasIndex(w => w.Code).IsUnique();
        builder.Property(w => w.Code).HasMaxLength(20).IsRequired();
        builder.Property(w => w.Name).HasMaxLength(150).IsRequired();
        builder.Property(w => w.Address).HasMaxLength(250);

        // Chuyển đổi Enum Status thành chuỗi khi lưu xuống DB (Tùy chọn giúp DB dễ đọc hơn)
        builder.Property(w => w.Status)
               .HasConversion<string>()
               .HasMaxLength(20);

        // Liên kết với Quản lý kho (User)
        builder.HasOne(w => w.Manager)
               .WithMany()
               .HasForeignKey(w => w.ManagerId)
               .OnDelete(DeleteBehavior.SetNull); // Quản lý nghỉ việc thì Kho không bị xóa, chỉ set null
    }
}