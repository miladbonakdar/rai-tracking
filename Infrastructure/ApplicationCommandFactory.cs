using Application.Interfaces;
using Domain.Interfaces;

namespace Infrastructure
{
    class ApplicationCommandFactory : IApplicationCommandFactory
    {
        public IApplicationCommand Create()
        {
            throw new System.NotImplementedException();
        }
    }
}