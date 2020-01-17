using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return Context.SaveChanges();
        }

        public async Task<int> Complete(Func<IUnitOfWorkContext, Task> beforeComplete = null)
        {
            if (beforeComplete != null) await beforeComplete(this);
            return await Context.SaveChangesAsync();
        }
    }
}