using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class StockTransferDetailConfiguration : IEntityTypeConfiguration<StockTransferDetail>
{
    public void Configure(EntityTypeBuilder<StockTransferDetail> builder)
    {
        builder.ToTable("StockTransferDetails");
        builder.HasKey(std => std.Id);

        builder.HasOne(std => std.StockTransfer)
               .WithMany(st => st.Details)
               .HasForeignKey(std => std.StockTransferId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(std => std.Product)
               .WithMany()
               .HasForeignKey(std => std.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(std => std.SourceLocation)
               .WithMany()
               .HasForeignKey(std => std.SourceLocationId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(std => std.DestinationLocation)
               .WithMany()
               .HasForeignKey(std => std.DestinationLocationId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}