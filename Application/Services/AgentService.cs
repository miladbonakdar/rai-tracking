using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Contracts;
using Domain.ValueObjects;
using SharedKernel;
using SharedKernel.Constants;
using SharedKernel.Exceptions;

namespace Application.Services
{
    public class AgentService : IAgentService
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

        [NeedTest]
        public async Task<AgentDto> CreateAsync(AgentDto dto)
        {
            var agent = new Domain.Agent(new PersonName(dto.Name, dto.Lastname)
                , dto.PhoneNumber, AgentSetting.CreateDefault()
                , dto.DepoId);
            agent.Register(dto.Email, _hasher.HashPassword(dto.Password));
            await _unitOfWork.CompleteAsync(ctx => ctx.Agents.AddAsync(agent));
            dto.Id = agent.Id;
            dto.Password = null;
            return dto;
        }

        [NeedTest]
        public async Task<AgentDto> GetAsync(int id)
        {
            var agentDto = await _cacheStore.StoreAndGetAsync(GetCacheKey(id), async () =>
            {
                var agent = await _unitOfWork.Agents.SingleOrDefaultAsync(a => a.Id == id);
                if (agent is null) throw new NotFoundException(id.ToString());
                return AgentDto.FromDomain(agent);
            });
            return agentDto;
        }

        [NeedTest]
        public async Task<AgentDto> DeleteAsync(int id)
        {
            var agent = await _unitOfWork.Agents.SingleAsync(a => a.Id == id);
            await _unitOfWork.CompleteAsync((ctx) => ctx.Agents.Remove(agent));
            await _cacheStore.RemoveAsync(GetCacheKey(id));
            return AgentDto.FromDomain(agent);
        }

        [NeedTest]
        public async Task<PageDto<AgentDto>> GetPageAsync(int pageSize, int pageNumber)
        {
            var page = new PageDto<AgentDto>(pageSize, pageNumber);
            var items = await _unitOfWork.Agents.GetPageAsync(pageSize, pageNumber);
            page.SetData(items.Item2, items.Item1.Select(i => AgentDto.FromDomain(i)).ToList());
            return page;
        }

        [NeedTest]
        public async Task<AgentDto> UpdateAsync(AgentDto dto)
        {
            var agent = await _unitOfWork.Agents.SingleOrDefaultAsync(a => a.Id == dto.Id);
            if (agent is null) throw new NotFoundException(dto.Id.ToString());
            _unitOfWork.Agents.UpdatedOwnedProperty(agent, a => a.PersonName
                , a => { a.Update(dto.Email, dto.PhoneNumber, dto.Name, dto.Lastname); });
            await _unitOfWork.CompleteAsync();
            await _cacheStore.RemoveAsync(GetCacheKey(dto.Id));
            return dto;
        }

        public async Task ResetPasswordAsync(ResetPasswordDto dto)
        {
            if (!_identityProvider.HasValue || !_identityProvider.IsAdmin)
                throw new ForbiddenException();

            var agent = await _unitOfWork.Agents.SingleOrDefaultAsync(a => a.Id == dto.DomainId);
            if (agent is null) throw new NotFoundException(dto.DomainId.ToString());

            agent.UpdatePassword(_hasher.HashPassword(dto.Password));

            await _unitOfWork.CompleteAsync();
            await _cacheStore.RemoveAsync(GetCacheKey(dto.DomainId));
        }

        private static string GetCacheKey(int id) => $"Agent_{id}";
    }
}