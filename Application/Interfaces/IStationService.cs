using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IStationService
    {
        Task<StationDto> CreateAsync(StationDto dto);
        Task<StationDto> UpdateAsync(StationDto dto);
        Task DeleteAsync(int id);
        Task<StationDto> GetAsync(int id);
        Task<PageDto<StationDto>> GetPageAsync(int pageSize, int pageNumber);
        Task<IEnumerable<StationDto>> GetByOrganizationAsync(int id);
        Task<IEnumerable<StationDto>> GetNeighboursByStation(int id);
    }
}