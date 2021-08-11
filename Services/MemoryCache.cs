using Microsoft.Extensions.Caching.Memory;
using RockFood.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public class MemoryCache<TItem>: MemoryCachable<TItem>
    {
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions()
        {
            SizeLimit = 5
        });
        private readonly object _locker = new object();
        public TItem GetOrCreate(object key, Func<TItem> createItem, out string message)
        {            
            TItem cacheEntry;
            lock (_locker)
            {
                message = "Read from cache ";
                if (!_cache.TryGetValue(key, out cacheEntry))
                {                
                    cacheEntry = createItem();
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSize(1).SetSlidingExpiration(TimeSpan.FromSeconds(120));
                    _cache.Set(key, cacheEntry, cacheEntryOptions);
                    message = "Write in cache ";
                }
            }
            return cacheEntry;
        } 
    }
}
