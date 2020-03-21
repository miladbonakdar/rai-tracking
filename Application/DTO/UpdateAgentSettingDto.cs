using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class UpdateAgentSettingDto
    {
        [Required] public int AgentId { get; set; }
        [Required] public int Version { get; set; }
    }
}