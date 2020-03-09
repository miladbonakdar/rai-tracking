using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using SharedKernel.Constants;

namespace Application.DTO
{
    public sealed class SignInDto
    {
        public string EmailOrPhoneNumber { get; set; }
        public string Password { set; get; }
        [NotMapped] public bool IsEmailAddress => Regex.IsMatch(EmailOrPhoneNumber, Constants.EmailRegex);
    }
}