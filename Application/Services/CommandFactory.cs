using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services.Contracts;
using Domain.Commands;
using Domain.ValueObjects;

namespace Application.Services
{
    class CommandFactory : ICommandFactory
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommandFactory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<NewMissionCommandRequest> CreateNewMissionCommand(int missionId)
        {
            var dataAdo = await _unitOfWork.Missions.GetMissionForNewProjectCommand(missionId);
            return new NewMissionCommandRequest(dataAdo.AgentNumber,
                dataAdo.AdminId, dataAdo.AgentId, dataAdo.MissionId, dataAdo.Description
                , dataAdo.RemainingTime, dataAdo.ProbableFailureZone);
        }

        public async Task<CancelProjectCommandRequest> CreateCancelMissionCommand(int missionId, int adminId)
        {
            var agent = await _unitOfWork.Missions.GetMissionAgent(missionId);
            return new CancelProjectCommandRequest(agent.PhoneNumber, adminId, agent.Id, missionId);
        }

        public async Task<FinishProjectCommandRequest> CreateFinishProjectCommand(int missionId, int adminId)
        {
            var agent = await _unitOfWork.Missions.GetMissionAgent(missionId);
            return new FinishProjectCommandRequest(agent.PhoneNumber, adminId, agent.Id, missionId);
        }

        public async Task<SetOtdrValueCommandRequest> CreateSetOtdrValueCommand(int missionId, int otdr, int adminId)
        {
            var agent = await _unitOfWork.Missions.GetMissionAgent(missionId);
            return new SetOtdrValueCommandRequest(agent.PhoneNumber, adminId, agent.Id, missionId, otdr);
        }

        public async Task<SetSettingCommandRequest> CreateSetSettingCommand(int agentId, AgentSetting setting,
            int adminId)
        {
            var agent = await _unitOfWork.Agents.FindOrThrowAsync(agentId);
            return new SetSettingCommandRequest(agent.PhoneNumber, adminId, agent.Id, setting);
        }

        public async Task<UpdateStatusCommandRequest> CreateUpdateStatusCommand(int agentId, int adminId)
        {
            var agent = await _unitOfWork.Agents.FindOrThrowAsync(agentId);
            return new UpdateStatusCommandRequest(agent.PhoneNumber, adminId, agent.Id);
        }

        public async Task<EditProjectCommandRequest> CreateEditMissionCommand(int missionId, int adminId)
        {
            var dataAdo = await _unitOfWork.Missions.GetMissionForEditProjectCommand(missionId);
            return new EditProjectCommandRequest(dataAdo.AgentNumber,
                adminId, dataAdo.AgentId, dataAdo.MissionId, dataAdo.Description
                , dataAdo.RemainingTime, dataAdo.ProbableFailureZone);
        }
    }
}