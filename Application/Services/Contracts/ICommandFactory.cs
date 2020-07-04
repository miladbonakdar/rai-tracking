using System.Threading.Tasks;
using Domain.Commands;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services.Contracts
{
    public interface ICommandFactory
    {
        Task<NewMissionCommandRequest> CreateNewMissionCommand(int missionId);
        Task<CancelProjectCommandRequest> CreateCancelMissionCommand(int missionId,int adminId);
        Task<FinishProjectCommandRequest> CreateFinishProjectCommand(int missionId,int adminId);
        Task<SetOtdrValueCommandRequest> CreateSetOtdrValueCommand(int missionId,int otdr,int adminId);
        Task<SetSettingCommandRequest> CreateSetSettingCommand(int agentId,AgentSetting setting,int adminId);
        Task<UpdateStatusCommandRequest> CreateUpdateStatusCommand(int agentId,int adminId);
        Task<EditProjectCommandRequest> CreateEditMissionCommand(int missionId,int adminId);
    }
}