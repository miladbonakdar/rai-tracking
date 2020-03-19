﻿using System.Linq;
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
    public class DepoService : IDepoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheStore _cacheStore;

        public DepoService(IUnitOfWork unitOfWork, ICacheStore cacheStore)
        {
            _unitOfWork = unitOfWork;
            _cacheStore = cacheStore;
        }

        [NeedTest]
        public async Task<DepoDto> UpdateAsync(DepoDto dto)
        {
            var depo = await _unitOfWork.Depos.SingleOrDefaultAsync(a => a.Id == dto.Id);
            if (depo is null) throw new NotFoundException(dto.Id.ToString());
            await _unitOfWork.CompleteAsync(ctx =>
                depo.Update(dto.Name, dto.OrganizationId, dto.StationId));
            await _cacheStore.RemoveAsync(GetCacheKey(dto.Id));
            return dto;
        }

        [NeedTest]
        public async Task UpdateLocationAsync(LocationUpdateDto dto)
        {
            var depo = await _unitOfWork.Depos.SingleOrDefaultAsync(a => a.Id == dto.DomainId);
            if (depo is null) throw new NotFoundException(dto.DomainId.ToString());

            _unitOfWork.Depos.UpdatedOwnedProperty(depo, d => d.Location, d =>
            {
                var location = new Location(dto.Latitude, dto.Longitude);
                d.UpdateLocation(location);
            });
            await _unitOfWork.CompleteAsync();
            await _cacheStore.RemoveAsync(GetCacheKey(dto.DomainId));
        }

        [NeedTest]
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

        [NeedTest]
        public async Task<DepoDto> DeleteAsync(int id)
        {
            var depo = await _unitOfWork.Depos.SingleAsync(a => a.Id == id);
            await _unitOfWork.CompleteAsync((ctx) => ctx.Depos.Remove(depo));
            await _cacheStore.RemoveAsync(GetCacheKey(id));
            return DepoDto.FromDomain(depo);
        }

        [NeedTest]
        public async Task<DepoDto> GetAsync(int id)
        {
            var depoDto = await _cacheStore.StoreAndGetAsync(GetCacheKey(id), async () =>
            {
                var depo = await _unitOfWork.Depos.SingleOrDefaultAsync(a => a.Id == id);
                if (depo is null) throw new NotFoundException(id.ToString());
                return DepoDto.FromDomain(depo);
            });
            return depoDto;
        }

        [NeedTest]
        public async Task<PageDto<DepoDto>> GetPageAsync(int pageSize, int pageNumber)
        {
            var page = new PageDto<DepoDto>(pageSize, pageNumber);
            var items = await _unitOfWork.Depos.GetPageAsync(pageSize, pageNumber);
            page.SetData(items.Item2, items.Item1.Select(i => DepoDto.FromDomain(i)).ToList());
            return page;
        }

        private static string GetCacheKey(int id) => $"Depo_{id}";
    }
}