using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class StockTransferConfiguration : IEntityTypeConfiguration<StockTransfer>
{
    public void Configure(EntityTypeBuilder<StockTransfer> builder)
    {
        builder.ToTable("StockTransfers");
        builder.HasKey(st => st.Id);

        builder.HasIndex(st => st.TransferCode).IsUnique();
        builder.Property(st => st.TransferCode).HasMaxLength(50).IsRequired();
        builder.Property(st => st.Remarks).HasMaxLength(500);

        builder.Property(st => st.Status)
               .HasConversion<string>()
               .HasMaxLength(20);

        // Ràng buộc Kho nguồn và Kho đích
        builder.HasOne(st => st.SourceWarehouse)
               .WithMany()
               .HasForeignKey(st => st.SourceWarehouseId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(st => st.DestinationWarehouse)
               .WithMany()
               .HasForeignKey(st => st.DestinationWarehouseId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(st => st.Employee)
               .WithMany()
               .HasForeignKey(st => st.EmployeeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}