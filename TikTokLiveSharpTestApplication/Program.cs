using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using TikTokLiveSharp.Client;
using TikTokLiveSharp.Client.Proxy;
using TikTokLiveSharp.Models;
using TikTokLiveSharp.Tools.Toolset;
using TikTokLiveSharp.Win.Helper;

namespace TikTokLiveSharpTestApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            //new TestTikTokLiveClient().RunAsync(args).GetAwaiter().GetResult();
            new TestTranslate().Run(args);
            /*
            NameObject nameObject1 = NameObject.GetNameObject("ttc-win.snapshot-202209132318.[yoyo.babies][0].exe");
            NameObject nameObject2 = NameObject.GetNameObject("ttc-win.snapshot-202209132318.[yoyo.babies][1080].exe");
            NameObject nameObject3 = NameObject.GetNameObject("ttc-win.snapshot-202209132318.[yoyo.babies].exe");
            NameObject nameObject4 = NameObject.GetNameObject("ttc-win.snapshot-202209132318.[1080].exe");
            NameObject nameObject5 = NameObject.GetNameObject("ttc-win.snapshot-202209132318.exe");
            */
        }

    }
}
