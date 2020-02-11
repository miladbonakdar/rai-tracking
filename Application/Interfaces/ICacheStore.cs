﻿using System;
using System.Threading.Tasks;
using Application.Constants;
using SharedKernel;

namespace Application.Interfaces
{
    public interface ICacheStore
    {
        Task<TCache> StoreAndGetAsync<TCache>(string key, Func<Task<TCache>> cacheFactory, 
            int duration = CacheDuration.Eternal);
        
        Task<TCache> StoreAsync<TCache>(string key, TCache toBeCached, 
            int duration = CacheDuration.Eternal);
    }
}