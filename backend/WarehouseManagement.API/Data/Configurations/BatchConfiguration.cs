using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class BatchConfiguration : IEntityTypeConfiguration<Batch>
{
    public void Configure(EntityTypeBuilder<Batch> builder)
    {
        builder.ToTable("Batches");
        builder.HasKey(b => b.Id);

        // Mỗi mã Lô phải là duy nhất
        builder.HasIndex(b => b.BatchCode).IsUnique();
        builder.Property(b => b.BatchCode).HasMaxLength(50).IsRequired();

        // Không cho phép xóa Sản phẩm nếu đã có Lô sản xuất
        builder.HasOne(b => b.Product)
               .WithMany()
               .HasForeignKey(b => b.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}