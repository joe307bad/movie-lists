using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLists.API.Helpers
{
    public static class DictionaryToQueryString
    {
        public static string ToQueryString(this Dictionary<string, string> source)
        {
            return "?" + string.Join("&", source.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value)));
        }
    }
}
