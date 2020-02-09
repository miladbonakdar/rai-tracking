using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    class StationRepository : Repository<Station>, IStationRepository
    {
        public StationRepository(DbContext context) : base(context)
        {
        }
    }
}