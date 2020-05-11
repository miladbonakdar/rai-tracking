using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace RaiTracking.Controllers.Admin
{
    [Route(RouteBase)]
    public class DashboardController : BaseAdminApiController
    {
        private readonly ISmsService _smsService;

        public DashboardController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        [WasFine]
        [HttpGet(nameof(SmsServiceStatus))]
        public async Task<Result<SmsServiceInfoDto>> SmsServiceStatus(int pageSize, int pageNumber)
        {
            var info = await _smsService.GetStatusAsync();
            return Result<SmsServiceInfoDto>.Success(data: info);
        }
    }
}