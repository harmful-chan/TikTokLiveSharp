using System;
using System.Collections.Generic;
using System.Text;

namespace TikTokLiveSharp.Win.Models
{
    internal class Private
    {
        public string[] UniqueIDList { get; set; }
        public string PublicSessionID { get; set; }
        public long Expiration { get; set; }
    }
}
