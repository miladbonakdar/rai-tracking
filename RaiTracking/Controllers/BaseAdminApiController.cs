using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using SharedKernel.Constants;

namespace RaiTracking.Controllers
{
    [Authorize(Roles = Constants.UserGroup.AllAdmins)]
    [Route("Admins/v1/[controller]")]
    public abstract class BaseAdminApiController : BaseApiController
    {
    }
}