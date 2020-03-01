using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost(nameof(SignUpAdmin))]
        public async Task<Result<AuthenticatedClientDto>> SignUpAdmin([FromBody]RegisterAdminDto dto)
            => await _authService.SignUpAdminAsync(dto);

        [HttpPost(nameof(SignInAgent))]
        public async Task<Result<AuthenticatedClientDto>> SignInAgent([FromBody]SignInDto dto)
            => await _authService.SignInAgentAsync(dto);

        [HttpPost(nameof(SignInAdmin))]
        public async Task<Result<AuthenticatedClientDto>> SignInAdmin([FromBody]SignInDto dto)
            => await _authService.SignInAdminAsync(dto);

        [Authorize(Roles = Constants.AdminType.Agent)]
        [HttpGet(nameof(Agent))]
        public Result<AgentDto> Agent()
            => Result<AgentDto>.Success(data: new AgentDto
            {
                Id = _identityProvider.Id,
                Lastname = _identityProvider.Fullname,
                Name = _identityProvider.Fullname,
                PhoneNumber = _identityProvider.PhoneNumber
            });

        [Authorize]
        [HttpGet(nameof(Admin))]
        public Result<AdminDto> Admin()
            => Result<AdminDto>.Success(data: new AdminDto
            {
                Email = _identityProvider.Email,
                Lastname = _identityProvider.Fullname,
                Id = _identityProvider.Id,
                Name = _identityProvider.Fullname,
                Number = _identityProvider.Number,
                PhoneNumber = _identityProvider.PhoneNumber
            });


        [HttpGet(nameof(AdminTypes))]
        public Result<IEnumerable<string>> AdminTypes()
            => Result<IEnumerable<string>>.Success(data: new[]
            {
                Constants.AdminType.Agent,
                Constants.AdminType.Monitor,
                Constants.AdminType.OrganizationAdmin,
                Constants.AdminType.OrganizationMonitor,
                Constants.AdminType.RootAdmin,
                Constants.AdminType.SysAdmin
            });
    }
}