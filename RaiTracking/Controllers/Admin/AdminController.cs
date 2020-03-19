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
    public class AdminController : BaseAdminApiController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [NeedTest]
        [HttpPost]
        [Authorize(Roles = Constants.UserGroup.AllMainAdmins)]
        public async Task<Result<AdminDto>> Create([FromBody] AdminDto dto)
        {
            var admin = await _adminService.CreateAsync(dto);
            return Result<AdminDto>.Success(data: admin);
        }

        [NeedTest]
        [HttpPut]
        [Authorize(Roles = Constants.UserGroup.AllMainAdmins)]
        public async Task<Result<AdminDto>> Update([FromBody] AdminDto dto)
        {
            var admin = await _adminService.UpdateAsync(dto);
            return Result<AdminDto>.Success(data: admin);
        }

        [NeedTest]
        [HttpPatch(nameof(UpdatePassword))]
        public async Task<Result> UpdatePassword([FromBody] PasswordUpdateDto dto)
        {
            await _adminService.UpdatePasswordAsync(dto);
            return Result.Success();
        }

        [NeedTest]
        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.UserGroup.AllRootAdmins)]
        public async Task<Result> Delete(int id)
        {
            await _adminService.DeleteAsync(id);
            return Result.Success();
        }

        [NeedTest]
        [HttpGet("{id}")]
        public async Task<Result<AdminDto>> Get(int id)
        {
            var admin = await _adminService.GetAsync(id);
            return Result<AdminDto>.Success(data: admin);
        }

        [NeedTest]
        [HttpGet("{pageSize}/{pageNumber}")]
        public async Task<Result<PageDto<AdminDto>>> Get(int pageSize, int pageNumber)
        {
            var res = await _adminService.GetPageAsync(pageSize, pageNumber);
            return Result<PageDto<AdminDto>>.Success(data: res);
        }
    }
}