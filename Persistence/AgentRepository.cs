using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    class AgentRepository : Repository<Agent>, IAgentRepository
    {
        public AgentRepository(DbContext context) : base(context)
        {
        }
    }
}