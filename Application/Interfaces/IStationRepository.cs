using System.Threading.Tasks;
using Domain;

namespace Application.Interfaces
{
    public interface IStationRepository : IRepository<Station>
    {
        Task GuardForDuplicateDepoName(string dtoName, int? currentItemId = null);
        Task<int> NextIdAsync();
        Task DetachAndDelete(Station station);
    }
}