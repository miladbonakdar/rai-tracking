using Application.Interfaces;
using Domain.Interfaces;

namespace Infrastructure
{
    public class ApplicationCommandFactory : IApplicationCommandFactory
    {
        public IApplicationCommand Create()
        {
            throw new System.NotImplementedException();
        }
    }
}