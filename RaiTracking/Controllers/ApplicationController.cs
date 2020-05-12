using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SharedKernel.Constants;

namespace RaiTracking.Controllers
{
    [Route("Public/v1/[controller]")]
    public class ApplicationController : BaseApiController
    {
        private readonly ISmsService _service;

        public ApplicationController(ISmsService service)
        {
            _service = service;
        }

        [WasFine]
        [HttpGet]
        public Result<string> Index() => Result<string>.Success(data: "yeah it is the main page");

        [HttpGet("test")]
        public async Task Test()
        {
            var status = await _service.GetStatusAsync();
        }

        [WasFine]
        [HttpGet(nameof(UserTypes))]
        public Result<IEnumerable<KeyValuePairDto<string, string>>> UserTypes()
            => Result<IEnumerable<KeyValuePairDto<string, string>>>.Success(data: new[]
            {
                new KeyValuePairDto<string, string>(Constants.UserType.Monitor, "بازرس کل"),
                new KeyValuePairDto<string, string>(Constants.UserType.Agent, "تعمیرکار"),
                new KeyValuePairDto<string, string>(Constants.UserType.OrganizationAdmin, "ادمین ناحیه"),
                new KeyValuePairDto<string, string>(Constants.UserType.OrganizationMonitor, "بازرس ناحیه"),
                new KeyValuePairDto<string, string>(Constants.UserType.RootAdmin, "ادمین کل"),
                new KeyValuePairDto<string, string>(Constants.UserType.SysAdmin, "ادمین سیستم"),
            });
    }
}