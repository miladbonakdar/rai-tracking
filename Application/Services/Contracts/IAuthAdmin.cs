using System.Threading.Tasks;
using Application.DTO;
using SharedKernel;

namespace Application.Services.Contracts
{
    public interface IAuthAdmin
    {
        Task<Result<AuthenticatedClientDto>> SignUpAdminAsync(RegisterAdminDto adminDto);
        Task<Result<AuthenticatedClientDto>> SignInAdminAsync(SignInDto adminDto);
    }
}