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
        private readonly IIdentityProvider _identityProvider;

        public UnitOfWork(AppDbContext context, IIdentityProvider identityProvider) : base(context)
        {
            _identityProvider = identityProvider;
        }

        public int Complete(Action<IUnitOfWorkContext> beforeComplete = null)
        {
            beforeComplete?.Invoke(this);
            foreach (var entry in Context.ChangeTracker.Entries())
            {
                if (AppDbContext.IgnoredForDefaultModelConfiguration().Contains(entry.Entity.GetType()))
                    continue;
                
                if (entry.State == EntityState.Added)
                {
                    entry.Property(ShadowPropertyKeys.CreatedAt).CurrentValue = DateTime.Now;
                    entry.Property(ShadowPropertyKeys.CreatedBy).CurrentValue = _identityProvider.Fullname;
                    entry.Property(ShadowPropertyKeys.CreatedById).CurrentValue = _identityProvider.Id;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(ShadowPropertyKeys.UpdatedAt).CurrentValue = DateTime.Now;
                    entry.Property(ShadowPropertyKeys.UpdatedBy).CurrentValue = _identityProvider.Fullname;
                    entry.Property(ShadowPropertyKeys.UpdatedById).CurrentValue = _identityProvider.Id;
                }
            }

            return Context.SaveChanges();
        }

        public async Task<int> CompleteAsync(Func<IUnitOfWorkContext, Task> beforeComplete = null)
        {
            if (beforeComplete != null) await beforeComplete(this);
            return await Context.SaveChangesAsync();
        }
    }
}