using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace RaiTracking.Controllers.Public
{
    [Authorize]
    [Route("Public/v1/[controller]")]
    public class OrganizationController : BaseApiController
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }
        
        [WasFine]
        [AllowAnonymous]
        [HttpGet(nameof(Organizations))]
        public async Task<Result<IEnumerable<OrganizationDto>>> Organizations()
        {
            var organDtos = await _organizationService.GetAllOrganizationsListAsync();
            return Result<IEnumerable<OrganizationDto>>.Success(data: organDtos);
        }
    }
}