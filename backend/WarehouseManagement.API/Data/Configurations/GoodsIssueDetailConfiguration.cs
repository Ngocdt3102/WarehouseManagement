using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class GoodsIssueDetailConfiguration : IEntityTypeConfiguration<GoodsIssueDetail>
{
    public void Configure(EntityTypeBuilder<GoodsIssueDetail> builder)
    {
        builder.ToTable("GoodsIssueDetails");
        builder.HasKey(gid => gid.Id);

        // Cascade: Xóa phiếu xuất thì xóa chi tiết
        builder.HasOne(gid => gid.GoodsIssue)
               .WithMany(gi => gi.Details)
               .HasForeignKey(gid => gid.GoodsIssueId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(gid => gid.Product)
               .WithMany()
               .HasForeignKey(gid => gid.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(gid => gid.Location)
               .WithMany()
               .HasForeignKey(gid => gid.LocationId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}