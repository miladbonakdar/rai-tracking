using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Contracts;
using Domain;
using Domain.ValueObjects;
using SharedKernel;
using SharedKernel.Exceptions;

namespace Application.Services
{
    class DepoService : IDepoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheStore _cacheStore;

        public DepoService(IUnitOfWork unitOfWork, ICacheStore cacheStore)
        {
            _unitOfWork = unitOfWork;
            _cacheStore = cacheStore;
        }

        [WasFine]
        public async Task<DepoDto> UpdateAsync(DepoDto dto)
        {
            await _unitOfWork.Depos.GuardForDuplicateDepoName(dto.Name, dto.Id);
            var depo = await Get(dto.Id);
            await Task.WhenAll(_unitOfWork.CompleteAsync(ctx =>
                    depo.Update(dto.Name, dto.OrganizationId, dto.StationId)),
                _cacheStore.RemoveAsync(GetCacheKey(dto.Id)));
            return dto;
        }

        [WasFine]
        public async Task UpdateLocationAsync(LocationUpdateDto dto)
        {
            var depo = await Get(dto.DomainId);
            var location = new Location(dto.Latitude, dto.Longitude);
            depo.UpdateLocation(location);
            await Task.WhenAll(_unitOfWork.CompleteAsync(), _cacheStore.RemoveAsync(GetCacheKey(dto.DomainId)));
        }

        [WasFine]
        public async Task<DepoDto> CreateAsync(DepoDto dto)
        {
            await _unitOfWork.Depos.GuardForDuplicateDepoName(dto.Name);
            var depo = new Depo(dto.Name, dto.OrganizationId, dto.StationId);
            if (dto.Location != null)
            {
                var location = new Location(dto.Location.Latitude, dto.Location.Longitude);
                depo.UpdateLocation(location);
            }

            await _unitOfWork.CompleteAsync(ctx => ctx.Depos.AddAsync(depo));
            dto.Id = depo.Id;
            return dto;
        }

        [WasFine]
        public async Task DeleteAsync(int id)
        {
            var depo = await Get(id);
            await Task.WhenAll(_unitOfWork.CompleteAsync((ctx) => ctx.Depos.Remove(depo)),
                _cacheStore.RemoveAsync(GetCacheKey(id)));
        }

        [WasFine]
        public async Task<DepoDto> GetAsync(int id)
        {
            var depoDto = await _cacheStore.StoreAndGetAsync(GetCacheKey(id), async () =>
            {
                var depo = await Get(id);
                return DepoDto.FromDomain(depo);
            });
            return depoDto;
        }

        [WasFine]
        public async Task<IEnumerable<DepoDto>> GetByOrganizationAsync(int? organId)
        {
            var organs = organId is null
                ? await _unitOfWork.Depos.GetAsync()
                : await _unitOfWork.Depos.GetAsync(d => d.OrganizationId == organId);
            return organs.Select(d => DepoDto.FromDomain(d)).ToList();
        }

        [WasFine]
        public async Task<PageDto<DepoDto>> GetPageAsync(int pageSize, int pageNumber)
        {
            var page = new PageDto<DepoDto>(pageSize, pageNumber);
            var items = await _unitOfWork.Depos.GetPageAsync(pageSize, pageNumber);
            page.SetData(items.Item2, items.Item1.Select(i => DepoDto.FromDomain(i)).ToList());
            return page;
        }

        private async Task<Depo> Get(int id) =>
            await _unitOfWork.Depos.SingleOrDefaultAsync(a => a.Id == id)
            ?? throw new NotFoundException(id.ToString());

        private static string GetCacheKey(int id) => $"Depo_{id}";
    }
}