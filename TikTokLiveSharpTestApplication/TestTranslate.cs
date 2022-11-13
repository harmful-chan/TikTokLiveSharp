using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TikTokLiveSharp.Tools.Toolset;
using TikTokLiveSharp.Win.Helper;

namespace TikTokLiveSharpTestApplication
{
    internal class TestTranslate : TestBase, ITest
    {
        public void Run(string[] args)
        {
            string msg = "The .NET Core !Desktop !Runtime! also includes the " +
                ".NET Core ?Runtime??? (starting with .NET Core 3.0.0-preview2). " +
                "Resource installation failed, please restart.";
            LogHelper.Info(msg);
            var str = Translate.GetGoogleApiResAsync(msg, proxy: new Uri("http://127.0.0.1:1080/")).Result ;
            LogHelper.Info(str);
        }

        public async Task RunAsync(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
