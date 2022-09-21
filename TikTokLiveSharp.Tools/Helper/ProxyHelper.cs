using System;
using System.Net;
using System.Threading.Tasks;
using TikTokLiveSharp.Tools.Toolset;

namespace TikTokLiveSharp.Win.Helper
{


    public static class ProxyHelper
    {
        private class Proxy
        {
            public string Protocol { get; set; }
            public string Host { get; set; }
            public int Port { get; set; }
            public string Description { get; set; }
        }
        private static Proxy[] _proxies = new Proxy[]
        {
            new Proxy{ Protocol = "http", Host = "127.0.0.1", Port = 8888, Description = "Fiddler" },
            new Proxy{ Protocol = "http", Host = "127.0.0.1", Port = 3213, Description = "Astrill VPN" },
            new Proxy{ Protocol = "http", Host = "127.0.0.1", Port = 1080, Description = "SS/SSR" },
        };

        public static async Task<Uri> CheckAvailableProxy()
        {
            foreach (var item in _proxies)
            {
                if (await Check(item.Host, item.Port, item.Description))
                {
                    return new Uri($"{item.Protocol}://{item.Host}:{item.Port}");
                }
            }


            var http_proxy = Environment.GetEnvironmentVariable("http_proxy", EnvironmentVariableTarget.User);
            if (!string.IsNullOrEmpty(http_proxy))
            {
                if (await Check(http_proxy, "http_proxy"))
                {
                    return new Uri(http_proxy);
                }
            }

            var https_proxy = Environment.GetEnvironmentVariable("https_proxy", EnvironmentVariableTarget.User);
            if (!string.IsNullOrEmpty(https_proxy))
            {
                if (await Check(https_proxy, "https_proxy"))
                {
                    return new Uri(https_proxy);
                }
            }

            return null;
        }

        public static async Task<bool> DirectTiktok()
        {
            IPHostEntry iPHostEntry = Dns.GetHostEntry("www.tiktok.com");
            
            bool flag = false;
            if( iPHostEntry.AddressList.Length > 0)
            {
                string ip = iPHostEntry.AddressList[0].ToString();
                return await Check(ip, 80, "www.tiktok.com");
            }
           

            return flag;
        }
        public static async Task<bool> Check(string uri, string msg)
        {
            Uri url = new Uri(uri);
            if (url.IsAbsoluteUri)
            {
                return await Check(url.Host, url.Port, msg);
            }
            return false;
        }
        public static async Task<bool> Check(string ip, int port, string msg)
        {
            var time = await Tcping.Ping5Async(ip, port, 2);

            LogHelper.Info($"check {ip}:{port} ... ");
            LogHelper.Append(time < 10.00 ? "active" : "unactive");
            LogHelper.Append($" [{msg}], time {time:000.000} S");

            return time < 10.00;
        }

    }
}
