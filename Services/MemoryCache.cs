using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public class MemoryCache<TItem>
    {
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions()
        {
            SizeLimit = 5
        });
        public TItem GetOrCreate(object key, Func<TItem> createItem)
        {
            TItem cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))
            {
                cacheEntry = createItem();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSize(1).SetSlidingExpiration(TimeSpan.FromSeconds(120));                          
                _cache.Set(key, cacheEntry, cacheEntryOptions);
                Console.Write("Write in cach ");
            }
            else
            {
                Console.Write("Read from cach ");
            }
            return cacheEntry;
        } 
    }
}
