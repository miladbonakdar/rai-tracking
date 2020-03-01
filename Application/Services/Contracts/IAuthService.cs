using Domain;

namespace Application.Services.Contracts
{
    public interface IAuthService : IAuthAgent, IAuthAdmin
    {
    }
}