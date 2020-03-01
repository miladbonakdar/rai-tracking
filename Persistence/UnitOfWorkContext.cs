using System;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;

namespace Persistence
{
    class UnitOfWorkContext : IUnitOfWorkContext
    {
        protected DbContext Context { get; }

        public IAgentRepository Agents => _agentsLazy.Value;
        public ICommandRepository Commands => _commandsLazy.Value;
        public IDepoRepository Depos => _deposLazy.Value;
        public IMissionRepository Missions => _missionsLazy.Value;
        public IOrganizationRepository Organizations => _organizationsLazy.Value;
        public IStationRepository Stations => _stationsLazy.Value;
        public IAdminRepository Admins => _adminsLazy.Value;

        private readonly Lazy<IAgentRepository> _agentsLazy;
        private readonly Lazy<ICommandRepository> _commandsLazy;
        private readonly Lazy<IDepoRepository> _deposLazy;
        private readonly Lazy<IMissionRepository> _missionsLazy;
        private readonly Lazy<IOrganizationRepository> _organizationsLazy;
        private readonly Lazy<IStationRepository> _stationsLazy;
        private readonly Lazy<IAdminRepository> _adminsLazy;

        public UnitOfWorkContext(DbContext context)
        {
            Context = context;
            _agentsLazy = new Lazy<IAgentRepository>(() => new AgentRepository(Context));
            _commandsLazy = new Lazy<ICommandRepository>(() => new CommandRepository(Context));
            _deposLazy = new Lazy<IDepoRepository>(() => new DepoRepository(Context));
            _missionsLazy = new Lazy<IMissionRepository>(() => new MissionRepository(Context));
            _organizationsLazy = new Lazy<IOrganizationRepository>(() => new OrganizationRepository(Context));
            _stationsLazy = new Lazy<IStationRepository>(() => new StationRepository(Context));
            _adminsLazy = new Lazy<IAdminRepository>(() => new AdminRepository(Context));
        }
    }
}