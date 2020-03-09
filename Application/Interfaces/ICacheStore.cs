using System;
using System.Threading.Tasks;
using Application.Enums;
using SharedKernel;

namespace Application.Interfaces
{
    public interface ICacheStore
    {
        Task<TCache> StoreAndGetAsync<TCache>(string key, Func<Task<TCache>> cacheFactory,
            CacheDuration duration = CacheDuration.Eternal);

        Task<TCache> StoreAsync<TCache>(string key, TCache toBeCached,
            CacheDuration duration = CacheDuration.Eternal);

        Task<bool> RemoveAsync(string key);
    }
}