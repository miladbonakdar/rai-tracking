using System.Threading.Tasks;
using Application.DTO;
using SharedKernel;

namespace Application.Services.Contracts
{
    public interface IAuthAgent
    {
        Task<Result<AuthenticatedClientDto>> SignInAgentAsync(SignInDto adminDto);
    }
}