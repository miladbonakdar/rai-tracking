using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO;
using Domain;
using SharedKernel;

namespace Application.Interfaces
{
    public interface IAgentRepository : IRepository<Agent>
    {
        Task<Agent> GetWithDepoAsync(Expression<Func<Agent, bool>> predicate);
        Task GuardForDuplicateEmailAddress(string email, int? currentItemId = null);
        Task GuardForDuplicatePhoneNumber(string number, int? currentItemId = null);
    }
}