using System;
using System.Collections.Generic;
using System.Text;

namespace TikTokLiveSharp.Win.Models
{
    internal class ErrorComment : Comment
    {
        public ErrorComment(string errorMsg) : base(null, "error ", false, errorMsg) { }
    }
}
