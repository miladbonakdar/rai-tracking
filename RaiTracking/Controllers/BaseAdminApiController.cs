using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace RaiTracking.Controllers
{

    [Authorize]
    [Route("Admins/v1/[controller]")]
    public abstract class BaseAdminApiController : BaseApiController
    {
    }
}
