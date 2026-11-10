using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class GoodsReceiptConfiguration : IEntityTypeConfiguration<GoodsReceipt>
{
    public void Configure(EntityTypeBuilder<GoodsReceipt> builder)
    {
        builder.ToTable("GoodsReceipts");
        builder.HasKey(gr => gr.Id);

        builder.HasIndex(gr => gr.ReceiptCode).IsUnique();
        builder.Property(gr => gr.ReceiptCode).HasMaxLength(50).IsRequired();
        builder.Property(gr => gr.Remarks).HasMaxLength(500);

        builder.Property(gr => gr.Status)
               .HasConversion<string>()
               .HasMaxLength(20);

        builder.Property(gr => gr.TotalAmount).HasColumnType("decimal(18,2)");

        builder.HasOne(gr => gr.Supplier)
               .WithMany()
               .HasForeignKey(gr => gr.SupplierId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(gr => gr.Warehouse)
               .WithMany()
               .HasForeignKey(gr => gr.WarehouseId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(gr => gr.Employee)
               .WithMany()
               .HasForeignKey(gr => gr.EmployeeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}