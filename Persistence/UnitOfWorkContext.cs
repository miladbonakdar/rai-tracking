using System;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Serilog;

namespace Persistence
{
    class UnitOfWorkContext : IUnitOfWorkContext
    {
        protected DbContext Context { get; }
        protected readonly IIdentityProvider IdentityProvider;

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

        public UnitOfWorkContext(DbContext context, IIdentityProvider identityProvider, ILogger logger)
        {
            Context = context;
            IdentityProvider = identityProvider;
            _agentsLazy = new Lazy<IAgentRepository>
                (() => new AgentRepository(Context, logger));
            
            _commandsLazy = new Lazy<ICommandRepository>(
                () => new CommandRepository(Context, logger));
            
            _deposLazy = new Lazy<IDepoRepository>(
                () => new DepoRepository(Context, logger, IdentityProvider));
            
            _missionsLazy = new Lazy<IMissionRepository>(
                () => new MissionRepository(Context, logger));
            
            _organizationsLazy = new Lazy<IOrganizationRepository>(
                () => new OrganizationRepository(Context, logger));
            
            _stationsLazy = new Lazy<IStationRepository>(
                () => new StationRepository(Context, logger));
            
            _adminsLazy = new Lazy<IAdminRepository>(
                () => new AdminRepository(Context, logger));
        }
    }
}