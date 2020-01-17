using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    class CommandRepository : Repository<Command>, ICommandRepository
    {
        public CommandRepository(DbContext context) : base(context)
        {
        }
    }
}