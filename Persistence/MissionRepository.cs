using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    class MissionRepository : Repository<Mission>, IMissionRepository
    {
        public MissionRepository(DbContext context) : base(context)
        {
        }
    }
}