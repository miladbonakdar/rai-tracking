using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class ResetPasswordDto
    {
        [Required]
        public string Password { get; set; }
        
        [Required]
        public int DomainId { get; set; }
    }
}