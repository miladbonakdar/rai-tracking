using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace RaiTracking.Controllers
{

    [Authorize]
    [Route("agents/v1/[controller]")]
    public abstract class BaseUserApiController : BaseApiController
    {
    }
}
