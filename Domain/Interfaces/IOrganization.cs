using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IOrganizationTenant
    {
        int OrganizationId { set; get; }
        Organization Organization { set; get; }
    }
}
