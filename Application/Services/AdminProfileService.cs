using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Contracts;
using SharedKernel.Exceptions;

namespace Application.Services
{
    class AdminProfileService : IAdminProfileService
    {
        private readonly IIdentityProvider _identityProvider;

        public AdminProfileService(IIdentityProvider identityProvider)
        {
            _identityProvider = identityProvider;
        }

        private void GuardForJustTheProfileOwner(int id)
        {
            if (!_identityProvider.HasValue
                || !_identityProvider.IsAdmin
                || _identityProvider.Id != id)
                throw new ForbiddenException();
        }

        public Task UpdatePasswordAsync(PasswordUpdateDto dto)
        {
            GuardForJustTheProfileOwner(dto.DomainId);
            throw new System.NotImplementedException();
        }

        public Task<AdminDto> UpdateAsync(AdminDto dto)
        {
            GuardForJustTheProfileOwner(dto.Id);
            throw new System.NotImplementedException();
        }

        public Task<AdminProfileDto> GetAsync(int id)
        {
            GuardForJustTheProfileOwner(id);
            throw new System.NotImplementedException();
        }
    }
}