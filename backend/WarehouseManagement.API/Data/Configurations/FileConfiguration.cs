using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
// Đổi alias nếu class File của bạn bị trùng với System.IO.File
using FileEntity = WarehouseManagement.API.Models.File;

namespace WarehouseManagement.API.Data.Configurations;

public class FileConfiguration : IEntityTypeConfiguration<FileEntity>
{
    public void Configure(EntityTypeBuilder<FileEntity> builder)
    {
        builder.ToTable("Files");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.FileName).HasMaxLength(255).IsRequired();
        builder.Property(f => f.ContentType).HasMaxLength(100).IsRequired();
        builder.Property(f => f.DownloadUrl).HasMaxLength(500).IsRequired();
        builder.Property(f => f.Length).IsRequired();
        builder.Property(f => f.Content).IsRequired();
    }
}
