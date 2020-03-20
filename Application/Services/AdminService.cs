using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Contracts;
using Domain;
using Domain.ValueObjects;
using SharedKernel;
using SharedKernel.Constants;
using SharedKernel.Exceptions;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheStore _cacheStore;
        private readonly IPasswordService _hasher;
        private readonly IIdentityProvider _identityProvider;

        public AdminService(IUnitOfWork unitOfWork, ICacheStore cacheStore, IPasswordService hasher,
            IIdentityProvider identityProvider)
        {
            _unitOfWork = unitOfWork;
            _cacheStore = cacheStore;
            _hasher = hasher;
            _identityProvider = identityProvider;
        }

        [NeedTest]
        public async Task<AdminDto> UpdateAsync(AdminDto dto)
        {
            if (!Constants.UserGroup.AllRootAdmins.Contains(_identityProvider.Role)
                && _identityProvider.Id != dto.Id)
                throw new ForbiddenException("شما نمی توانید اطلاعات شخص دیگری را تغییر دهید");

            var admin = await _unitOfWork.Admins.SingleOrDefaultAsync(a => a.Id == dto.Id);
            if (admin is null) throw new NotFoundException(dto.Id.ToString());

            admin.UpdateInfo(dto.PhoneNumber, dto.Name, dto.Lastname,
                    dto.About, dto.Number)
                .UpdateEmail(dto.Email)
                .UpdateOrganization(dto.OrganizationId)
                .UpdateAdminType(dto.AdminType);

            await _unitOfWork.CompleteAsync();
            await _cacheStore.RemoveAsync(GetCacheKey(dto.Id));
            return dto;
        }

        [NeedTest]
        public async Task UpdatePasswordAsync(PasswordUpdateDto dto)
        {
            if (!_identityProvider.HasValue || !_identityProvider.IsAdmin)
                throw new ForbiddenException();
            if (_identityProvider.Id != dto.DomainId &&
                !Constants.UserGroup.AllRootAdmins.Contains(_identityProvider.Role))
                throw new ForbiddenException("شما نمی توانید پسورد فرد دیگری را تغییر دهید");

            var admin = await _unitOfWork.Admins.SingleOrDefaultAsync(a => a.Id == dto.DomainId);
            if (admin is null) throw new NotFoundException(dto.DomainId.ToString());
            if (!_hasher.Verify(dto.OldPassword, admin.Password))
                throw new BadRequestException(nameof(dto.OldPassword), "پسورد قدیمی اشتباه می باشد");

            admin.UpdatePassword(_hasher.HashPassword(dto.NewPassword));

            await _unitOfWork.CompleteAsync();
            await _cacheStore.RemoveAsync(GetCacheKey(dto.DomainId));
        }

        [NeedTest]
        public async Task<AdminDto> CreateAsync(AdminDto dto)
        {
            var admin = new Admin(new PersonName(dto.Name, dto.Lastname), dto.AdminType, dto.OrganizationId
                , dto.PhoneNumber, dto.Number, dto.About);

            await _unitOfWork.CompleteAsync(ctx => ctx.Admins.AddAsync(admin));
            dto.Id = admin.Id;
            return dto;
        }

        [NeedTest]
        public async Task<AdminDto> DeleteAsync(int id)
        {
            var admin = await _unitOfWork.Admins.SingleAsync(a => a.Id == id)
                        ?? throw new NotFoundException(id.ToString());
            await _unitOfWork.CompleteAsync((ctx) => ctx.Admins.Remove(admin));
            await _cacheStore.RemoveAsync(GetCacheKey(id));
            return AdminDto.FromDomain(admin);
        }

        [NeedTest]
        public async Task<AdminDto> GetAsync(int id)
        {
            var adminDto = await _cacheStore.StoreAndGetAsync(GetCacheKey(id), async () =>
            {
                var admin = await _unitOfWork.Admins.SingleOrDefaultAsync(a => a.Id == id);
                if (admin is null) throw new NotFoundException(id.ToString());
                return AdminDto.FromDomain(admin);
            });
            return adminDto;
        }

        [NeedTest]
        public async Task<PageDto<AdminDto>> GetPageAsync(int pageSize, int pageNumber)
        {
            var page = new PageDto<AdminDto>(pageSize, pageNumber);
            var items = await _unitOfWork.Admins.GetPageAsync(pageSize, pageNumber);
            page.SetData(items.Item2, items.Item1.Select(i => AdminDto.FromDomain(i)).ToList());
            return page;
        }

        private static string GetCacheKey(int id) => $"Admin_{id}";
    }
}