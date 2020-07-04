using System.Threading.Tasks;
using Application.ADO;
using Application.DTO;
using Domain;

namespace Application.Interfaces
{
    public interface IMissionRepository : IRepository<Mission>
    {
        Task GuardForValidMission(CreateMissionDto dto);
        Task<NewMissionCommandAdo> GetMissionForNewProjectCommand(int missionId);
        Task<EditMissionCommandAdo> GetMissionForEditProjectCommand(int missionId);

        Task GuardForEditMission(int missionId);
        Task GuardForDeleteMission(int id);
        Task<Agent> GetMissionAgent(int missionId);
    }
}