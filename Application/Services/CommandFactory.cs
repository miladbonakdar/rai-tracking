using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services.Contracts;
using Domain.Commands;

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
            return new NewMissionCommandRequest(dataAdo.AgentNumber,dataAdo.CreatedBy,
                dataAdo.AdminId,dataAdo.AgentId,dataAdo.MissionId,dataAdo.Description
                ,dataAdo.RemainingTime,dataAdo.ProbableFailureZone);
        }
    }
}