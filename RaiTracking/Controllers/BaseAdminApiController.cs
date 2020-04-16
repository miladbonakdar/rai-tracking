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
    public abstract class BaseAdminApiController : BaseApiController
    {
        public const string RouteBase = "Admins/v1/[controller]";
    }
}