using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(DbContext context) : base(context)
        {
        }
    }
}