using System.Threading.Tasks;
using Domain.Commands;

namespace Application.Services.Contracts
{
    public interface ICommandFactory
    {
        Task<NewMissionCommandRequest> CreateNewMissionCommand(int missionId);
        // Task<CancelProjectCommandRequest> CreateCancelProjectCommand(int missionId);
        // Task<EditProjectCommandRequest> CreateEditProjectCommand(int missionId);
        // Task<FinishProjectCommandRequest> CreateFinishProjectCommand(int missionId);
        // Task<SetOtdrValueCommandRequest> CreateSetOtdrValueCommand(int missionId);
        // Task<SetSettingCommandRequest> CreateSetSettingCommand(int missionId);
        // Task<UpdateStatusCommandRequest> CreateUpdateStatusCommand(int missionId);
    }
}