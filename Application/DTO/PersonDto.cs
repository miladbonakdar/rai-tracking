using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public abstract class PersonDto : IModelDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }

        public Guid Id { get; set; }
        AuthenticatedClientDto Authenticated(string token)
            => new AuthenticatedClientDto(this, token);

        [MinLength(8)]
        [Required]
        public string Password { get; set; }
    }
}