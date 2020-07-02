using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Contracts;
using Domain;
using SharedKernel.Exceptions;

namespace Application.Services
{
    class MissionService : IMissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommander _commander;
        private readonly IIdentityProvider _identityProvider;
        private readonly ICommandFactory _commandFactory;

        public MissionService(IUnitOfWork unitOfWork, ICommander commander, IIdentityProvider identityProvider,
            ICommandFactory commandFactory)
        {
            _unitOfWork = unitOfWork;
            _commander = commander;
            _identityProvider = identityProvider;
            _commandFactory = commandFactory;
        }

        public async Task<MissionDto> CreateAsync(CreateMissionDto dto)
        {
            await _unitOfWork.Missions.GuardForValidMission(dto);
            var mission = new Mission(dto.AgentId, dto.RemainingTime, dto.StationOneId
                , dto.Zone.ToDomain(), dto.Description, dto.StationTwoId);
            await _unitOfWork.CompleteAsync(ctx => ctx.Missions.AddAsync(mission));
            var missionDto = dto.ToMissionDto(mission.Id);
            var command = await _commandFactory.CreateNewMissionCommand(missionDto.Id);
            await _commander.SendAsync(command);
            return missionDto;
        }

        public async Task<UpdateMissionDto> UpdateAsync(UpdateMissionDto dto)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<MissionDto> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PageDto<MissionListDto>> GetPageAsync(int pageSize, int pageNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task SetOtdr(int id, int otdr)
        {
            throw new System.NotImplementedException();
        }

        public async Task StartMission(int missionId)
        {
            throw new System.NotImplementedException();
        }

        public async Task StopMission(int missionId)
        {
            throw new System.NotImplementedException();
        }

        public async Task CancelMission(int missionId)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateFailureLocation(int missionId, LocationDto dto)
        {
            throw new System.NotImplementedException();
        }


        private async Task<Mission> Get(int id) =>
            await _unitOfWork.Missions.SingleOrDefaultAsync(a => a.Id == id)
            ?? throw new NotFoundException(id.ToString());

        private static string GetCacheKey(int id) => $"Mission_{id}";
    }
}