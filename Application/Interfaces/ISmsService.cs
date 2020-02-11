using System.Collections.Generic;
using System.Threading.Tasks;
using SharedKernel;

namespace Application.Interfaces
{
    public interface ISmsService
    {
        Task<Result<bool>> SendAsync(string number, string content);
        Task<Result<bool>> SendManyAsync(IEnumerable<string> numbers, string content);
    }
}