using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    class MissionRepository : Repository<Mission>, IMissionRepository
    {
        public MissionRepository(DbContext context) : base(context)
        {
        }
    }
}