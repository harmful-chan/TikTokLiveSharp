using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TikTokLiveSharpTestApplication
{
    internal interface ITest
    {
        void Run(string[] args);
        Task RunAsync(string[] args);
    }
}
