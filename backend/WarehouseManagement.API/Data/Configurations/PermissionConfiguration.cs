using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permissions");

        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.Code).IsUnique(); // Mã quyền không được trùng (vd: PRODUCT_VIEW)
        builder.Property(p => p.Code).HasMaxLength(50).IsRequired();

        builder.Property(p => p.Module).HasMaxLength(50).IsRequired(); // Tên module để nhóm trên UI
        builder.Property(p => p.Description).HasMaxLength(200);
    }
}