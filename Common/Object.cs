using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Common
{
    public static class Object
    {
        public static bool IsIn<T>(this T obj, params T[] collection)
        {
            return collection.Contains(obj);
        }
    }
}
