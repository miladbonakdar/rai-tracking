using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Contracts;
using SharedKernel.Constants;

namespace Application.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheStore _cacheStore;

        public OrganizationService(IUnitOfWork unitOfWork, ICacheStore cacheStore)
        {
            _unitOfWork = unitOfWork;
            _cacheStore = cacheStore;
        }

        public async Task<IEnumerable<OrganizationDto>> GetAllOrganizationsListAsync()
        {
            var organDtos = await _cacheStore.StoreAndGetAsync(CacheKeys.AllOrganizationsList
                , async () =>
                {
                    var organs = await _unitOfWork.Organizations.GetAsync();
                    return organs.Select(o => OrganizationDto.FromDomain(o)).ToList();
                });

            return organDtos;
        }
    }
}