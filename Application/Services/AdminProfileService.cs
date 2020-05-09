using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Contracts;
using Domain;
using SharedKernel.Constants;
using SharedKernel.Exceptions;

namespace Application.Services
{
    class AdminProfileService : IAdminProfileService
    {
        private readonly IIdentityProvider _identityProvider;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordService _hasher;
        private readonly ICacheStore _cacheStore;

        public AdminProfileService(IIdentityProvider identityProvider, IUnitOfWork unitOfWork
            , IPasswordService hasher, ICacheStore cacheStore)
        {
            _identityProvider = identityProvider;
            _unitOfWork = unitOfWork;
            _hasher = hasher;
            _cacheStore = cacheStore;
        }

        private void GuardForJustTheProfileOwner(int id)
        {
            if (!_identityProvider.HasValue
                || !_identityProvider.IsAdmin
                || _identityProvider.Id != id)
                throw new ForbiddenException();
        }

        public async Task UpdatePasswordAsync(PasswordUpdateDto dto)
        {
            GuardForJustTheProfileOwner(dto.DomainId);

            var user = await Get(dto.DomainId);

            if (!_hasher.Verify(dto.OldPassword, user.Password))
                throw new BadRequestException(nameof(dto.OldPassword), "پسورد قدیمی اشتباه می باشد");

            user.UpdatePassword(_hasher.HashPassword(dto.NewPassword));

            await _unitOfWork.CompleteAsync();
            await _cacheStore.RemoveAsync(GetCacheKey(dto.DomainId));
        }

        public async Task<AdminDto> UpdateAsync(AdminDto dto)
        {
            GuardForJustTheProfileOwner(dto.Id);
            await _unitOfWork.Admins.GuardForDuplicateEmailAddress(dto.Email, dto.Id);

            var admin = await Get(dto.Id);

            admin.UpdateInfo(dto.PhoneNumber, dto.Name, dto.Lastname,
                    dto.About, dto.Number)
                .UpdateEmail(dto.Email)
                .UpdateOrganization(dto.OrganizationId)
                .UpdateAdminType(dto.AdminType);

            await _unitOfWork.CompleteAsync();
            await _cacheStore.RemoveAsync(GetCacheKey(dto.Id));
            return dto;
        }

        public async Task<AdminProfileDto> GetAsync(int id)
        {
            GuardForJustTheProfileOwner(id);
            return await _cacheStore.StoreAndGetAsync(GetCacheKey(id),
                async () => await _unitOfWork.Admins.GetUserProfile(id));
        }


        private async Task<Admin> Get(int id) =>
            await _unitOfWork.Admins.SingleOrDefaultAsync(a => a.Id == id) ??
            throw new NotFoundException(id.ToString());


        private static string GetCacheKey(int id) => $"Profile_{id}";
    }
}