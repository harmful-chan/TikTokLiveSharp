using System;
using System.Collections.Generic;
using System.Text;

namespace TikTokLiveSharp.Win.Models
{
    internal class FollowComment : Comment
    {
        public FollowComment(string nickName) : base(null, nickName, false, "followed the host") { }
    }
}
