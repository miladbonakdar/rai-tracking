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
    }
}