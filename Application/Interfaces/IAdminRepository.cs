using System.Threading.Tasks;
using Application.DTO;
using Domain;
using SharedKernel;

namespace Application.Interfaces
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Task GuardForDuplicateEmailAddress(string email, int? currentItemId = null);
        Task<AdminProfileDto> GetUserProfile(int id);
    }
}