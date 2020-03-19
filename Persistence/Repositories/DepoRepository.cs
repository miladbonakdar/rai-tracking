using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Exceptions;

namespace Persistence.Repositories
{
    class DepoRepository : Repository<Depo>, IDepoRepository
    {
        public DepoRepository(DbContext context) : base(context)
        {
        }

        public async Task GuardForDuplicateDepoName(string depoName)
        {
            var isAny = await DbSet.AnyAsync(d => d.Name == depoName);
            if (isAny) throw new BadRequestException("Name", "نام دپو نکراریست");
        }
    }
}