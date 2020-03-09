using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Services.Contracts
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationDto>> GetAllOrganizationsListAsync();
    }
}