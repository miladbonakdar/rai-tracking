using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedKernel;

namespace RaiTracking.Controllers
{
    [Route("Public/v1/[controller]")]
    public class ApplicationController : BaseApiController
    {
        [HttpGet]
        public Result<string> Index() => Result<string>.Success(data: "yeah it is the main page");
    }
}
