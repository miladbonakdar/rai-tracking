using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    class AgentRepository : Repository<Agent>, IAgentRepository
    {
        public AgentRepository(DbContext context) : base(context)
        {
        }

        public Task<Agent> GetWithDepoAsync(Expression<Func<Agent, bool>> predicate)
        {
            return DbSet.Include(a => a.Depo).FirstOrDefaultAsync(predicate);
        }
    }
}