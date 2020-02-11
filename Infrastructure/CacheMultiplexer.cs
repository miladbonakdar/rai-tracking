using System;
using Infrastructure.Interfaces;
using StackExchange.Redis;

namespace Infrastructure
{
    class CacheMultiplexer : ICacheMultiplexer
    {
        private readonly Lazy<ConnectionMultiplexer> _lazyConnection;
        
        public CacheMultiplexer()
        {
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { InfrastructureModule.RedisConnectionString },
                KeepAlive = 60,
                AllowAdmin = true
            };

            _lazyConnection = new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect(configurationOptions));
        }
        public ConnectionMultiplexer Connection => _lazyConnection.Value;

        public IDatabase Db => Connection.GetDatabase();

        public IServer Server => Connection.GetServer(InfrastructureModule.RedisConnectionString);
    }
}