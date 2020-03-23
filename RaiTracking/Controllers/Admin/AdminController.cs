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

        [WasFine]
        [HttpPost]
        [Authorize(Roles = Constants.UserGroup.AllRootAdmins)]
        public async Task<Result<AdminDto>> Create([FromBody] AdminDto dto)
        {
            var admin = await _adminService.CreateAsync(dto);
            return Result<AdminDto>.Success(data: admin);
        }

        [WasFine]
        [HttpPut]
        [Authorize(Roles = Constants.UserGroup.AllRootAdmins)]
        public async Task<Result<AdminDto>> Update([FromBody] AdminDto dto)
        {
            var admin = await _adminService.UpdateAsync(dto);
            return Result<AdminDto>.Success(data: admin);
        }

        [WasFine]
        [HttpPatch(nameof(UpdatePassword))]
        public async Task<Result> UpdatePassword([FromBody] PasswordUpdateDto dto)
        {
            await _adminService.UpdatePasswordAsync(dto);
            return Result.Success();
        }

        [WasFine]
        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.UserGroup.AllRootAdmins)]
        public async Task<Result> Delete(int id)
        {
            await _adminService.DeleteAsync(id);
            return Result.Success();
        }

        [WasFine]
        [HttpGet("{id}")]
        public async Task<Result<AdminDto>> Get(int id)
        {
            var admin = await _adminService.GetAsync(id);
            return Result<AdminDto>.Success(data: admin);
        }

        [WasFine]
        [HttpGet("{pageSize}/{pageNumber}")]
        public async Task<Result<PageDto<AdminDto>>> Get(int pageSize, int pageNumber)
        {
            var res = await _adminService.GetPageAsync(pageSize, pageNumber);
            return Result<PageDto<AdminDto>>.Success(data: res);
        }
    }
}