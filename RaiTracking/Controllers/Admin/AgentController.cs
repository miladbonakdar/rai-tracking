using System;
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
    public class AgentController : BaseAdminApiController
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [WasFine]
        [HttpPost]
        [Authorize(Roles = PermissionSet.Agent.Create)]
        public async Task<Result<AgentDto>> Create([FromBody] AgentDto dto)
        {
            var agent = await _agentService.CreateAsync(dto);
            return Result<AgentDto>.Success(data: agent);
        }

        [WasFine]
        [HttpPut]
        [Authorize(Roles = PermissionSet.Agent.Update)]
        public async Task<Result<AgentDto>> Update([FromBody] AgentDto dto)
        {
            var agent = await _agentService.UpdateAsync(dto);
            return Result<AgentDto>.Success(data: agent);
        }
 
        [WasFine]
        [HttpPatch(nameof(ResetPassword))]
        [Authorize(Roles = PermissionSet.Agent.ResetPassword)]
        public async Task<Result> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            await _agentService.ResetPasswordAsync(dto);
            return Result.Success();
        }
        
        [WasFine]
        [HttpPatch(nameof(UpdateSetting))]
        [Authorize(Roles = PermissionSet.Agent.UpdateSetting)]
        public async Task<Result> UpdateSetting([FromBody] UpdateAgentSettingDto dto)
        {
            await _agentService.UpdateSettingAsync(dto);
            return Result.Success();
        }

        [WasFine]
        [HttpDelete("{id}")]
        [Authorize(Roles = PermissionSet.Agent.Delete)]
        public async Task<Result> Delete(int id)
        {
            var res = await _agentService.DeleteAsync(id);
            return Result.Success();
        }

        [WasFine]
        [HttpGet("{id}")]
        public async Task<Result<AgentDto>> Get(int id)
        {
            var res = await _agentService.GetAsync(id);
            return Result<AgentDto>.Success(data: res);
        }

        [WasFine]
        [HttpGet("{pageSize}/{pageNumber}")]
        public async Task<Result<PageDto<AgentDto>>> Get(int pageSize, int pageNumber)
        {
            var res = await _agentService.GetPageAsync(pageSize, pageNumber);
            return Result<PageDto<AgentDto>>.Success(data: res);
        }
        
        [NeedTest]
        [HttpGet("update-status-request/{id}")]
        public async Task<Result> UpdateStatusRequest(int id)
        {
            await _agentService.SendUpdateStatusCommand(id);
            return Result.Success(data: true);
        }
    }
}