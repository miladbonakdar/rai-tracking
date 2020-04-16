using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Persistence.Repositories
{
    class CommandRepository : Repository<Command>, ICommandRepository
    {
        public CommandRepository(DbContext context,ILogger logger) : base(context,logger)
        {
        }
    }
}