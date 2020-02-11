using StackExchange.Redis;

namespace Infrastructure.Interfaces
{
    internal interface ICacheMultiplexer
    {
        ConnectionMultiplexer Connection { get; }

        IDatabase Db { get; }

        IServer Server { get; }
    }
}