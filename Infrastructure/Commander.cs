using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces;
using SharedKernel;

namespace Infrastructure
{
    class Commander : ICommander
    {
        private readonly IApplicationCommandFactory _factory;
        private readonly ICommandRepository _commandRepository;
        private readonly ISmsService _smsService;

        public Commander(IApplicationCommandFactory factory,ICommandRepository commandRepository,
            ISmsService smsService)
        {
            _factory = factory;
            _commandRepository = commandRepository;
            _smsService = smsService;
        }

        public Task<Result<bool>> SendAsync<TCommand>(TCommand command) where TCommand : IApplicationCommand
        {
            var commandMessage = command.Message;
            _smsService.SendAsync(command.PhoneNumber, commandMessage);
            throw new NotImplementedException();
        }

        public Task<Result<bool>> SendAsync<TCommand>(Func<IApplicationCommandFactory, TCommand> commandFactory) where TCommand : IApplicationCommand
        {
            var command = commandFactory(_factory);
            return SendAsync(command);
        }
    }
}