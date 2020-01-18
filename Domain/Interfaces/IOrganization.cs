using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IOrganizationTenant
    {
        Guid OrganizationId { set; get; }
        Organization Organization { set; get; }
    }
    public interface IMission
    {
        Guid MissionId { set; get; }
        Mission Mission { set; get; }
    }
}
