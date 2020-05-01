using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SharedKernel.Constants;

namespace RaiTracking.Controllers.Admin
{
    [Route(RouteBase)]
    public class StationController : BaseAdminApiController
    {
        private readonly IStationService _stationService;

        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [WasFine]
        [HttpPost]
        [Authorize(Roles = PermissionSet.Station.Create)]
        public async Task<Result<StationDto>> Create([FromBody] StationDto dto)
        {
            var item = await _stationService.CreateAsync(dto);
            return Result<StationDto>.Success(data: item);
        }

        [WasFine]
        [HttpPut]
        [Authorize(Roles = PermissionSet.Station.Update)]
        public async Task<Result<StationDto>> Update([FromBody] StationDto dto)
        {
            var item = await _stationService.UpdateAsync(dto);
            return Result<StationDto>.Success(data: item);
        }

        [WasFine]
        [HttpDelete("{id}")]
        [Authorize(Roles = PermissionSet.Station.Delete)]
        public async Task<Result> Delete(int id)
        {
             await _stationService.DeleteAsync(id);
            return Result.Success();
        }

        [WasFine]
        [HttpGet("{id}")]
        public async Task<Result<StationDto>> Get(int id)
        {
            var res = await _stationService.GetAsync(id);
            return Result<StationDto>.Success(data: res);
        }

        [WasFine]
        [HttpGet("{pageSize}/{pageNumber}")]
        public async Task<Result<PageDto<StationDto>>> Get(int pageSize, int pageNumber)
        {
            var res = await _stationService.GetPageAsync(pageSize, pageNumber);
            return Result<PageDto<StationDto>>.Success(data: res);
        }

        [WasFine]
        [HttpGet("by_organization/{id}")]
        public async Task<Result<IEnumerable<StationDto>>> GetByOrganization(int id)
        {
            var res = await _stationService.GetByOrganizationAsync(id);
            return Result<IEnumerable<StationDto>>.Success(data: res);
        }
        
        [WasFine]
        [HttpGet("by_station/{id}")]
        public async Task<Result<IEnumerable<StationDto>>> GetByStation(int id)
        {
            var res = await _stationService.GetNeighboursByStation(id);
            return Result<IEnumerable<StationDto>>.Success(data: res);
        }
    }
}