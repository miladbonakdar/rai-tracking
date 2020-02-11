using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IApplicationCommandFactory
    {
        IApplicationCommand Create();
    }
}