using System.Threading.Tasks;
using Application.DTO;

namespace Application.Services.Contracts
{
    public interface IAdminService
    {
        Task<AdminDto> UpdateAsync(AdminDto dto);
        Task<AdminDto> DeleteAsync(int id);
        Task<AdminDto> GetAsync(int id);
        Task<AdminDto> CreateAsync(AdminDto dto);
        Task UpdatePasswordAsync(PasswordUpdateDto dto);
        Task<PageDto<AdminDto>> GetPageAsync(int pageSize, int pageNumber);
    }
}