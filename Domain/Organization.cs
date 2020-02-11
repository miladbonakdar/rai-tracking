using System.ComponentModel.DataAnnotations;
using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class Organization : AggregateRoot
    {
        public bool IsAdmin { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public Location Location { get; set; }
        [Required]
        public string Code { get; set; }
    }
}