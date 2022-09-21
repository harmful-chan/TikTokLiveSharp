using System;
using System.Collections.Generic;
using System.Text;
using TikTokLiveSharp.Client;

namespace TikTokLiveSharp.Win.Models
{
    internal class Live
    {
        internal RoomData RoomData { get; set; }
        internal TikTokLiveClient Client { get; set; }
        internal int CommentFontSize { get; set; }
        internal int ViewerFontSize { get; set; }
        internal int JoinedFontSize { get; set; }
        internal List<Comment> CommentList { get; set; }
        internal List<string> joinedList { get; set; }
    }
}
