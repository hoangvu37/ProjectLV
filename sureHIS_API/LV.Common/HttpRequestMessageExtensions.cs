using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

//Tham khảo tại trang https://weblog.west-wind.com/posts/2013/Apr/15/WebAPI-Getting-Headers-QueryString-and-Cookie-Values
namespace LV.Common
{

    /// <summary>
    /// Extends the HttpRequestMessage collection
    /// </summary>
    public static class HttpRequestMessageExtensions
    {

        /// <summary>
        /// Returns a dictionary of QueryStrings that's easier to work with 
        /// than GetQueryNameValuePairs KevValuePairs collection.
        /// If you need to pull a few single values use GetQueryString instead.
        /// <para>Phân tách chuỗi query request đến ASP.NET WEB API thành dictionary có Key là tên tham số và Value là giá trị của tham số</para>
        /// <para>Nếu có ít tham số thì dùng Request.GetQueryString thay vì phương thức này</para>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetQueryStrings(this HttpRequestMessage request)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var item in request.GetQueryNameValuePairs())
            {
                if (dic.ContainsKey(item.Key))
                {
                    dic[item.Key] = item.Value;
                }
                else
                {
                    dic.Add(item.Key, item.Value);
                }
            }
            return dic;
        }

        /// <summary>
        /// Returns an individual querystring value
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetQueryString(this HttpRequestMessage request, string key)
        {
            // IEnumerable<KeyValuePair<string,string>> - right!
            var queryStrings = request.GetQueryNameValuePairs();
            if (queryStrings == null)
                return null;

            var match = queryStrings.FirstOrDefault(kv => string.Compare(kv.Key, key, true) == 0);
            if (string.IsNullOrEmpty(match.Value))
                return null;

            return match.Value;
        }

        /// <summary>
        /// Returns an individual HTTP Header value
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetHeader(this HttpRequestMessage request, string key)
        {
            IEnumerable<string> keys = null;
            if (!request.Headers.TryGetValues(key, out keys))
                return null;

            return keys.First();
        }

       
    }
}