using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO;
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

        public virtual T Find(int id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<T> FindAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual T First(Expression<Func<T, bool>> @where)
        {
            return DbSet.First(where);
        }

        public virtual Task<T> FirstAsync(Expression<Func<T, bool>> @where)
        {
            return DbSet.FirstAsync(where);
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> @where)
        {
            return DbSet.FirstOrDefault(where);
        }

        public virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> @where)
        {
            return DbSet.FirstOrDefaultAsync(where);
        }

        public virtual T Single(Expression<Func<T, bool>> @where)
        {
            return DbSet.Single(where);
        }

        public virtual Task<T> SingleAsync(Expression<Func<T, bool>> @where)
        {
            return DbSet.SingleAsync(where);
        }

        public virtual T SingleOrDefault(Expression<Func<T, bool>> @where)
        {
            return DbSet.SingleOrDefault(where);
        }

        public virtual Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> @where)
        {
            return DbSet.SingleOrDefaultAsync(where);
        }

        public virtual IList<T> Get(Expression<Func<T, bool>> @where = null)
        {
            return @where is null ? DbSet.ToList() : DbSet.Where(@where).ToList();
        }

        public virtual async Task<IList<T>> GetAsync(Expression<Func<T, bool>> @where = null)
        {
            return @where is null
                ? await DbSet.ToListAsync()
                : await DbSet.Where(@where).ToListAsync();
        }

        public virtual async Task<Tuple<IList<T>, int>> GetPageAsync(int pageSize, int pageNumber,
            Expression<Func<T, bool>> @where = null)
        {
            var query = DbSet.AsQueryable();
            if (@where != null)
                query = query.Where(@where);

            var listQuery = query.OrderBy(i => i.Id).Skip(pageSize * pageNumber)
                .Take(pageSize).ToListAsync();
            var listTotal = query.CountAsync();

            await Task.WhenAll(listQuery, listTotal);

            return new Tuple<IList<T>, int>(await listQuery, await listTotal);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public virtual Task<bool> AnyAsync(Expression<Func<T, bool>> @where)
        {
            return DbSet.AnyAsync(where);
        }

        public virtual bool Any(Expression<Func<T, bool>> @where)
        {
            return DbSet.Any(where);
        }
    }
}