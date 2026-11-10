using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable("Units");

        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.Name).IsUnique(); // Tên đơn vị tính không được trùng
        builder.Property(u => u.Name).HasMaxLength(50).IsRequired();

        builder.Property(u => u.Description).HasMaxLength(200);
    }
}