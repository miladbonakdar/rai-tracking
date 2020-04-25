using System.Threading.Tasks;
using Application.ADO;
using Application.DTO;
using Domain;

namespace Application.Interfaces
{
    public interface IMissionRepository : IRepository<Mission>
    {
        Task GuardForValidMission(MissionDto dto);
        Task<NewMissionCommandAdo> GetMissionForNewProjectCommand(int missionId);
    }
}