using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Contracts;
using Domain;
using Domain.Enums;
using SharedKernel;
using SharedKernel.Exceptions;

namespace Application.Services
{
    class MissionService : IMissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommander _commander;
        private readonly ICommandFactory _commandFactory;
        private readonly IIdentityProvider _identityProvider;

        public MissionService(IUnitOfWork unitOfWork, ICommander commander,
            ICommandFactory commandFactory, IIdentityProvider identityProvider)
        {
            _unitOfWork = unitOfWork;
            _commander = commander;
            _commandFactory = commandFactory;
            _identityProvider = identityProvider;
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

        public async Task<MissionDto> UpdateAsync(UpdateMissionDto dto)
        {
            await _unitOfWork.Missions.GuardForEditMission(dto.Id);
            var mission = await _unitOfWork.Missions.SingleAsync(m => m.Id == dto.Id);
            var missionDto = dto.ToMissionDto(mission.Id, mission.AgentId, mission.Phase);
            var command = await _commandFactory.CreateEditMissionCommand(missionDto.Id,_identityProvider.Id);
            await _commander.SendAsync(command);
            return missionDto;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Missions.GuardForDeleteMission(id);
            await _unitOfWork.CompleteAsync(ctx =>
            {
                var m = ctx.Missions.Find(id);
                ctx.Missions.Remove(m);
            });
        }

        public async Task<MissionDto> GetAsync(int id)
        {
            var m = await _unitOfWork.Missions.FindOrThrowAsync(id);
            return MissionDto.FromDomain(m);
        }

        public async Task<PageDto<MissionListDto>> GetPageAsync(int pageSize, int pageNumber)
        {
            var page = new PageDto<MissionListDto>(pageSize, pageNumber);
            var items = await _unitOfWork.Missions.GetPageAndSelectAsync(pageSize, pageNumber,
                m => new MissionListDto
                {
                    Admin = _unitOfWork.GetProperty<string>(m, ShadowPropertyKeys.CreatedBy),
                    Agent = m.Agent.PersonName.Firstname + " " + m.Agent.PersonName.Firstname,
                    Description = m.Description,
                    Id = m.Id,
                    Phase = m.Phase,
                    FinishedAt = m.FinishedAt,
                    RemainingTime = m.RemainingTime,
                    StartedAt = m.StartedAt,
                    StationOne = m.StationOne.Name,
                    StationTwo = m.StationTwo.Name,
                    OTDR = m.OTDR
                });
            page.SetData(items.Item2, items.Item1);
            return page;
        }

        public async Task SetOtdr(int id, int otdr)
        {
            var mission = await _unitOfWork.Missions.FindOrThrowAsync(id);
            if (mission.Phase == MissionPhase.Canceled)
                throw new ConflictedException("این عملیات لغو شده است و امکان تغییر آن ممکن نیست");
            mission.UpdateOtdr(otdr);
            await _unitOfWork.CompleteAsync();
        }

        public async Task StartMission(int missionId)
        {
            var mission = await _unitOfWork.Missions.FindOrThrowAsync(missionId);
            if (mission.Phase == MissionPhase.Started) return;
            if (mission.Phase != MissionPhase.NotStarted)
                throw new ConflictedException(
                    "در این حالت امکان شروع عملیات وجود ندارد. لطفا وضعیت عملیات را بررسی کنید");
            mission.Start();
            await _unitOfWork.CompleteAsync();
        }

        public async Task StopMission(int missionId)
        {
            var mission = await _unitOfWork.Missions.FindOrThrowAsync(missionId);
            if (mission.Phase == MissionPhase.Finished) return;
            if (mission.Phase != MissionPhase.Started || mission.Phase != MissionPhase.NotStarted)
                throw new ConflictedException(
                    "در این حالت امکان خاتمه دادن به عملیات وجود ندارد. لطفا وضعیت عملیات را بررسی کنید");
            mission.Finish();
            await _unitOfWork.CompleteAsync();
        }

        public async Task CancelMission(int missionId)
        {
            var mission = await _unitOfWork.Missions.FindOrThrowAsync(missionId);
            if(mission.Phase == MissionPhase.Canceled) return;
            if (mission.Phase != MissionPhase.Finished)
                throw new ConflictedException(
                    "در این حالت امکان لغو عملیات وجود ندارد. لطفا وضعیت عملیات را بررسی کنید");
            mission.Cancel();
            await _unitOfWork.CompleteAsync();
        }

        public async Task SendCancelCommand(int missionId)
        {
            var command = await _commandFactory.CreateCancelMissionCommand(missionId,_identityProvider.Id);
            await _commander.SendAsync(command);
        }

        public async Task SendFinishCommand(int missionId)
        {            
            var command = await _commandFactory.CreateFinishProjectCommand(missionId,_identityProvider.Id);
            await _commander.SendAsync(command);
        }

        public async Task SendSetOtdrCommand(int missionId,int otdr)
        {
            var command = await _commandFactory.CreateSetOtdrValueCommand(missionId,otdr,_identityProvider.Id);
            await _commander.SendAsync(command);
        }

        public async Task UpdateFailureLocation(int missionId, LocationDto dto)
        {
            var mission = await _unitOfWork.Missions.FindOrThrowAsync(missionId);
            mission.UpdateFailureLocation(dto.ToDomain());
        }
    }
}