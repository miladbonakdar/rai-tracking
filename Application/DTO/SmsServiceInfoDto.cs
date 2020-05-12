using System;

namespace Application.DTO
{
    public class SmsServiceInfoDto
    {
        public DateTime ExpireDate { get; set; }
        public string Type { get; set; }
        public long RemainingCredit { get; set; }
    }
}