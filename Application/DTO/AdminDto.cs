using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class AdminDto : PersonDto
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Number { get; set; }
    }
}
