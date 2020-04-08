using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Persistence.Repositories
{
    class MissionRepository : Repository<Mission>, IMissionRepository
    {
        public MissionRepository(DbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}