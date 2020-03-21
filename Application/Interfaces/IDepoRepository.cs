using System.Threading.Tasks;
using Domain;

namespace Application.Interfaces
{
    public interface IDepoRepository : IRepository<Depo>
    {
        Task GuardForDuplicateDepoName(string dtoName, int? currentItemId = null);
    }
}