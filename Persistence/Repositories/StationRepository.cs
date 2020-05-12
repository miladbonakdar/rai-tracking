using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SharedKernel.Exceptions;

namespace Persistence.Repositories
{
    class StationRepository : Repository<Station>, IStationRepository
    {
        public StationRepository(DbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task GuardForDuplicateDepoName(string dtoName, int? currentItemId = null)
        {
            var isAny = currentItemId is null
                ? await DbSet.AnyAsync(d => d.Name == dtoName)
                : await DbSet.AnyAsync(d => d.Name == dtoName && d.Id != currentItemId);
            if (isAny) throw new BadRequestException("Name", "نام ایستگاه تکراریست");
        }

        public async Task<int> NextIdAsync()
        {
            var lastId = await DbSet.OrderByDescending(s => s.Id).Select(s => s.Id).FirstOrDefaultAsync();
            return lastId + 1;
        }

        public async Task DetachAndDelete(Station station)
        {
            var neighbors = await DbSet.Where(s => s.PostStationId == station.Id
                                                   || s.PreStationId == station.Id)
                .ToListAsync();
            foreach (var neighbor in neighbors)
            {
                if (neighbor.PreStationId == station.Id)
                    neighbor.DetachPreStation();
                
                if (neighbor.PostStationId == station.Id)
                    neighbor.DetachPostStation();
            }

            DbSet.Remove(station);
        }
    }
}