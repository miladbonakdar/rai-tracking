using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using SharedKernel.Constants;

namespace Application.DTO
{
    public class RegisterAdminDto : AdminDto
    {
        [Required]
        [RegularExpression(Constants.EmailRegex)]
        public string AdminEmailAddress { get; set; }

        [Required] public string RootPassword { get; set; }
        [Required] public string AdminType { get; set; }
        [Required] public int OrganizationId { get; set; }
    }
}