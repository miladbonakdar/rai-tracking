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
        public UnitOfWork(AppDbContext context, IIdentityProvider identityProvider) : base(context, identityProvider)
        {
        }

        public int Complete(Action<IUnitOfWorkContext> beforeComplete = null)
        {
            beforeComplete?.Invoke(this);
            UpdateShadowProperties();
            return Context.SaveChanges();
        }

        public async Task<int> CompleteAsync(Func<IUnitOfWorkContext, Task> beforeComplete)
        {
            if (beforeComplete != null) await beforeComplete(this);
            UpdateShadowProperties();
            return await Context.SaveChangesAsync();
        }

        public Task<int> CompleteAsync(Action<IUnitOfWorkContext> beforeComplete)
        {
            beforeComplete?.Invoke(this);
            UpdateShadowProperties();
            return Context.SaveChangesAsync();
        }

        public Task<int> CompleteAsync()
        {
            UpdateShadowProperties();
            return Context.SaveChangesAsync();
        }

        private void UpdateShadowProperties()
        {
            foreach (var entry in Context.ChangeTracker.Entries())
            {
                if (AppDbContext.IgnoredForDefaultModelConfiguration().Contains(entry.Entity.GetType()))
                    continue;
                if (AppDbContext.OwnedProperties().Contains(entry.Entity.GetType()))
                    continue;

                if (entry.State == EntityState.Added)
                {
                    entry.Property(ShadowPropertyKeys.CreatedAt).CurrentValue = DateTime.Now;
                    entry.Property(ShadowPropertyKeys.CreatedBy).CurrentValue = IdentityProvider.Fullname;
                    entry.Property(ShadowPropertyKeys.CreatedById).CurrentValue = IdentityProvider.Id;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(ShadowPropertyKeys.UpdatedAt).CurrentValue = DateTime.Now;
                    entry.Property(ShadowPropertyKeys.UpdatedBy).CurrentValue = IdentityProvider.Fullname;
                    entry.Property(ShadowPropertyKeys.UpdatedById).CurrentValue = IdentityProvider.Id;
                }
            }
        }
    }
}