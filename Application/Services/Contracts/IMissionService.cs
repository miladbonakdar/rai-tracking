using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Enums;

namespace Application.Services.Contracts
{
    public interface IMissionService
    {
        Task<UpdateMissionDto> UpdateAsync(UpdateMissionDto dto);
        Task<MissionDto> CreateAsync(MissionDto dto);
        Task DeleteAsync(int id);
        Task<MissionDto> GetAsync(int id);
        Task<PageDto<MissionListDto>> GetPageAsync(int pageSize, int pageNumber);
        Task SetOtdr(int id, int otdr);
        Task StartMission(int missionId);
        Task StopMission(int missionId);
        Task CancelMission(int missionId);
        Task UpdateFailureLocation(int missionId, LocationDto dto);
    }
}