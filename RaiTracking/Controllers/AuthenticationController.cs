using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SharedKernel.Constants;

namespace RaiTracking.Controllers
{
    [Route("Public/v1/Auth")]
    public class AuthenticationController : BaseApiController
    {
        private readonly IAuthService _authService;
        private readonly IIdentityProvider _identityProvider;

        public AuthenticationController(IAuthService authService, IIdentityProvider identityProvider)
        {
            _authService = authService;
            _identityProvider = identityProvider;
        }

        [WasFine]
        [HttpPost(nameof(SignUpAdmin))]
        public async Task<Result<AuthenticatedClientDto>> SignUpAdmin([FromBody] RegisterAdminDto dto)
            => await _authService.SignUpAdminAsync(dto);

        [WasFine]
        [HttpPost(nameof(SignInAgent))]
        public async Task<Result<AuthenticatedClientDto>> SignInAgent([FromBody] SignInDto dto)
            => await _authService.SignInAgentAsync(dto);

        [WasFine]
        [HttpPost(nameof(SignInAdmin))]
        public async Task<Result<AuthenticatedClientDto>> SignInAdmin([FromBody] SignInDto dto)
            => await _authService.SignInAdminAsync(dto);

        [WasFine]
        [Authorize]
        [HttpGet(nameof(Agent))]
        public Result<AgentDto> Agent()
            => Result<AgentDto>.Success(data: new AgentDto
            {
                Id = _identityProvider.Id,
                Lastname = _identityProvider.Fullname,
                Name = _identityProvider.Fullname,
                PhoneNumber = _identityProvider.PhoneNumber,
            });

        [WasFine]
        [Authorize(Roles = Constants.UserGroup.AllAdmins)]
        [HttpGet(nameof(Admin))]
        public Result<AuthorizedAdminDto> Admin()
            => Result<AuthorizedAdminDto>.Success(data: new AuthorizedAdminDto(new AdminDto
            {
                Email = _identityProvider.Email,
                Lastname = _identityProvider.Fullname,
                Id = _identityProvider.Id,
                Name = _identityProvider.Fullname,
                PhoneNumber = _identityProvider.PhoneNumber,
                AdminType = _identityProvider.Role,
                OrganizationId = _identityProvider.OrganizationId
            }));


        [WasFine]
        [HttpGet(nameof(AdminTypes))]
        public Result<IEnumerable<KeyValuePairDto<string, string>>> AdminTypes()
            => Result<IEnumerable<KeyValuePairDto<string, string>>>.Success(data: new[]
            {
                new KeyValuePairDto<string, string>(Constants.UserType.Monitor, "بازرس کل"),
                new KeyValuePairDto<string, string>(Constants.UserType.OrganizationAdmin, "ادمین ناحیه"),
                new KeyValuePairDto<string, string>(Constants.UserType.OrganizationMonitor, "بازرس ناحیه"),
                new KeyValuePairDto<string, string>(Constants.UserType.RootAdmin, "ادمین کل"),
            });
    }
}