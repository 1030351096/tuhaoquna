using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TuHaoQuNa.Core.Utility
{
    /// <summary>
    /// Fetch 的摘要说明。
    /// </summary>
    public class Fetch
    {
        /// <summary>
        /// 获取Url后面的值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Get(string name, string defaultValue = "")
        {
            string text1 = HttpContext.Current.Request.QueryString[name];
            return ((text1 == null) ? defaultValue : text1);
        }

        /// <summary>
        /// 判断表单Post过来的值是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ExistPost(string name)
        {
            string text1 = HttpContext.Current.Request.Form[name];
            return (text1 != null);
        }

        /// <summary>
        /// 获取表单Post过来的值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Post(string name)
        {
            string text1 = HttpContext.Current.Request.Form[name];
            return ((text1 == null) ? "" : text1);
        }

        /// <summary>
        /// 获取Url后面的值，如.....aspx?productid=2将获取到"2"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int GetId(string name)
        {
            int id = 0;
            int.TryParse(Get(name), out id);
            return id;
        }

        /// <summary>
        /// 获取Url后面的值，如.....aspx?productid=2将获取到"2"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int GetId(string name, int defaultValue)
        {
            name = Get(name);
            if (name != "")
                int.TryParse(name, out defaultValue);
            return defaultValue;
        }

        public static int PostId(string name)
        {
            int id = 0;
            int.TryParse(Post(name), out id);
            return id;
        }

        public static int PostId(string name, int defaultValue)
        {
            name = Post(name);
            if (name != "")
                int.TryParse(name, out defaultValue);
            return defaultValue;
        }

        /// <summary>
        /// 获取表单Post过来的值，如表单checkboxlist传ids:2,3,5过来，将是int[]{2,3,4}
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int[] PostIds(string name)
        {
            var ids = Post(name);
            List<int> result = new List<int>();
            int id = 0;
            var array = ids.Split(',');
            foreach (var a in array)
                if (int.TryParse(a.Trim(), out id))
                    result.Add(id);

            return result.ToArray();
        }

        /// <summary>
        /// 获取Url过来的值，如.....aspx?productid=2&productid=3，将是int[]{2,3}
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int[] GetIds(string name)
        {
            var ids = Get(name);
            List<int> result = new List<int>();
            int id = 0;
            var array = ids.Split(',');
            foreach (var a in array)
                if (int.TryParse(a.Trim(), out id))
                    result.Add(id);

            return result.ToArray();
        }

        /// <summary>
        /// 获取当前页面的Url
        /// </summary>
        public static string CurrentUrl
        {
            get
            {
                return HttpContext.Current.Request.Url.ToString();
            }
        }

        /// <summary>
        /// 获取当前页面的主域，如www.GMS.com主域是GMS.com
        /// </summary>
        public static string ServerDomain
        {
            get
            {
                string urlHost = HttpContext.Current.Request.Url.Host.ToLower();
                string[] urlHostArray = urlHost.Split(new char[] { '.' });
                if ((urlHostArray.Length < 3) || RegExp.IsIp(urlHost))
                {
                    return urlHost;
                }
                string urlHost2 = urlHost.Remove(0, urlHost.IndexOf(".") + 1);
                if ((urlHost2.StartsWith("com.") || urlHost2.StartsWith("net.")) || (urlHost2.StartsWith("org.") || urlHost2.StartsWith("gov.")))
                {
                    return urlHost;
                }
                return urlHost2;
            }
        }

        /// <summary>
        /// 获取访问用户的IP
        /// </summary>
        public static string UserIp
        {
            get
            {
                string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                switch (result)
                {
                    case null:
                    case "":
                        result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                        break;
                }
                if (!RegExp.IsIp(result))
                {
                    return "127.0.0.1";
                }
                return result;
            }
        }

        /// <summary>
        /// 返回指定IP是否在指定的IP数组所限定的范围内, IP数组内的IP地址可以使用*表示该IP段任意, 例如192.168.1.*
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="iparray"></param>
        /// <returns></returns>
        public static bool InIPArray(string ip, string[] iparray)
        {
            if (iparray.Length == 0)
                return true;
            string[] userip = ip.Split('.');

            for (int ipIndex = 0; ipIndex < iparray.Length; ipIndex++)
            {
                string[] tmpip = iparray[ipIndex].Split('.');
                int r = 0;
                for (int i = 0; i < tmpip.Length; i++)
                {
                    if (tmpip[i] == "*")
                        return true;

                    if (userip.Length > i)
                    {
                        if (tmpip[i] == userip[i])
                            r++;
                        else
                            break;
                    }
                    else
                        break;
                }

                if (r == 4)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 返回 URL 字符串的编码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>编码结果</returns>
        public static string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// 返回 URL 字符串的编码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>解码结果</returns>
        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        public static T JsonToObject<T>(string json)
        {
            //提交参数是对象
            if (json != null)
                if (json.StartsWith("{") && json.EndsWith("}"))
                {
                    JObject jsonBody = JObject.Parse(json);
                    if (jsonBody.Count > 0)
                        return jsonBody.ToObject<T>();
                }
                //提交参数是数组
                else if (json.StartsWith("[") && json.EndsWith("]"))
                {
                    JArray jsonRsp = JArray.Parse(json);
                    //if (jsonRsp.Count > 0)
                    return jsonRsp.ToObject<T>();
                }
            return default(T);
        }

    }
}
