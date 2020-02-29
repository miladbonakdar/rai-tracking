using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Contracts;
using Domain;
using Domain.ValueObjects;
using Microsoft.IdentityModel.Tokens;
using SharedKernel;
using SharedKernel.Constants;
using SharedKernel.Exceptions;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordService _passwordService;
        private readonly IAuthSetting _authSetting;
        private readonly IAppSetting _appSetting;

        public AuthService(IUnitOfWork unitOfWork,
            IPasswordService passwordService, IAuthSetting authSetting, IAppSetting appSetting)
        {
            _unitOfWork = unitOfWork;
            _passwordService = passwordService;
            _authSetting = authSetting;
            _appSetting = appSetting;
        }

        public async Task<Result<AuthenticatedClientDto>> SignInAgentAsync(SignInDto dto)
        {
            var agentTask = dto.IsEmailAddress
                ? _unitOfWork.Agents.GetWithDepoAsync(a => a.Email == dto.EmailOrPhoneNumber)
                : _unitOfWork.Agents.GetWithDepoAsync(a => a.PhoneNumber == dto.EmailOrPhoneNumber);
            var agent = await agentTask;

            if (agent is null) throw new NotFoundException("کاربر مورد نظر یافت نشد. لطفا ورودی خود را چک کنید.");
            if (!_passwordService.Verify(dto.Password, agent.Password))
                throw new BadRequestException("password", "پسوورد اشتباه می باشد.");

            var expire = _authSetting.AgentExpireInDays < 0
                ? (DateTime?) null
                : DateTime.UtcNow.AddDays(_authSetting.AgentExpireInDays);

            var token = GenerateToken(GetAgentClaimsIdentity(agent), expire);

            return Result<AuthenticatedClientDto>.Success(data:
                new AuthenticatedClientDto(new AgentDto
                {
                    Id = agent.Id,
                    Lastname = agent.PersonName.Lastname,
                    Name = agent.PersonName.Firstname,
                    PhoneNumber = agent.PhoneNumber
                }, token));
        }

        public async Task<Result<AuthenticatedClientDto>> SignUpAdminAsync(RegisterAdminDto dto)
        {
            if (!_appSetting.AdminEmailAddress.Equals(dto.AdminEmailAddress, StringComparison.OrdinalIgnoreCase))
                throw new BadRequestException("AdminEmailAddress", "ایمیل ادمین اشتباه می باشد");
            if (!_passwordService.Verify(dto.RootPassword, _appSetting.RootPassword))
                throw new BadRequestException("password", "پسوورد ادمین اشتباه می باشد.");
            dto.Email = dto.Email.ToLower();

            if (await _unitOfWork.Admins.AnyAsync(a => a.Email == dto.Email))
                throw new BadRequestException("Email", "این ایمیل در سیستم وجود دارد");
            
            if (!await _unitOfWork.Organizations.AnyAsync(a => a.Id == dto.OrganizationId))
                throw new BadRequestException("OrganizationId", "سازمان وارد شده معتبر نمی باشد");

            var admin = new Admin
            {
                Email = dto.Email,
                OrganizationId = dto.OrganizationId,
                Password = _passwordService.HashPassword(dto.Password),
                Telephone = dto.Number,
                AdminType = dto.AdminType,
                PersonName = new PersonName(dto.Name, dto.Lastname),
                PhoneNumber = dto.PhoneNumber,
            };

            await _unitOfWork.CompleteAsync(async ctx => { await _unitOfWork.Admins.AddAsync(admin); });
            return await SignInAdminAsync(new SignInDto
            {
                Password = dto.Password,
                EmailOrPhoneNumber = dto.Email
            });
        }

        public async Task<Result<AuthenticatedClientDto>> SignInAdminAsync(SignInDto dto)
        {
            var adminTask = dto.IsEmailAddress
                ? _unitOfWork.Admins.SingleOrDefaultAsync(a => a.Email == dto.EmailOrPhoneNumber)
                : _unitOfWork.Admins.SingleOrDefaultAsync(a => a.PhoneNumber == dto.EmailOrPhoneNumber);
            var admin = await adminTask;

            if (admin is null) throw new NotFoundException("کاربر مورد نظر یافت نشد. لطفا ورودی خود را چک کنید.");
            if (!_passwordService.Verify(dto.Password, admin.Password))
                throw new BadRequestException("password", "پسوورد اشتباه می باشد.");

            var token = GenerateToken(GetAdminClaimsIdentity(admin),
                DateTime.UtcNow.AddDays(_authSetting.AdminExpireInDays));

            return Result<AuthenticatedClientDto>.Success(data:
                new AuthenticatedClientDto(new AdminDto
                {
                    Id = admin.Id,
                    Lastname = admin.PersonName.Lastname,
                    Name = admin.PersonName.Firstname,
                    PhoneNumber = admin.PhoneNumber,
                    Email = admin.Email,
                    Number = admin.Telephone
                }, token));
        }


        private string GenerateToken(ClaimsIdentity identity, DateTime? expireInDays)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = expireInDays,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                    , SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private ClaimsIdentity GetAdminClaimsIdentity(Admin admin)
        {
            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, admin.Id.ToString()),
                new Claim(ClaimTypes.Role, admin.AdminType.ToString()),
                new Claim(Constants.CustomClaimTypes.Fullname,
                    $"{admin.PersonName.Firstname} {admin.PersonName.Lastname}"),
                new Claim(ClaimTypes.Email, admin.Email),
                new Claim(Constants.CustomClaimTypes.PhoneNumber, admin.PhoneNumber),
                new Claim(Constants.CustomClaimTypes.Number, admin.Telephone),
                new Claim(Constants.CustomClaimTypes.Organization, admin.OrganizationId.ToString())
            });
            return claims;
        }

        private ClaimsIdentity GetAgentClaimsIdentity(Agent account)
        {
            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, account.Id.ToString()),
                new Claim(ClaimTypes.Role, Constants.AdminType.Agent),
                new Claim(Constants.CustomClaimTypes.Fullname,
                    $"{account.PersonName.Firstname} {account.PersonName.Lastname}"),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(Constants.CustomClaimTypes.PhoneNumber, account.PhoneNumber),
                new Claim(Constants.CustomClaimTypes.Organization, account.Depo.OrganizationId.ToString())
            });
            return claims;
        }
    }
}