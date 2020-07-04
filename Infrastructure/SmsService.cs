using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Configurations;
using Application.DTO;
using Application.Interfaces;
using Serilog;
using SharedKernel;

namespace Infrastructure
{
    class SmsService : ISmsService
    {
        private readonly SmsServiceSetting _setting;
        private readonly ILogger _logger;
        private readonly KavenegarApi _api;

        public SmsService(SmsServiceSetting setting, ILogger logger)
        {
            _setting = setting;
            _logger = logger;
            _api = new KavenegarApi(_setting.ApiKey);
        }

        public async Task<Result<bool>> SendAsync(string number, string content)
        {
            try
            {
                await _api.Send(_setting.ServiceNumber, number, content);
                _logger.Information($"sms send to number {number} and content is {content}");
                return Result<bool>.Success("اس ام اس ارسال شد");
            }
            catch (KavehnegarApiException ex)
            {
                _logger.Error(ex, "problem in sending message to number" + number);
                throw;
            }
            catch (Exception e)
            {
                _logger.Fatal(e, "something bad happen when sending message to number " + number);
                throw;
            }
        }

        public async Task<Result<bool>> SendManyAsync(IEnumerable<string> numbers, string content)
        {
            try
            {
                var enumerable = numbers.ToList();
                await _api.SendMany(_setting.ServiceNumber, enumerable, content);
                _logger.Information($"bulk sms send to numbers {string.Join(',',enumerable)} and content is {content}");
                return Result<bool>.Success("اس ام اس ها ارسال شد");
            }
            catch (KavehnegarApiException ex)
            {
                _logger.Error(ex, "problem in sending bulk message");
                throw;
            }
            catch (Exception e)
            {
                _logger.Fatal(e, "something bad happen when sending bulk message");
                throw;
            }
        }


        public async Task<SmsServiceInfoDto> GetStatusAsync()
        {
            var information = await _api.AccountInfo();
            return new SmsServiceInfoDto
            {
                ExpireDate = information.ExpireDate,
                Type = information.Type,
                RemainingCredit = information.RemainingCredit,
            };
        }
    }
}