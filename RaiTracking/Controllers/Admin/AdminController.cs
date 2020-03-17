using System;
using System.Collections.Generic;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace RaiTracking.Controllers.Admin
{
    public class AdminController: BaseAdminApiController
    {
        
        [NeedTest]
        [HttpPost]
        public Result<AdminDto> Create([FromBody]AdminDto dto)
        {
            throw new NotImplementedException();
        }
        
        [NeedTest]
        [HttpPut]
        public Result<AdminDto> Update([FromBody]AdminDto dto)
        {
            throw new NotImplementedException();
        }
        
        [NeedTest]
        [HttpDelete("{id}")]
        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        [NeedTest]
        [HttpGet("{id}")]
        public Result<AdminDto> Get(int id)
        {
            throw new NotImplementedException();
        }
        
        [NeedTest]
        [HttpGet]
        public Result<IEnumerable<AdminDto>> Get()
        {
            throw new NotImplementedException();
        }
    }
}