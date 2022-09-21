using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TikTokLiveSharp.Client.Proxy;
using TikTokLiveSharp.Client;
using TikTokLiveSharp.Models;
using TikTokLiveSharp.Win.Helper;

namespace TikTokLiveSharpTestApplication
{
    internal class TestTikTokLiveClient : TestBase, ITest
    {

        public TestTikTokLiveClient() : base() { }
        public void Run(string[] args)
        {
            ;
        }
        public async Task RunAsync(string[] args)
        {



            // 代理
            Uri uri = null;
            TikTokLiveClient client = null;
            if (!await ProxyHelper.DirectTiktok())
            {
                uri = await ProxyHelper.CheckAvailableProxy();
                RotatingProxy rotatingProxy = new RotatingProxy(isEnabled: true, RotationSettings.PINNED, uri.AbsoluteUri);
                client = new TikTokLiveClient("fbs.students", proxyHandler: rotatingProxy);
            }
            else
            {
                client = new TikTokLiveClient("fbs.students");
            }

            // TikTokLiveClient
            client.OnCommentRecieved += Client_OnCommentRecieved;
            client.OnFollow += Client_OnFollow;
            client.OnShare += Client_OnShare;
            client.OnSubscribe += Client_OnSubscribe;
            client.OnJoin += Client_OnJoin;
            client.OnLike += Client_OnLike;
            client.OnGiftRecieved += Client_OnGiftRecieved;
            client.OnEmoteRecieved += Client_OnEmoteRecieved;
            client.OnLikesRecieved += Client_OnLikesRecieved;
            client.OnViewerCountUpdated += Client_OnViewerCountUpdated;
            client.OnConnected += Client_OnConnected;
            client.OnDisconnected += Client_OnDisconnected;
            client.OnLiveEnded += Client_OnLiveEnded;

            try
            {
                client.Run(new System.Threading.CancellationToken());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void Client_OnLiveEnded(object sender, EventArgs e)
        {
            SetConsoleColor(ConsoleColor.White);
            Console.WriteLine("Live ended!");
        }

        private void Client_OnDisconnected(object sender, TikTokLiveSharp.Events.ConnectionEventArgs e)
        {
            SetConsoleColor(ConsoleColor.White);
            Console.WriteLine($"Disconnected from live!");
        }

        private void Client_OnConnected(object sender, TikTokLiveSharp.Events.ConnectionEventArgs e)
        {
            SetConsoleColor(ConsoleColor.White);
            Console.WriteLine($"Connected to live!");
        }

        private void Client_OnViewerCountUpdated(object sender, WebcastRoomUserSeqMessage e)
        {
            SetConsoleColor(ConsoleColor.Cyan);
            Console.WriteLine($"Viewer count is: {e.viewerCount}");
        }

        private void Client_OnLikesRecieved(object sender, WebcastLikeMessage e)
        {
            SetConsoleColor(ConsoleColor.DarkYellow);
            Console.WriteLine($"{e.User.uniqueId} liked {e.totalLikeCount}x!");
        }

        private void Client_OnEmoteRecieved(object sender, WebcastEmoteChatMessage e)
        {
            SetConsoleColor(ConsoleColor.DarkGreen);
            Console.WriteLine($"{e.User.uniqueId} sent {e.Emote.emoteId}!");
        }

        private void Client_OnGiftRecieved(object sender, WebcastGiftMessage e)
        {
            SetConsoleColor(ConsoleColor.Magenta);
            Console.WriteLine($"{e.User.uniqueId} sent {e.repeatCount}x {e.giftDetails.giftName}!");
        }

        private void Client_OnLike(object sender, User e)
        {
            SetConsoleColor(ConsoleColor.Red);
            Console.WriteLine($"{e.uniqueId} liked!");
        }

        private void Client_OnJoin(object sender, User e)
        {
            SetConsoleColor(ConsoleColor.Green);
            Console.WriteLine($"{e.uniqueId} joined!");
        }

        private void Client_OnSubscribe(object sender, WebcastMemberMessage e)
        {
            SetConsoleColor(ConsoleColor.DarkCyan);
            Console.WriteLine($"{e.User.uniqueId} subscribed!");
        }

        private void Client_OnShare(object sender, TikTokLiveSharp.Events.ShareEventArgs e)
        {
            SetConsoleColor(ConsoleColor.Blue);
            Console.WriteLine($"{e.User.uniqueId} shared!");
        }

        private void Client_OnFollow(object sender, User e)
        {
            SetConsoleColor(ConsoleColor.DarkRed);
            Console.WriteLine($"{e.uniqueId} followed!");
        }

        private void Client_OnCommentRecieved(object sender, WebcastChatMessage e)
        {
            SetConsoleColor(ConsoleColor.Yellow);
            Console.WriteLine($"{e.User.uniqueId}: {e.Comment}");
        }

        private void SetConsoleColor(ConsoleColor color)
        {
            if (Console.ForegroundColor != color)
            {
                Console.ForegroundColor = color;
            }
        }
    }
}
