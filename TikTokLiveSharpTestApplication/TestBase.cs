using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TikTokLiveSharp.Win.Helper;

namespace TikTokLiveSharpTestApplication
{
    abstract class TestBase
    {
        public TestBase()
        {
            // 日志
            LogHelper.NewLineHandler += (sender, msg) =>
            {
                Console.WriteLine();
                Console.Write(msg);
            };
            LogHelper.AppendHandler += (sender, msg) =>
            {
                Console.Write(msg);
            };
        }
    }
}
