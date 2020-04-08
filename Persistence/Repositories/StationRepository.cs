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
    }
}