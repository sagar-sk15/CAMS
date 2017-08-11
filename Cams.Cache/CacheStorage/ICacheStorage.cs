﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Cache.CacheStorage
{
    public interface ICacheStorage
    {
        void Remove(string key);
        void Store(string key, object data);
        T Retrieve<T>(string storageKey);
    }
}
