using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class AgentDto : PersonDto
    {
        [Required]
        public string PhoneNumber { get; set; }

        [MinLength(8)]
        [Required]
        public string Password { get; set; }
    }
}