using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SharedKernel.Constants;

namespace Application.DTO
{
    public class AdminDto : PersonDto
    {

        [MinLength(8)]
        [Required]
        public string Password { get; set; }
        
        [Required]
        [RegularExpression(Constants.EmailRegex)]
        public string Email { get; set; }
        [MaxLength(13)]
        public string PhoneNumber { get; set; }
        [MaxLength(13)]
        public string Number { get; set; }
    }
}
