using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Persistence
{
    class UnitOfWork : UnitOfWorkContext, IUnitOfWork
    {
        public UnitOfWork(DbContext context) : base(context)
        {
        }

        public int Complete(Action<IUnitOfWorkContext> beforeComplete = null)
        {
            beforeComplete?.Invoke(this);
            // foreach (var entry in Context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
            // {
            //     entry.Property(ShadowPropertyKeys.CreatedAt).CurrentValue = DateTime.Now;
            //     entry.Property(ShadowPropertyKeys.CreatedBy).CurrentValue = ;
            // }
            return Context.SaveChanges();
        }

        public async Task<int> CompleteAsync(Func<IUnitOfWorkContext, Task> beforeComplete = null)
        {
            if (beforeComplete != null) await beforeComplete(this);
            return await Context.SaveChangesAsync();
        }
    }
}