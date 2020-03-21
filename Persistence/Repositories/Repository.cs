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
        protected readonly IQueryable<T> BaseQuery;
        protected readonly AppDbContext Context;
        protected readonly DbSet<T> DbSet;

        protected Repository(DbContext context, Func<DbSet<T>, IQueryable<T>> baseQueryBuilder = null)
        {
            Context = context as AppDbContext;
            DbSet = context.Set<T>();
            BaseQuery = baseQueryBuilder is null
                ? DbSet.AsQueryable()
                : baseQueryBuilder(DbSet);
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
            return BaseQuery.First(where);
        }

        public virtual Task<T> FirstAsync(Expression<Func<T, bool>> @where)
        {
            return BaseQuery.FirstAsync(where);
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> @where)
        {
            return BaseQuery.FirstOrDefault(where);
        }

        public virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> @where)
        {
            return BaseQuery.FirstOrDefaultAsync(where);
        }

        public virtual T Single(Expression<Func<T, bool>> @where)
        {
            return BaseQuery.Single(where);
        }

        public virtual Task<T> SingleAsync(Expression<Func<T, bool>> @where)
        {
            return BaseQuery.SingleAsync(where);
        }

        public virtual T SingleOrDefault(Expression<Func<T, bool>> @where)
        {
            return BaseQuery.SingleOrDefault(where);
        }

        public virtual Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> @where)
        {
            return BaseQuery.SingleOrDefaultAsync(where);
        }

        public virtual IList<T> Get(Expression<Func<T, bool>> @where = null)
        {
            return @where is null ? BaseQuery.ToList() : BaseQuery.Where(@where).ToList();
        }

        public virtual async Task<IList<T>> GetAsync(Expression<Func<T, bool>> @where = null)
        {
            return @where is null
                ? await BaseQuery.ToListAsync()
                : await BaseQuery.Where(@where).ToListAsync();
        }

        public virtual async Task<Tuple<IList<T>, int>> GetPageAsync(int pageSize, int pageNumber,
            Expression<Func<T, bool>> @where = null)
        {
            void PageParameterGuard(ref int pageSize, ref int pageNumber)
            {
                pageSize = Math.Min(Math.Max(pageSize, 1), 50);
                pageNumber = Math.Max(pageNumber, 0);
            }

            PageParameterGuard(ref pageSize, ref pageNumber);
            var query = BaseQuery;
            if (@where != null)
                query = query.Where(@where);

            var listItems = await query.OrderBy(i => i.Id).Skip(pageSize * pageNumber)
                .Take(pageSize).ToListAsync();
            var total = await query.CountAsync();

            return new Tuple<IList<T>, int>(listItems, total);
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
            return BaseQuery.AnyAsync(where);
        }

        public virtual bool Any(Expression<Func<T, bool>> @where)
        {
            return BaseQuery.Any(where);
        }
    }
}