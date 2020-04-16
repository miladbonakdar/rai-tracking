using System;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace Application.DTO
{
    public class AgentDto : PersonDto
    {
        [Required] public string PhoneNumber { get; set; }

        [MinLength(8)] [Required] public string Password { get; set; }

        [Required] public int DepoId { get; set; }

        [Required] public string Email { get; set; }

        private static readonly Func<Agent, AgentDto> DefaultConverter = agent =>
            new AgentDto
            {
                Email = agent.Email,
                DepoId = agent.DepoId,
                PhoneNumber = agent.PhoneNumber,
                Name = agent.PersonName.Firstname,
                Lastname = agent.PersonName.Lastname,
                Id = agent.Id
            };

        public static AgentDto FromDomain(Agent agent, Func<Agent, AgentDto> converter = null)
        {
            if (converter is null) converter = DefaultConverter;
            return converter(agent);
        }
    }
}