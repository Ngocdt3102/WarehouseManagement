using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class GoodsReceiptDetailConfiguration : IEntityTypeConfiguration<GoodsReceiptDetail>
{
    public void Configure(EntityTypeBuilder<GoodsReceiptDetail> builder)
    {
        builder.ToTable("GoodsReceiptDetails");
        builder.HasKey(grd => grd.Id);

        builder.Property(grd => grd.UnitPrice).HasColumnType("decimal(18,2)");
        builder.Property(grd => grd.BatchCode).HasMaxLength(50);

        // Cascade delete: Xóa phiếu nhập -> Xóa chi tiết phiếu nhập
        builder.HasOne(grd => grd.GoodsReceipt)
               .WithMany(gr => gr.Details)
               .HasForeignKey(grd => grd.GoodsReceiptId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(grd => grd.Product)
               .WithMany()
               .HasForeignKey(grd => grd.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(grd => grd.Location)
               .WithMany()
               .HasForeignKey(grd => grd.LocationId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}