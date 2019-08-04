using System.Collections.Generic;

namespace Common
{
    public static class Int32Extensions
    {
        public static int[] To(this int start, int end, int step = 1)
        {
            if (start == end)
                return new[] { start };
            var result = new List<int>();
            if (start < end)
            {
                for (var i = start; i <= end; i += step)
                {
                    result.Add(i);
                }
            }
            else
            {
                for (var i = start; i >= end; i -= step)
                {
                    result.Add(i);
                }
            }
            return result.ToArray();
        }
    }
}