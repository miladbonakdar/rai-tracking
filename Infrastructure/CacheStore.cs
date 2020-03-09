using System;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Enums;
using Application.Interfaces;
using Infrastructure.Interfaces;
using Newtonsoft.Json;
using Serilog;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Infrastructure
{
    class CacheStore : ICacheStore
    {
        private readonly ICacheMultiplexer _multiplexer;
        private readonly ILogger _logger;

        private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public CacheStore(ICacheMultiplexer multiplexer, ILogger logger)
        {
            _multiplexer = multiplexer;
            _logger = logger;
        }

        public async Task<TCache> StoreAndGetAsync<TCache>(string key, Func<Task<TCache>> cacheFactory,
            CacheDuration duration = CacheDuration.Eternal)
        {
            string oldCache = await _multiplexer.Db.StringGetAsync(key);

            _logger.Information($"cache object: {typeof(TCache).Name} \n");
            if (string.IsNullOrWhiteSpace(oldCache))
            {
                try
                {
                    var toBeCached = await cacheFactory();
                    var result = await StoreAsync(key, toBeCached, duration);
                    return result;
                }
                catch (Exception e)
                {
                    _logger.Fatal($"create object to be cached failed: {typeof(TCache).Name} \n" +
                                  $"exception : {e}");
                    throw;
                }
            }

            return JsonSerializer.Deserialize<TCache>(oldCache, _serializerOptions);
        }

        public async Task<TCache> StoreAsync<TCache>(string key, TCache toBeCached,
            CacheDuration duration = CacheDuration.Eternal)
        {
            try
            {
                string objectString = JsonSerializer.Serialize(toBeCached, _serializerOptions);
                await _multiplexer.Db.StringSetAsync(key, objectString,
                    duration == CacheDuration.Eternal
                        ? (TimeSpan?) null
                        : TimeSpan.FromSeconds((int) duration));
                return toBeCached;
            }
            catch (Exception e)
            {
                _logger.Fatal($"object cached failed: {typeof(TCache).Name} \n" +
                              $"exception : {e}");
                throw;
            }
        }


        public async Task<bool> RemoveAsync(string key)
        {
            try
            {
                return await _multiplexer.Db.KeyDeleteAsync(key);
            }
            catch (Exception e)
            {
                _logger.Fatal($"object remove key failed with key: {key} \n" +
                              $"exception : {e}");
                throw;
            }
        }
    }
}