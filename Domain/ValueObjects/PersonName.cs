using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SharedKernel;
using SharedKernel.Exceptions;

namespace Domain.ValueObjects
{
    public class PersonName : ValueObject<PersonName>
    {
        public PersonName(string firstname, string lastname)
        {
            Firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
            Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
        }

        private PersonName()
        {
        }

        [MaxLength(200)] public string Firstname { get; private set; }
        [MaxLength(200)] public string Lastname { get; private set; }
        [NotMapped] public string Fullname => $"{Firstname} {Lastname}";

        public override void UpdateFrom(PersonName item)
        {
            Firstname = item.Firstname;
            Lastname = item.Lastname;
        }

        public override bool IsEmpty()
        {
            return (Firstname == "" && Lastname == "");
        }
    }
}