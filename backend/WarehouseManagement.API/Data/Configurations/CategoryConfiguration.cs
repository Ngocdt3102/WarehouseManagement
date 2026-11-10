using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.API.Models;

namespace WarehouseManagement.API.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(500);

        // 1. Cấu hình danh mục Cha - Con (Đệ quy)
        builder.HasOne(c => c.ParentCategory)
               .WithMany(c => c.SubCategories) // Tùy thuộc bạn có tạo ICollection<Category> SubCategories trong model không, nếu không có thể để trống WithMany()
               .HasForeignKey(c => c.ParentCategoryId)
               .OnDelete(DeleteBehavior.Restrict); // Không cho phép xóa danh mục cha nếu còn danh mục con

        // 2. Cấu hình khóa ngoại cho ảnh (tương tự User)
        builder.HasOne(c => c.Image)
               .WithMany()
               .HasForeignKey(c => c.ImageId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}