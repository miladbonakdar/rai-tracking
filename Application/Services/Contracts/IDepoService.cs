using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Services.Contracts
{
    public interface IDepoService
    {
        Task<DepoDto> UpdateAsync(DepoDto dto);
        Task<DepoDto> CreateAsync(DepoDto dto);
        Task UpdateLocationAsync(LocationUpdateDto dto);
        Task<DepoDto> DeleteAsync(int id);
        Task<DepoDto> GetAsync(int id);
        Task<IEnumerable<DepoDto>> GetByOrganizationAsync(int? organId);
        Task<PageDto<DepoDto>> GetPageAsync(int pageSize, int pageNumber);
    }
}