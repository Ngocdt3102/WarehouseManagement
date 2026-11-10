using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("AuditLogs");
        builder.HasKey(al => al.Id);

        builder.Property(al => al.Action).HasMaxLength(50).IsRequired();
        builder.Property(al => al.TableName).HasMaxLength(100).IsRequired();
        builder.Property(al => al.RecordId).HasMaxLength(50).IsRequired();

        // OldValues và NewValues có thể chứa JSON lớn nên không giới hạn MaxLength (tương đương nvarchar(max))

        builder.Property(al => al.IpAddress).HasMaxLength(50);

        builder.HasOne(al => al.User)
               .WithMany()
               .HasForeignKey(al => al.UserId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}