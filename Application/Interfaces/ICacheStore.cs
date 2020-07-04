using System;
using System.Threading.Tasks;
using Application.Enums;

namespace Application.Interfaces
{
    public interface ICacheStore
    {
        Task<TCache> StoreAndGetAsync<TCache>(string key, Func<Task<TCache>> cacheFactory,
            CacheDuration duration = CacheDuration.Eternal);

        Task<TCache> StoreAsync<TCache>(string key, TCache toBeCached,
            CacheDuration duration = CacheDuration.Eternal);
        
        Task<TCache> GetAsync<TCache>(string key);

        Task<bool> RemoveAsync(string key);
    }
}