using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagement.API.Enums;

namespace WarehouseManagement.API.Models;

[Table("GoodsReceipts")]
public class GoodsReceiptModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Mã phiếu nhập là bắt buộc.")]
    [StringLength(50, MinimumLength = 3)]
    [RegularExpression(@"^GR-[A-Z0-9]+$", ErrorMessage = "Mã phiếu nhập phải có tiền tố GR- và không chứa khoảng trắng.")]
    public string ReceiptCode { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ID Nhà cung cấp không hợp lệ.")]
    public int SupplierId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ID Kho không hợp lệ.")]
    public int WarehouseId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ID Nhân viên không hợp lệ.")]
    public int EmployeeId { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public GoodsReceiptStatus Status { get; set; } = GoodsReceiptStatus.PENDING;

    [StringLength(500)]
    public string? Remarks { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation Properties
    public SupplierModel Supplier { get; set; } = null!;
    public WarehouseModel Warehouse { get; set; } = null!;
    public UserModel Employee { get; set; } = null!;
    public ICollection<GoodsReceiptDetailModel> Details { get; set; } = new List<GoodsReceiptDetailModel>();
}