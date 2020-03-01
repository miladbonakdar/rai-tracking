using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IOrganizationTenant
    {
        int OrganizationId { get; }
        Organization Organization { get; }
    }
}