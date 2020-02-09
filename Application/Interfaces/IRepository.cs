using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SharedKernel.Interfaces;

namespace Application.Interfaces
{
    public interface IRepository<TAggregateRoot> 
        where TAggregateRoot : class , IAggregateRoot
    {

        int Add(TAggregateRoot entity);
        Task<int> AddAsync(TAggregateRoot entity);

        void AddRange(IEnumerable<TAggregateRoot> entities);
        Task AddRangeAsync(IEnumerable<TAggregateRoot> entities);

        TAggregateRoot Find(int id);
        Task<TAggregateRoot> FindAsync(int id);

        TAggregateRoot First(Expression<Func<TAggregateRoot, bool>> where);
        Task<TAggregateRoot> FirstAsync(Expression<Func<TAggregateRoot, bool>> where);

        TAggregateRoot FirstOrDefault(Expression<Func<TAggregateRoot, bool>> where);
        Task<TAggregateRoot> FirstOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> where);

        TAggregateRoot Single(Expression<Func<TAggregateRoot, bool>> where);
        Task<TAggregateRoot> SingleAsync(Expression<Func<TAggregateRoot, bool>> where);

        TAggregateRoot SingleOrDefault(Expression<Func<TAggregateRoot, bool>> where);
        Task<TAggregateRoot> SingleOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> where);

        IList<TAggregateRoot> Get(Expression<Func<TAggregateRoot, bool>> where);
        Task<IList<TAggregateRoot>> GetAsync(Expression<Func<TAggregateRoot, bool>> where);

        void Remove(TAggregateRoot entity);
        void RemoveRange(IEnumerable<TAggregateRoot> entities);
    }
}