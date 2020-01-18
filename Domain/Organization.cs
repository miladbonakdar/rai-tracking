using Domain.ValueObjects;
using SharedKernel;

namespace Domain
{
    public class Organization : AggregateRoot
    {
        public string IsAdmin { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Code { get; set; }
    }
}