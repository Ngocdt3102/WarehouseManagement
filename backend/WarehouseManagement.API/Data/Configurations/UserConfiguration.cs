using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        // Đánh Index & Unique để tìm kiếm nhanh và chống trùng lặp dữ liệu
        builder.HasIndex(u => u.EmployeeCode).IsUnique();
        builder.HasIndex(u => u.Username).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.EmployeeCode).HasMaxLength(20).IsRequired();
        builder.Property(u => u.Username).HasMaxLength(50).IsRequired();
        builder.Property(u => u.FullName).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(100);
        builder.Property(u => u.PhoneNumber).HasMaxLength(20);
        builder.Property(u => u.Password).IsRequired();

        // Thiết lập quan hệ 1-N (hoặc 1-1 lỏng lẻo) với bảng File cho Avatar
        builder.HasOne(u => u.Avatar)
               .WithMany() // Một file có thể được dùng chung (ví dụ avatar mặc định)
               .HasForeignKey(u => u.AvatarId)
               // Nếu xóa File ảnh trong DB, AvatarId của User sẽ về null chứ không xóa User
               .OnDelete(DeleteBehavior.SetNull);
    }
}