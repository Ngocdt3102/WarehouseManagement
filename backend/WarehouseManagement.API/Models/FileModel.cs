using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.API.Models;

[Table("Files")]
public class FileModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên file gốc là bắt buộc.")]
    [StringLength(255, ErrorMessage = "Tên file không vượt quá 255 ký tự.")]
    // Chỉ cho phép các ký tự chữ, số, gạch ngang, gạch dưới, khoảng trắng và giới hạn định dạng an toàn
    [RegularExpression(@"^[\w\-. ]+\.(jpg|jpeg|png|gif|pdf|doc|docx|xls|xlsx|csv)$",
        ErrorMessage = "Chỉ hỗ trợ file ảnh (jpg, png, gif) hoặc tài liệu (pdf, word, excel, csv).")]
    public required string FileName { get; set; }

    [Required(ErrorMessage = "Kiểu MIME là bắt buộc.")]
    [StringLength(100, ErrorMessage = "Kiểu MIME không vượt quá 100 ký tự.")]
    // Validate MIME Type tương ứng với các đuôi file ở trên
    [RegularExpression(@"^(image\/(jpeg|png|gif)|application\/(pdf|msword|vnd\.openxmlformats-officedocument\..+|vnd\.ms-excel|csv))$",
        ErrorMessage = "Kiểu MIME không được hỗ trợ.")]
    public required string ContentType { get; set; }

    [Required(ErrorMessage = "Đường dẫn tải file là bắt buộc.")]
    [StringLength(500, ErrorMessage = "Đường dẫn tải file không vượt quá 500 ký tự.")]
    public string DownloadUrl { get; set; } = null!;

    [Required(ErrorMessage = "Nội dung file là bắt buộc.")]
    // Giới hạn độ dài mảng byte ở mức 5MB (5 * 1024 * 1024 = 5242880 bytes)
    [MaxLength(5242880, ErrorMessage = "Dung lượng file không được vượt quá 5MB.")]
    public required byte[] Content { get; set; }

    [Required]
    // Giới hạn giá trị Length đồng bộ với mảng byte (Tối đa 5MB)
    [Range(1, 5242880, ErrorMessage = "Kích thước file phải từ 1 byte đến 5MB.")]
    public long Length { get; set; }

    [Required]
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}
