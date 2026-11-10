using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class SerialNumberConfiguration : IEntityTypeConfiguration<SerialNumber>
{
    public void Configure(EntityTypeBuilder<SerialNumber> builder)
    {
        builder.ToTable("SerialNumbers");
        builder.HasKey(sn => sn.Id);

        // Mỗi mã Serial là duy nhất trên toàn hệ thống
        builder.HasIndex(sn => sn.SerialCode).IsUnique();
        builder.Property(sn => sn.SerialCode).HasMaxLength(100).IsRequired();

        builder.Property(sn => sn.Status).HasMaxLength(50).IsRequired();

        // Ràng buộc Sản phẩm
        builder.HasOne(sn => sn.Product)
               .WithMany()
               .HasForeignKey(sn => sn.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

        // Ràng buộc Lô (Một Serial có thể thuộc một Lô cụ thể hoặc không)
        builder.HasOne(sn => sn.Batch)
               .WithMany()
               .HasForeignKey(sn => sn.BatchId)
               .OnDelete(DeleteBehavior.SetNull);

        // Ràng buộc Phiếu nhập chi tiết
        builder.HasOne(sn => sn.GoodsReceiptDetail)
               .WithMany()
               .HasForeignKey(sn => sn.GoodsReceiptDetailId)
               .OnDelete(DeleteBehavior.SetNull);

        // Ràng buộc Phiếu xuất chi tiết
        builder.HasOne(sn => sn.GoodsIssueDetail)
               .WithMany()
               .HasForeignKey(sn => sn.GoodsIssueDetailId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
