using System.ComponentModel.DataAnnotations;
using Domain.ValueObjects;
using JetBrains.Annotations;
using SharedKernel;

namespace Domain
{
    public class Organization : AggregateRoot
    {
        public Organization([NotNull] string name, [NotNull] string code, bool isAdmin = false)
        {
            Name = name;
            IsAdmin = isAdmin;
            Code = code;
        }

        public Organization(int id, [NotNull] string name, [NotNull] string code, bool isAdmin = false)
            : this(name, code, isAdmin)
        {
            Id = id;
        }

        private Organization()
        {
        }

        public bool IsAdmin { get; private set; }
        [Required] [MaxLength(150)] public string Name { get; private set; }
        public Location Location { get; set; }
        [Required] public string Code { get; private set; }
    }
}