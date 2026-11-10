using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class WarehouseLocationConfiguration : IEntityTypeConfiguration<WarehouseLocation>
{
    public void Configure(EntityTypeBuilder<WarehouseLocation> builder)
    {
        builder.ToTable("WarehouseLocations");

        builder.HasKey(l => l.Id);

        builder.HasIndex(l => l.Code).IsUnique(); // vd: WH1-ZONEA-R1-S1-B1
        builder.Property(l => l.Code).HasMaxLength(50).IsRequired();

        builder.Property(l => l.Zone).HasMaxLength(50);
        builder.Property(l => l.Rack).HasMaxLength(50);
        builder.Property(l => l.Shelf).HasMaxLength(50);
        builder.Property(l => l.Bin).HasMaxLength(50);

        // Liên kết với Kho
        builder.HasOne(l => l.Warehouse)
               .WithMany() // Nếu Model Warehouse có ICollection<WarehouseLocation> Locations thì điền vào WithMany(w => w.Locations)
               .HasForeignKey(l => l.WarehouseId)
               .OnDelete(DeleteBehavior.Restrict); // Không cho xóa Kho nếu trong Kho đã phân bổ các Vị trí
    }
}