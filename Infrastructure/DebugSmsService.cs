using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Serilog;
using SharedKernel;

namespace Infrastructure
{
    class DebugSmsService : ISmsService
    {
        private readonly ILogger _logger;

        public DebugSmsService(ILogger logger)
        {
            _logger = logger;
        }

        public Task<Result<bool>> SendAsync(string number, string content)
        {
            WarnDebug();
            Console.WriteLine($"sms to number {number} content : {content}");
            _logger.Information($"sms send to number {number} and content is {content}");
            return Task.FromResult(Result<bool>.Success());
        }

        public Task<Result<bool>> SendManyAsync(IEnumerable<string> numbers, string content)
        {
            WarnDebug();
            var enumerable = numbers.ToList();
            Console.WriteLine($"sms to numbers {string.Join(',',enumerable)} content : {content}");
            _logger.Information($"bulk sms send to numbers {string.Join(',',enumerable)} and content is {content}");
            return Task.FromResult(Result<bool>.Success());
        }

        private void WarnDebug()
        {
            var preColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("THIS IS SMS SERVICE FOR TEST PLEASE MAKE SURE NOT TO USE IN PRODUCTION");
            Console.ForegroundColor = preColor;
        }

        public Task<SmsServiceInfoDto> GetStatusAsync()
        {
            return Task.FromResult(new SmsServiceInfoDto
            {
                ExpireDate = DateTime.Now.AddYears(1),
                Type = "Debug sms service",
                RemainingCredit = Int64.MaxValue,
            });
        }
    }
}