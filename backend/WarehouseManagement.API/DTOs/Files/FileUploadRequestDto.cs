using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Files;

public class FileUploadRequestDto : IValidatableObject
{
    private const long MaxFileSize = 5 * 1024 * 1024; // 5MB
    private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".csv" };

    [Required(ErrorMessage = "Vui lòng chọn file để tải lên.")]
    public IFormFile File { get; set; } = null!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (File == null || File.Length == 0)
        {
            yield return new ValidationResult("File tải lên không được rỗng.", new[] { nameof(File) });
            yield break;
        }

        if (File.Length > MaxFileSize)
        {
            yield return new ValidationResult("Kích thước file không được vượt quá 5MB.", new[] { nameof(File) });
        }

        var ext = Path.GetExtension(File.FileName)?.ToLowerInvariant();
        if (string.IsNullOrEmpty(ext) || !AllowedExtensions.Contains(ext))
        {
            yield return new ValidationResult(
                $"Định dạng file không được hỗ trợ. Chỉ chấp nhận các định dạng: {string.Join(", ", AllowedExtensions)}",
                new[] { nameof(File) }
            );
        }
    }
}
