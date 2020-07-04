using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Enums;
using Application.Interfaces;
using Domain;
using Domain.Interfaces;
using Domain.Enums;
using SharedKernel;
using SharedKernel.Exceptions;

namespace Infrastructure
{
    class Commander : ICommander
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISmsService _smsService;
        private readonly ICacheStore _cacheStore;

        public Commander(IUnitOfWork unitOfWork,
            ISmsService smsService, ICacheStore cacheStore)
        {
            _unitOfWork = unitOfWork;
            _smsService = smsService;
            _cacheStore = cacheStore;
        }

        private async Task GuardForDuplicateRequests<TCommand>(TCommand command,CacheDuration duration) where TCommand : IApplicationCommand
        {
            if(IgnoreForDuplicatedCheck().Contains(command.CommandType)) return;
            var key = $"Command_Request_Admin{command.AdminId.ToString()}_Agent_{command.AgentId}_Command{command.CommandType.ToString()}";
            var data = await _cacheStore.GetAsync<string>(key);
            if(data != null) throw new ConflictedException("این درخواست پیشتر ارسال شده است لطفا با اندکی تاخیر دوباره امتحان کنید. بیشترین زمان انتظار 10 دقیقه می باشد");
            await _cacheStore.StoreAsync(key, "sent", duration);
        }

        private IEnumerable<CommandType> IgnoreForDuplicatedCheck()
        {
            yield return CommandType.NewMission;
            yield return CommandType.EditMission;
            yield return CommandType.SetSetting;
        }

        public async Task<Result<bool>> SendAsync<TCommand>(TCommand command) where TCommand : IApplicationCommand
        {
            await GuardForDuplicateRequests(command,CacheDuration.FromMin10);
            var commandMessage = command.Message;
            await _smsService.SendAsync(command.PhoneNumber, commandMessage);
            await _unitOfWork.CompleteAsync(ctx =>
            {
                var cmd = new Command(command.AgentId, command.CommandType, DateTime.Now);
                cmd.SetData(command.Message);
                ctx.Commands.Add(cmd);
            });
            return Result<bool>.Success();
        }
    }
}