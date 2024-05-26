using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEPCO.Application.Constants;

public static class CacheKeysConstants
{
    public static CacheKey initCacheKey =  new () {Key = "initCacheKey" , KeyType = KeyType.SingleObject };
}


public class CacheKey
{
    public string Key { get; set; }
    public KeyType KeyType { get; set; }
}


public enum KeyType
{
    SingleObject = 1,
    List = 2
}
