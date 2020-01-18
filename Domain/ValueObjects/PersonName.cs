using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SharedKernel;

namespace Domain.ValueObjects
{
    public class PersonName : ValueObject<PersonName>
    {
        public PersonName(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        private PersonName()
        {
            
        }

        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        [NotMapped] public string Fullname => $"{Firstname} {Lastname}";
        public override bool IsEmpty()
        {
            return (Firstname == "" && Lastname == "");
        }
    }
}
