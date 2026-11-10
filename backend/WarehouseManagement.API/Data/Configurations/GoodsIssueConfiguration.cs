using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class GoodsIssueConfiguration : IEntityTypeConfiguration<GoodsIssue>
{
    public void Configure(EntityTypeBuilder<GoodsIssue> builder)
    {
        builder.ToTable("GoodsIssues");
        builder.HasKey(gi => gi.Id);

        builder.HasIndex(gi => gi.IssueCode).IsUnique();
        builder.Property(gi => gi.IssueCode).HasMaxLength(50).IsRequired();
        builder.Property(gi => gi.Remarks).HasMaxLength(500);

        builder.Property(gi => gi.Status)
               .HasConversion<string>()
               .HasMaxLength(20);

        builder.HasOne(gi => gi.Customer)
               .WithMany()
               .HasForeignKey(gi => gi.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(gi => gi.Warehouse)
               .WithMany()
               .HasForeignKey(gi => gi.WarehouseId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(gi => gi.Employee)
               .WithMany()
               .HasForeignKey(gi => gi.EmployeeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}