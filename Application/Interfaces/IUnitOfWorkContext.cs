using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace Application.Interfaces
{
    public interface IUnitOfWorkContext
    {
        IAgentRepository Agents { get; }
        ICommandRepository Commands { get; }
        IDepoRepository Depos { get; }
        IMissionRepository Missions { get; }
        IOrganizationRepository Organizations { get; }
        IStationRepository Stations { get; }
        IAdminRepository Admins { get; }

        T GetProperty<T>(
            [NotNull] object entity,
            [NotNull] string propertyName);
    }
}
