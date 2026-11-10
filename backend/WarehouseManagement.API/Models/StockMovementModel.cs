using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagement.API.Enums;

namespace WarehouseManagement.API.Models;

[Table("StockMovements")]
public class StockMovementModel
{
    public int Id { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int WarehouseId { get; set; }

    public int? LocationId { get; set; }

    [Required(ErrorMessage = "Loại biến động là bắt buộc.")]
    public StockMovementType MovementType { get; set; }

    [Required]
    // Quantity có thể âm (khi xuất) hoặc dương (khi nhập), không dùng Range(0, Max) ở đây
    public int Quantity { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Số lượng trước biến động phải >= 0.")]
    public int BeforeQuantity { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Số lượng sau biến động phải >= 0.")]
    public int AfterQuantity { get; set; }

    public int? ReferenceId { get; set; }

    [StringLength(50, ErrorMessage = "Loại tham chiếu không vượt quá 50 ký tự.")]
    public string? ReferenceType { get; set; } // Ví dụ: "GOODS_RECEIPT", "GOODS_ISSUE"

    [Required]
    [Range(1, int.MaxValue)]
    public int UserId { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public ProductModel Product { get; set; } = null!;
    public WarehouseModel Warehouse { get; set; } = null!;
    public WarehouseLocationModel? Location { get; set; }
    public UserModel User { get; set; } = null!;
}