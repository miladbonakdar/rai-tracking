using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    class UnitOfWorkContext : IUnitOfWorkContext
    {
        protected DbContext Context { get; }
        public IAgentRepository Agents { get; }
        public ICommandRepository Commands { get; }
        public IDepoRepository Depos { get; }
        public IMissionRepository Missions { get; }
        public IOrganizationRepository Organizations { get; }
        public IStationRepository Stations { get; }
        public IUserRepository Users { get; }

        public UnitOfWorkContext(DbContext context)
        {
            Context = context;
            Agents = new AgentRepository(Context);
            Commands = new CommandRepository(Context);
            Depos = new DepoRepository(Context);
            Missions = new MissionRepository(Context);
            Organizations = new OrganizationRepository(Context);
            Stations = new StationRepository(Context);
            Users = new UserRepository(Context);
        }
    }
}