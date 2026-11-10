using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class StocktakeConfiguration : IEntityTypeConfiguration<Stocktake>
{
    public void Configure(EntityTypeBuilder<Stocktake> builder)
    {
        builder.ToTable("Stocktakes");
        builder.HasKey(st => st.Id);

        builder.HasIndex(st => st.StocktakeCode).IsUnique();
        builder.Property(st => st.StocktakeCode).HasMaxLength(50).IsRequired();

        builder.Property(st => st.Status).HasMaxLength(20).IsRequired();
        builder.Property(st => st.Remarks).HasMaxLength(500);

        builder.HasOne(st => st.Warehouse)
               .WithMany()
               .HasForeignKey(st => st.WarehouseId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(st => st.CreatedBy)
               .WithMany()
               .HasForeignKey(st => st.CreatedById)
               .OnDelete(DeleteBehavior.Restrict);
    }
}