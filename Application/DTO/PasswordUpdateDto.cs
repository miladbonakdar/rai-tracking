using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class PasswordUpdateDto
    {
        [Required] [MinLength(8)] public string NewPassword { get; set; }

        [Required] public string OldPassword { get; set; }

        [Required] public int DomainId { get; set; }
    }
}