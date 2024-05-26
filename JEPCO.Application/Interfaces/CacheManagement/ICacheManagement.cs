using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEPCO.Application.Interfaces.CacheManagement
{
    public interface ICacheManagement
    {
        T GetData<T>(string cacheKey);
        bool SetData<T>(string cacheKey, T value, DateTimeOffset expirationTime);
        object RemoveData(string key);
    }
}
