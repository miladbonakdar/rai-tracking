using System.Threading.Tasks;
using Application.DTO;

namespace Application.Services.Contracts
{
    public interface IAdminProfileService
    {
        Task UpdatePasswordAsync(PasswordUpdateDto dto);
        Task<AdminDto> UpdateAsync(AdminDto dto);
        Task<AdminProfileDto> GetAsync(int id);
    }
}