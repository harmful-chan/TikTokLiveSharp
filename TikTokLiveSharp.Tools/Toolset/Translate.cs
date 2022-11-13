using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Text.RegularExpressions;

namespace TikTokLiveSharp.Tools.Toolset
{
    public static class Translate
    {

        private static void SetQ(in HttpWebRequest httpWebRequest)
        {
            httpWebRequest.Method = "GET";
            httpWebRequest.KeepAlive = false;
            httpWebRequest.ProtocolVersion = HttpVersion.Version10;
            httpWebRequest.Headers.Add("Accept-Encoding", "utf-8");
            httpWebRequest.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
            httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            httpWebRequest.ContentType = "text/html; charset=utf-8";
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = 8000;
            httpWebRequest.ReadWriteTimeout = 8000;
            httpWebRequest.ProtocolVersion = HttpVersion.Version11;
        }

        public static string GetQ(in HttpWebResponse httpWebResponse)
        {
            Stream myResponseStream = httpWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string hq = myStreamReader.ReadToEnd();
            return hq;
        }
        


        /// <summary>
        /// 根据api获取翻译
        /// </summary>
        /// <param name="str">需要翻译的内容</param>
        /// <param name="Translattype">目标翻译类型:传入使用GetRequestLang所获得的值</param>
        /// <returns></returns>
        public static async Task<string> GetGoogleApiResAsync(string str, string dstType = "zh-CN", string srcType = "auto", Uri proxy = null)
        {
            string res = null;
            await Task.Run(() =>
            {
                
                string raw = Regex.Replace(str, @"\b\s+\b", " "); // 

                string[] sraw = raw.Split(" ");
                for (int i = 0; i < sraw.Length -1; i++)
                {
                    int len = sraw[i].Length;
                    if (sraw[i].EndsWith(".") || sraw[i].EndsWith("!") || sraw[i].EndsWith("?"))
                    {
                        sraw[i] = sraw[i].Remove(len-1) + ",";
                    }
                }
                raw = sraw[0];
                for (int i = 1; i < sraw.Length; i++)
                {
                    raw += " " + sraw[i];
                }

                raw = HttpUtility.UrlEncode(raw, Encoding.UTF8);
                dstType = dstType ?? "zh-CN";
                srcType = srcType ?? "auto";
                string apiurl = "http://translate.google.com/translate_a/single?client=gtx&dt=t&dj=1&ie=UTF-8&sl="+srcType+"&tl=" + dstType + "&q=" + raw;
 
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(apiurl);
                if( proxy != null)
                {
                    myRequest.Proxy = new WebProxy(proxy); 
                }
                SetQ(in myRequest);
                HttpWebResponse response = null;
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        response = (HttpWebResponse)myRequest.GetResponse();
                        string hq = GetQ(response);
                        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(hq);
                        res = data.sentences[0].trans.ToString();
                    }
                    catch(Exception) 
                    { 
                        if( response != null)
                        {
                            response.Close(); 

                        }
                        continue;
                    }
                    break;
                }
            });
            return res;
        }
    }
}
