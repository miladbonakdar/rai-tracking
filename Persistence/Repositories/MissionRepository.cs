using System;
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
            if (mission != null) throw new ApplicationException("تعمیر کار در حال انجام عملیات دیگری می باشد.");
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
                    CreatedBy = EF.Property<string>(m,ShadowPropertyKeys.CreatedBy),
                    MissionId = m.Id,
                    RemainingTime = m.RemainingTime,
                    ProbableFailureZone = m.ProbableFailureZone,
                    StationOneId = m.StationOneId,
                    StationTwoId = m.StationTwoId
                }).FirstOrDefaultAsync();
        }
    }
}