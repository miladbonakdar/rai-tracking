using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using SharedKernel;

namespace Infrastructure
{
//https://github.com/mberneti/Kavenegar.Core
    class SmsService : ISmsService
    {
        public Task<Result<bool>> SendAsync(string number, string content)
        {
            Console.WriteLine($"to : {number} \n content : {content}");
            return Task.FromResult(Result<bool>.Error());
        }

        public Task<Result<bool>> SendManyAsync(IEnumerable<string> numbers, string content)
        {
            foreach (var number in numbers)
                Console.WriteLine($"to : {number} \n content : {content}");
            return Task.FromResult(Result<bool>.Error());
        }
    }
}