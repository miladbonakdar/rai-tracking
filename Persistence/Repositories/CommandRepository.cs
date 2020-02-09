using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    class CommandRepository : Repository<Command>, ICommandRepository
    {
        public CommandRepository(DbContext context) : base(context)
        {
        }
    }
}