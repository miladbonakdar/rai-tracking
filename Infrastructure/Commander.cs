using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Domain.Interfaces;
using SharedKernel;

namespace Infrastructure
{
    class Commander : ICommander
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISmsService _smsService;

        public Commander( IUnitOfWork unitOfWork,
            ISmsService smsService)
        {
            _unitOfWork = unitOfWork;
            _smsService = smsService;
        }

        public async Task<Result<bool>> SendAsync<TCommand>(TCommand command) where TCommand : IApplicationCommand
        {
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