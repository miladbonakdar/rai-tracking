using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SharedKernel.Constants;

namespace RaiTracking.Controllers.Admin
{
    [Route(RouteBase)]
    public class DepoController : BaseAdminApiController
    {
        private readonly IDepoService _depoService;

        public DepoController(IDepoService depoService)
        {
            _depoService = depoService;
        }

        [WasFine]
        [HttpPost]
        [Authorize(Roles = Constants.UserGroup.AllMainAdmins)]
        public async Task<Result<DepoDto>> Create([FromBody] DepoDto dto)
        {
            var agent = await _depoService.CreateAsync(dto);
            return Result<DepoDto>.Success(data: agent);
        }

        [WasFine]
        [HttpPut]
        [Authorize(Roles = Constants.UserGroup.AllMainAdmins)]
        public async Task<Result<DepoDto>> Update([FromBody] DepoDto dto)
        {
            var agent = await _depoService.UpdateAsync(dto);
            return Result<DepoDto>.Success(data: agent);
        }

        [WasFine]
        [HttpPatch(nameof(UpdateLocation))]
        [Authorize(Roles = Constants.UserGroup.AllMainAdmins)]
        public async Task<Result> UpdateLocation([FromBody] LocationUpdateDto dto)
        {
            await _depoService.UpdateLocationAsync(dto);
            return Result.Success();
        }

        [WasFine]
        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.UserGroup.AllMainAdmins)]
        public async Task<Result> Delete(int id)
        {
            var res = await _depoService.DeleteAsync(id);
            return Result.Success();
        }

        [WasFine]
        [HttpGet("{id}")]
        public async Task<Result<DepoDto>> Get(int id)
        {
            var res = await _depoService.GetAsync(id);
            return Result<DepoDto>.Success(data: res);
        }

        [WasFine]
        [HttpGet("{pageSize}/{pageNumber}")]
        public async Task<Result<PageDto<DepoDto>>> Get(int pageSize, int pageNumber)
        {
            var res = await _depoService.GetPageAsync(pageSize, pageNumber);
            return Result<PageDto<DepoDto>>.Success(data: res);
        }

        /// <summary>
        /// get list of depos by organization id. send null to get all of them
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WasFine]
        [HttpGet("organization/{id?}")]
        public async Task<Result<IEnumerable<DepoDto>>> GetByOrganization(int? id)
        {
            var res = await _depoService.GetByOrganizationAsync(id);
            return Result<IEnumerable<DepoDto>>.Success(data: res);
        }
    }
}