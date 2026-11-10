using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.API.Models;

[Table("Suppliers")]
public class SupplierModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Mã nhà cung cấp là bắt buộc.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Mã nhà cung cấp phải từ 3-20 ký tự.")]
    [RegularExpression(@"^[A-Z0-9\-_]+$", ErrorMessage = "Mã nhà cung cấp chỉ chứa chữ in hoa, số, gạch ngang/dưới.")]
    public string Code { get; set; } = null!;

    [Required(ErrorMessage = "Tên nhà cung cấp là bắt buộc.")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Tên nhà cung cấp phải từ 2-150 ký tự.")]
    public string Name { get; set; } = null!;

    [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
    [StringLength(20, ErrorMessage = "Số điện thoại không vượt quá 20 ký tự.")]
    public string? Phone { get; set; }

    [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
    [StringLength(100, ErrorMessage = "Email không vượt quá 100 ký tự.")]
    public string? Email { get; set; }

    [StringLength(250, ErrorMessage = "Địa chỉ không vượt quá 250 ký tự.")]
    public string? Address { get; set; }

    public bool IsActive { get; set; } = true;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation Properties
    public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
    public ICollection<GoodsReceiptModel> GoodsReceipts { get; set; } = new List<GoodsReceiptModel>();
}