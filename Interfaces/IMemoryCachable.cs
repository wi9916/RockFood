using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Interfaces
{
    public interface IMemoryCachable<TItem>
    {
        TItem GetOrCreate(object key, Func<TItem> createItem, out string message);
    }
}
