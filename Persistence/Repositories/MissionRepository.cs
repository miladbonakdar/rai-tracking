using System.Linq;
using System.Threading.Tasks;
using Application.ADO;
using Application.DTO;
using Application.Interfaces;
using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SharedKernel;
using SharedKernel.Exceptions;

namespace Persistence.Repositories
{
    class MissionRepository : Repository<Mission>, IMissionRepository
    {
        public MissionRepository(DbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task GuardForValidMission(CreateMissionDto dto)
        {
            var mission = await DbSet.Where(m => m.Phase == MissionPhase.Started &&
                                                 m.AgentId == dto.AgentId).FirstOrDefaultAsync();
            if (mission != null) throw new ConflictedException("تعمیر کار در حال انجام عملیات دیگری می باشد.");
        }
        
        
        public async Task GuardForEditMission(int missionId)
        {
            var mission = await FindOrThrowAsync(missionId);
            if(mission.Phase == MissionPhase.Canceled || mission.Phase == MissionPhase.Finished)
                throw new ConflictedException("این عملیات به پایان رسیده است و امکان ویرایش برای آن ممکن نیست");
        }

        public async Task GuardForDeleteMission(int id)
        {
            var mission = await FindOrThrowAsync(id);
            if(mission.Phase == MissionPhase.Started)
                throw new ConflictedException("این عملیات در حال انجام است و امکان حذف آن ممکن نیست");
        }

        public async Task<Agent> GetMissionAgent(int missionId)
        {
            var mission = await DbSet.Include(m => m.Agent)
                .Where(m => m.Id == missionId).FirstOrDefaultAsync();
            if(mission is null) throw new NotFoundException(missionId.ToString());
            return mission.Agent;
        }

        public Task<NewMissionCommandAdo> GetMissionForNewProjectCommand(int missionId)
        {
            return DbSet.Where(m => m.Id == missionId && m.Phase == MissionPhase.NotStarted)
                .Select(m => new NewMissionCommandAdo
                {
                    Description = m.Description,
                    AdminId =EF.Property<int>(m,ShadowPropertyKeys.CreatedById),
                    AgentId = m.AgentId,
                    AgentNumber = m.Agent.PhoneNumber,
                    MissionId = m.Id,
                    RemainingTime = m.RemainingTime,
                    ProbableFailureZone = m.ProbableFailureZone,
                    StationOneId = m.StationOneId,
                    StationTwoId = m.StationTwoId
                }).FirstOrDefaultAsync();
        }
        
        public Task<EditMissionCommandAdo> GetMissionForEditProjectCommand(int missionId)
        {
            return DbSet.Where(m => m.Id == missionId && m.Phase == MissionPhase.NotStarted)
                .Select(m => new EditMissionCommandAdo
                {
                    Description = m.Description,
                    AdminId =EF.Property<int>(m,ShadowPropertyKeys.CreatedById),
                    AgentId = m.AgentId,
                    AgentNumber = m.Agent.PhoneNumber,
                    MissionId = m.Id,
                    RemainingTime = m.RemainingTime,
                    ProbableFailureZone = m.ProbableFailureZone,
                    StationOneId = m.StationOneId,
                    StationTwoId = m.StationTwoId
                }).FirstOrDefaultAsync();
        }
    }
}