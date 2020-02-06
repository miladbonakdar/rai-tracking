using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace RaiTracking.Controllers.Public
{
    [Authorize]
    [Route("Public/v1/[controller]")]
    public class StationController : BaseApiController
    {
    }
}