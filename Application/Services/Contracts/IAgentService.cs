using System.Threading.Tasks;
using Application.DTO;

namespace Application.Services.Contracts
{
    public interface IAgentService
    {
        Task<AgentDto> CreateAsync(AgentDto dto);
        Task<AgentDto> GetAsync(int id);
        Task<AgentDto> DeleteAsync(int id);
        Task<PageDto<AgentDto>> GetPageAsync(int pageSize, int pageNumber);
        Task<AgentDto> UpdateAsync(AgentDto dto);
        Task ResetPasswordAsync(ResetPasswordDto dto);
        Task UpdateSettingAsync(UpdateAgentSettingDto dto);
    }
}