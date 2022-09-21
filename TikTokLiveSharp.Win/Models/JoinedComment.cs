using System;
using System.Collections.Generic;
using System.Text;

namespace TikTokLiveSharp.Win.Models
{
    internal class JoinedComment : Comment
    {
        public JoinedComment(string nickName) : base(null, nickName, false, "joined") { }
    }
}
