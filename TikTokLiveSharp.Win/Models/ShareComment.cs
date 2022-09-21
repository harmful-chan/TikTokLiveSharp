using System;
using System.Collections.Generic;
using System.Text;

namespace TikTokLiveSharp.Win.Models
{
    internal class ShareComment : Comment
    {
        public ShareComment(string nickName) : base(null, nickName, false, "shared a link") { }
    }
}
