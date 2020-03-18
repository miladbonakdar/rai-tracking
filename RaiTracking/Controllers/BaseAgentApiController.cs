using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using SharedKernel.Constants;

namespace RaiTracking.Controllers
{
    [Authorize(Roles = Constants.UserType.Agent)]
    public abstract class BaseAgentApiController : BaseApiController
    {
        public const string RouteBase = "Agents/v1/[controller]";
    }
}