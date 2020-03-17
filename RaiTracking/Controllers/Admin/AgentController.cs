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
    public class AgentController : BaseAdminApiController
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [NeedTest]
        [HttpPost]
        [Authorize(Roles = Constants.UserGroup.AllRootAdmins)]
        public async Task<Result<AgentDto>> Create([FromBody] AgentDto dto)
        {
            var agent = await _agentService.CreateAsync(dto);
            return Result<AgentDto>.Success(data: agent);
        }

        [NeedTest]
        [HttpPut]
        [Authorize(Roles = Constants.UserGroup.AllRootAdmins)]
        public async Task<Result<AgentDto>> Update([FromBody] AgentDto dto)
        {
            var agent = await _agentService.UpdateAsync(dto);
            return Result<AgentDto>.Success(data: agent);
        }

        [NeedTest]
        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.UserGroup.AllRootAdmins)]
        public async Task<Result> Delete(int id)
        {
            var res = await _agentService.DeleteAsync(id);
            return Result.Success();
        }

        [NeedTest]
        [HttpGet("{id}")]
        public async Task<Result<AgentDto>> Get(int id)
        {
            var res = await _agentService.GetAsync(id);
            return Result<AgentDto>.Success(data: res);
        }

        [NeedTest]
        [HttpGet("{pageSize}/{pageNumber}")]
        public async Task<Result<PageDto<AgentDto>>> Get(int pageSize, int pageNumber)
        {
            var res = await _agentService.GetPageAsync(pageSize, pageNumber);
            return Result<PageDto<AgentDto>>.Success(data: res);
        }
    }
}