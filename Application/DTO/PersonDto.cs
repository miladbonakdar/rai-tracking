using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public abstract class PersonDto : IModelDto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Lastname { get; set; }

        public int Id { get; set; }
        AuthenticatedClientDto Authenticate(string token)
            => new AuthenticatedClientDto(this, token);
    }
}