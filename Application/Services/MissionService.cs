using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Contracts;
using Domain;
using SharedKernel.Exceptions;

namespace Application.Services
{
    class MissionService : IMissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MissionDto> CreateAsync(MissionDto dto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UpdateMissionDto> UpdateAsync(UpdateMissionDto dto)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<MissionDto> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PageDto<MissionListDto>> GetPageAsync(int pageSize, int pageNumber)
        {
            throw new System.NotImplementedException();
        }


        private async Task<Mission> Get(int id) =>
            await _unitOfWork.Missions.SingleOrDefaultAsync(a => a.Id == id)
            ?? throw new NotFoundException(id.ToString());

        private static string GetCacheKey(int id) => $"Mission_{id}";
    }
}