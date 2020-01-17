using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IUnitOfWorkContext
    {
        int Complete(Action<IUnitOfWorkContext> beforeComplete = null);
        Task<int> Complete(Func<IUnitOfWorkContext, Task> beforeComplete = null);
    }
}