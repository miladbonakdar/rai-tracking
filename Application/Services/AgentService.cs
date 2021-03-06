﻿using System.Linq;
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
    class AgentService : IAgentService
    {
        private readonly IPasswordService _hasher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheStore _cacheStore;
        private readonly IIdentityProvider _identityProvider;

        public AgentService(IPasswordService hasher, IUnitOfWork unitOfWork
            , ICacheStore cacheStore
            , IIdentityProvider identityProvider)
        {
            _hasher = hasher;
            _unitOfWork = unitOfWork;
            _cacheStore = cacheStore;
            _identityProvider = identityProvider;
        }

        [WasFine]
        public async Task<AgentDto> CreateAsync(AgentDto dto)
        {
            await _unitOfWork.Agents.GuardForDuplicateEmailAddress(dto.Email);
            await _unitOfWork.Agents.GuardForDuplicatePhoneNumber(dto.PhoneNumber);

            var agent = new Agent(new PersonName(dto.Name, dto.Lastname)
                , dto.PhoneNumber, AgentSetting.CreateDefault()
                , dto.DepoId);
            agent.Register(dto.Email, _hasher.HashPassword(dto.Password));
            await _unitOfWork.CompleteAsync(ctx => ctx.Agents.AddAsync(agent));
            dto.Id = agent.Id;
            dto.Password = null;
            return dto;
        }

        [WasFine]
        public async Task<AgentDto> GetAsync(int id)
        {
            var agentDto = await _cacheStore.StoreAndGetAsync(GetCacheKey(id), async () =>
            {
                var agent = await Get(id);
                return AgentDto.FromDomain(agent);
            });
            return agentDto;
        }

        [WasFine]
        public async Task<AgentDto> DeleteAsync(int id)
        {
            var agent = await Get(id);
            await Task.WhenAll(_unitOfWork.CompleteAsync((ctx) => ctx.Agents.Remove(agent)),
                _cacheStore.RemoveAsync(GetCacheKey(id)));
            return AgentDto.FromDomain(agent);
        }

        [WasFine]
        public async Task<PageDto<AgentDto>> GetPageAsync(int pageSize, int pageNumber)
        {
            var page = new PageDto<AgentDto>(pageSize, pageNumber);
            var items = await _unitOfWork.Agents.GetPageAsync(pageSize, pageNumber);
            page.SetData(items.Item2, items.Item1.Select(i => AgentDto.FromDomain(i)).ToList());
            return page;
        }

        [WasFine]
        public async Task<AgentDto> UpdateAsync(AgentDto dto)
        {
            await _unitOfWork.Agents.GuardForDuplicateEmailAddress(dto.Email, dto.Id);
            await _unitOfWork.Agents.GuardForDuplicatePhoneNumber(dto.PhoneNumber, dto.Id);

            var agent = await Get(dto.Id);
            agent.Update(dto.Email, dto.PhoneNumber, dto.Name, dto.Lastname);

            await Task.WhenAll(_unitOfWork.CompleteAsync(), _cacheStore.RemoveAsync(GetCacheKey(dto.Id)));
            return dto;
        }

        [WasFine]
        public async Task ResetPasswordAsync(ResetPasswordDto dto)
        {
            if (!_identityProvider.HasValue || !_identityProvider.IsAdmin)
                throw new ForbiddenException();

            var agent = await Get(dto.DomainId);

            agent.UpdatePassword(_hasher.HashPassword(dto.Password));

            await _unitOfWork.CompleteAsync();
        }

        [WasFine]
        public async Task UpdateSettingAsync(UpdateAgentSettingDto dto)
        {
            var agent = await Get(dto.AgentId);
            await Task.WhenAll(_unitOfWork.CompleteAsync(ctx =>
                    agent.UpdateSetting(new AgentSetting(dto.Version))),
                _cacheStore.RemoveAsync(GetCacheKey(dto.AgentId)));
        }

        private async Task<Agent> Get(int id) =>
            await _unitOfWork.Agents.SingleOrDefaultAsync(a => a.Id == id)
            ?? throw new NotFoundException(id.ToString());

        private static string GetCacheKey(int id) => $"Agent_{id}";
    }
}