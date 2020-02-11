using StackExchange.Redis;

namespace Infrastructure.Interfaces
{
    public interface ICacheMultiplexer
    {
        ConnectionMultiplexer Connection { get; }

        IDatabase Db { get; }

        IServer Server { get; }
    }
}