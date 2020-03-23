using System.ComponentModel.DataAnnotations;
using SharedKernel.Constants;

namespace Application.DTO
{
    public class AdminProfileDto
    {
        public AdminDto Admin { get; set; }

        public int MissionsCount { get; set; }
        
    }
}