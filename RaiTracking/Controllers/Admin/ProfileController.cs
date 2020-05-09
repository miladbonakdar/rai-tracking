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
    public class ProfileController : BaseAdminApiController
    {
        private readonly IAdminProfileService _profileService;

        public ProfileController(IAdminProfileService profileService)
        {
            _profileService = profileService;
        }
        
        [WasFine]
        [HttpPut]
        public async Task<Result<AdminDto>> Update([FromBody] AdminDto dto)
        {
            var admin = await _profileService.UpdateAsync(dto);
            return Result<AdminDto>.Success(data: admin);
        }

        [WasFine]
        [HttpPatch(nameof(UpdatePassword))]
        public async Task<Result> UpdatePassword([FromBody] PasswordUpdateDto dto)
        {
            await _profileService.UpdatePasswordAsync(dto);
            return Result.Success();
        }

        [WasFine]
        [HttpGet("{id}")]
        public async Task<Result<AdminProfileDto>> Get(int id)
        {
            var admin = await _profileService.GetAsync(id);
            return Result<AdminProfileDto>.Success(data: admin);
        }

    }
}