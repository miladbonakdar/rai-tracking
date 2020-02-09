using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Interfaces;

namespace Persistence.Repositories
{

    abstract class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        protected readonly AppDbContext Context;
        protected DbSet<T> DbSet;

        protected Repository(DbContext context)
        {
            Context = context as AppDbContext;
            DbSet = context.Set<T>();
        }

        public int Add(T entity)
        {
            var res = DbSet.Add(entity);
            return res.Entity.Id;
        }

        public async Task<int> AddAsync(T entity)
        {
            var res = await DbSet.AddAsync(entity);
            return res.Entity.Id;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public Task AddRangeAsync(IEnumerable<T> entities)
        {
            return DbSet.AddRangeAsync(entities);
        }

        public T Find(int id)
        {
            return DbSet.Find(id);
        }

        public async Task<T> FindAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public T First(Expression<Func<T, bool>> @where)
        {
            return DbSet.First(where);
        }

        public Task<T> FirstAsync(Expression<Func<T, bool>> @where)
        {
            return DbSet.FirstAsync(where);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> @where)
        {
            return DbSet.FirstOrDefault(where);
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> @where)
        {
            return DbSet.FirstOrDefaultAsync(where);
        }

        public T Single(Expression<Func<T, bool>> @where)
        {
            return DbSet.Single(where);
        }

        public Task<T> SingleAsync(Expression<Func<T, bool>> @where)
        {
            return DbSet.SingleAsync(where);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> @where)
        {
            return DbSet.SingleOrDefault(where);
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> @where)
        {
            return DbSet.SingleOrDefaultAsync(where);
        }

        public IList<T> Get(Expression<Func<T, bool>> @where)
        {
            return DbSet.Where(where).ToList();
        }

        public async Task<IList<T>> GetAsync(Expression<Func<T, bool>> @where)
        {
            return await DbSet.Where(where).ToListAsync();
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}
