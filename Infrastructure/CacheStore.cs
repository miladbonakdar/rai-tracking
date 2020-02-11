using System;
using System.Threading.Tasks;
using Application.Constants;
using Application.Interfaces;
using Infrastructure.Interfaces;
using Newtonsoft.Json;
using Serilog;

namespace Infrastructure
{
    public class CacheStore : ICacheStore
    {
        private readonly ICacheMultiplexer _multiplexer;
        private readonly ILogger _logger;

        public CacheStore(ICacheMultiplexer multiplexer, ILogger logger)
        {
            _multiplexer = multiplexer;
            _logger = logger;
        }

        public async Task<TCache> StoreAndGet<TCache>(string key, Func<Task<TCache>> cacheFactory,
            int duration = CacheDuration.Eternal)
        {
            string oldCache = await _multiplexer.Db.StringGetAsync(key);

            _logger.Information($"cache object: {typeof(TCache).Name} \n");
            if (string.IsNullOrWhiteSpace(oldCache))
            {
                try
                {
                    var toBeCached = await cacheFactory();
                    var result = await Store(key, toBeCached, duration);
                    return result;
                }
                catch (Exception e)
                {
                    _logger.Fatal($"create object to be cached failed: {typeof(TCache).Name} \n" +
                                  $"exception : {e}");
                    throw;
                }
            }

            return JsonConvert.DeserializeObject<TCache>(oldCache);
        }

        public async Task<TCache> Store<TCache>(string key, TCache toBeCached,
            int duration = CacheDuration.Eternal)
        {
            try
            {
                string objectString = JsonConvert.SerializeObject(toBeCached);
                await _multiplexer.Db.StringSetAsync(key, objectString);
                return toBeCached;
            }
            catch (Exception e)
            {
                _logger.Fatal($"object cached failed: {typeof(TCache).Name} \n" +
                              $"exception : {e}");
                throw;
            }
        }
    }
}