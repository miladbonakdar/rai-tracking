using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Domain;
using Serilog;
using SharedKernel.Exceptions;

namespace Application.Services
{
    class StationService : IStationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheStore _cacheStore;

        public StationService(IUnitOfWork unitOfWork, ICacheStore cacheStore)
        {
            _unitOfWork = unitOfWork;
            _cacheStore = cacheStore;
        }

        public async Task<StationDto> CreateAsync(StationDto dto)
        {
            await _unitOfWork.Stations.GuardForDuplicateDepoName(dto.Name);
            var station = new Station(dto.Name, dto.OrganizationId);
            var sideStations = await _unitOfWork.Stations.GetAsync(s => s.Id == dto.PreStationId
                                                                        || s.Id == dto.PostStationId);
            station.SetPosition(dto.Latitude, dto.Longitude, dto.Altitude);
            station.SetId(await _unitOfWork.Stations.NextIdAsync());

            await _unitOfWork.CompleteAsync(ctx => ctx.Stations.AddAsync(station));

            station.SetPreStation(sideStations.FirstOrDefault(s => s.Id == dto.PreStationId), dto.ForceUpdateNeighbors)
                .SetPostStation(sideStations.FirstOrDefault(s => s.Id == dto.PostStationId), dto.ForceUpdateNeighbors);
            await _unitOfWork.CompleteAsync();
            dto.Id = station.Id;
            return dto;
        }

        public async Task<StationDto> UpdateAsync(StationDto dto)
        {
            await _unitOfWork.Stations.GuardForDuplicateDepoName(dto.Name, dto.Id);
            var station = await _unitOfWork.Stations.FindOrThrowAsync(dto.Id);
            var sideStations = await _unitOfWork.Stations.GetAsync(s => s.Id == dto.PreStationId
                                                                        || s.Id == dto.PostStationId);

            await Task.WhenAll(_unitOfWork.CompleteAsync(ctx =>
                {
                    station.Update(dto.Name, dto.OrganizationId);

                    station.SetPosition(dto.Latitude, dto.Longitude, dto.Altitude)
                        .SetPreStation(sideStations.FirstOrDefault(s => s.Id == dto.PreStationId), dto.ForceUpdateNeighbors)
                        .SetPostStation(sideStations.FirstOrDefault(s => s.Id == dto.PostStationId), dto.ForceUpdateNeighbors);
                }),
                _cacheStore.RemoveAsync(GetCacheKey(dto.Id)));
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var station = await _unitOfWork.Stations.FindOrThrowAsync(id);
            await Task.WhenAll(_unitOfWork.CompleteAsync((ctx) => ctx.Stations.DetachAndDelete(station)),
                _cacheStore.RemoveAsync(GetCacheKey(id)));
        }

        public async Task<StationDto> GetAsync(int id)
        {
            var dto = await _cacheStore.StoreAndGetAsync(GetCacheKey(id), async () =>
            {
                var item = await _unitOfWork.Stations.FindOrThrowAsync(id);
                return StationDto.FromDomain(item);
            });
            return dto;
        }

        public async Task<PageDto<StationDto>> GetPageAsync(int pageSize, int pageNumber)
        {
            var page = new PageDto<StationDto>(pageSize, pageNumber);
            var items = await _unitOfWork.Stations.GetPageAsync(pageSize, pageNumber);
            page.SetData(items.Item2, items.Item1.Select(i => StationDto.FromDomain(i)).ToList());
            return page;
        }

        public async Task<IEnumerable<StationDto>> GetByOrganizationAsync(int id)
        {
            var items = await _unitOfWork.Stations.GetAsync(s => s.OrganizationId == id);

            IEnumerable<StationDto> ConvertToDtoList(IEnumerable<Station> list)
            {
                foreach (var item in list)
                    yield return StationDto.FromDomain(item);
            }

            return ConvertToDtoList(items);
        }

        public async Task<IEnumerable<StationDto>> GetNeighboursByStation(int id)
        {
            var items = await _unitOfWork.Stations.GetAsync(s =>
                s.PreStationId == id || s.PostStationId == id);

            IEnumerable<StationDto> ConvertToDtoList(IEnumerable<Station> list)
            {
                foreach (var item in list)
                    yield return StationDto.FromDomain(item);
            }

            return ConvertToDtoList(items);
        }

        private static string GetCacheKey(int id) => $"Station_{id}";
    }
}