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
    public class MissionController: BaseAdminApiController
    {
        private readonly IMissionService _missionService;

        public MissionController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        [NeedTest]
        [HttpPost]
        [Authorize(Roles = PermissionSet.Mission.Create)]
        public async Task<Result<MissionDto>> Create([FromBody] CreateMissionDto dto)
        {
            var mission = await _missionService.CreateAsync(dto);
            return Result<MissionDto>.Success(data: mission);
        }

        [NeedTest]
        [HttpPut]
        [Authorize(Roles = PermissionSet.Mission.Update)]
        public async Task<Result<UpdateMissionDto>> Update([FromBody] UpdateMissionDto dto)
        {
            var mission = await _missionService.UpdateAsync(dto);
            return Result<UpdateMissionDto>.Success(data: mission);
        }

        [NeedTest]
        [HttpDelete("{id}")]
        [Authorize(Roles = PermissionSet.Mission.Delete)]
        public async Task<Result> Delete(int id)
        {
            await _missionService.DeleteAsync(id);
            return Result.Success();
        }

        [NeedTest]
        [HttpGet("{id}")]
        public async Task<Result<MissionDto>> Get(int id)
        {
            var res = await _missionService.GetAsync(id);
            return Result<MissionDto>.Success(data: res);
        }

        [NeedTest]
        [HttpGet("{pageSize}/{pageNumber}")]
        public async Task<Result<PageDto<MissionListDto>>> Get(int pageSize, int pageNumber)
        {
            var res = await _missionService.GetPageAsync(pageSize, pageNumber);
            return Result<PageDto<MissionListDto>>.Success(data: res);
        }
    }
}