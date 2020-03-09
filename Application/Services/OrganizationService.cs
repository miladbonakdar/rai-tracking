using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Contracts;

namespace Application.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrganizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OrganizationDto>> GetAllOrganizationsListAsync()
        {
            var organs = await _unitOfWork.Organizations.GetAsync();
            return organs.Select(o => OrganizationDto.FromDomain(o)).ToList();
        }
    }
}