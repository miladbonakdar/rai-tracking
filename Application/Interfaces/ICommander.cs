using System;
using System.Threading.Tasks;
using Domain.Interfaces;
using SharedKernel;

namespace Application.Interfaces
{
    public interface ICommander
    {
        Task<Result<bool>> SendAsync<TCommand>(TCommand command) where TCommand : IApplicationCommand;
    }
}