﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TikTokLiveSharp.Win.Models
{
    internal class Cookie
    {
        public string domain { get; set; }
        public double expirationDate { get; set; }
        public bool hostOnly { get; set; }
        public bool httpOnly { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string sameSite { get; set; }
        public bool secure { get; set; }
        public bool session { get; set; }
        public string storeId { get; set; }
        public string value { get; set; }
        public int id { get; set; }
    }
}
