using System;
using System.Collections.Generic;

namespace TikTokLiveSharp.Win.Models
{
    internal static class LiveCenter
    {
        private static Dictionary<string, Live> _dictionary = new Dictionary<string, Live>();
        internal static Uri Proxy { get; set; }
        internal static bool IsDirect { get; set; } = false;
        private static Live _currenteLive { get; set; }
        internal static void SetCurrentLive(Live live)
        {
            _currenteLive=live;
        }
        internal static Live GetCurrentLive() => _currenteLive;
        internal static Live CreateLive(string key = "default")
        {
            if( !_dictionary.ContainsKey(key))
            {
                Live live = new Live();
                live.CommentList = new List<Comment>();
                live.joinedList = new List<string>();
                live.RoomData = new RoomData();
                live.CommentFontSize = 14;
                live.JoinedFontSize = 14;
                live.ViewerFontSize = 14;
                if (!string.IsNullOrWhiteSpace(key))
                {
                    _dictionary[key] = live;
                    return live;
                }
                return live;
            }
            else
            {
                return _dictionary[key];
            }
        }
        internal static void RemoveLive(string key = "default")
        {
            if (_dictionary.ContainsKey(key))
            {
                if(_currenteLive == _dictionary[key])
                {
                    _currenteLive = null;
                }

                _dictionary[key] = null;
                _dictionary.Remove(key);
            }
        }
    }
}
