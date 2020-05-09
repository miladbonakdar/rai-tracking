using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Configurations;
using Application.Interfaces;
using Kavenegar;
using Kavenegar.Core.Exceptions;
using Serilog.Core;
using SharedKernel;

namespace Infrastructure
{
    class SmsService : ISmsService
    {
        private readonly SmsServiceSetting _setting;
        private readonly Logger _logger;
        private readonly KavenegarApi _api;

        public SmsService(SmsServiceSetting setting, Logger logger)
        {
            _setting = setting;
            _logger = logger;
            _api = new KavenegarApi(_setting.ApiKey);
        }

        public async Task<Result<bool>> SendAsync(string number, string content)
        {
            try
            {
                var result
                    = await _api.Send(_setting.ServiceNumber, new List<string> {number}, content);
                return Result<bool>.Success("اس ام اس ارسال شد");
            }
            catch (ApiException ex)
            {
                _logger.Error(ex, "problem in sending message to number" + number);
                throw;
            }
            catch (HttpException ex)
            {
                _logger.Error(ex, "problem in connecting to the sms service");
                throw new ApplicationException("سرویس اس ام اس در دسترس نمی باشد.");
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
                var result
                    = await _api.Send(_setting.ServiceNumber, numbers.ToList(), content);
                return Result<bool>.Success("اس ام اس ارسال شد");
            }
            catch (ApiException ex)
            {
                _logger.Error(ex, "problem in sending bulk message");
                throw;
            }
            catch (HttpException ex)
            {
                _logger.Error(ex, "problem in connecting to the sms service");
                throw new ApplicationException("سرویس اس ام اس در دسترس نمی باشد.");
            }
            catch (Exception e)
            {
                _logger.Fatal(e, "something bad happen when sending bulk message");
                throw;
            }
        }
    }
}