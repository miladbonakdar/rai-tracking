using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Constants;
using SharedKernel.Exceptions;

namespace Persistence.Repositories
{
    class DepoRepository : Repository<Depo>, IDepoRepository
    {
        public DepoRepository(DbContext context, IIdentityProvider provider) : base(context
            , set =>
            {
                if (provider.HasValue && provider.IsAdmin &&
                    Constants.UserGroup.AllLimitedAdmins.Contains(provider.Role))
                    return set.Where(d => d.OrganizationId == provider.OrganizationId);
                return set;
            })
        {
        }

        public async Task GuardForDuplicateDepoName(string depoName, int? currentItemId = null)
        {
            var isAny = currentItemId is null
                ? await DbSet.AnyAsync(d => d.Name == depoName)
                : await DbSet.AnyAsync(d => d.Name == depoName && d.Id != currentItemId);
            if (isAny) throw new BadRequestException("Name", "نام دپو تکراریست");
        }
    }
}