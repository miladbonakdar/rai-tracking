using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Persistence.Repositories
{
    class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(DbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}