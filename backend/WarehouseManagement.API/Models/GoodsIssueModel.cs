using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagement.API.Enums;

namespace WarehouseManagement.API.Models;

[Table("GoodsIssues")]
public class GoodsIssueModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    [RegularExpression(@"^GI-[A-Z0-9]+$", ErrorMessage = "Mã phiếu xuất phải có tiền tố GI- và không chứa khoảng trắng.")]
    public string IssueCode { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ID Khách hàng không hợp lệ.")]
    public int CustomerId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ID Kho không hợp lệ.")]
    public int WarehouseId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ID Nhân viên không hợp lệ.")]
    public int EmployeeId { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public GoodsIssueStatus Status { get; set; } = GoodsIssueStatus.PENDING;

    [StringLength(500)]
    public string? Remarks { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation Properties
    public CustomerModel Customer { get; set; } = null!;
    public WarehouseModel Warehouse { get; set; } = null!;
    public UserModel Employee { get; set; } = null!;
    public ICollection<GoodsIssueDetailModel> Details { get; set; } = new List<GoodsIssueDetailModel>();
}