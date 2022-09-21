namespace TikTokLiveSharp.Win.Models
{
    public class Comment
    {
        public Comment()
        {

        }

        public Comment(string iconUrl, string nickName, bool isTranslate, string raw)
        {
            IconUrl = iconUrl;
            NickName = nickName;
            Raw = raw;
            IsTranslate = isTranslate;
        }

        public string IconUrl { get; set; }
        public string NickName { get; set; }
        public bool IsTranslate { get; set; } =true;
        public string Raw { get; set; }
        public string Chinese { get; set; }
    }

}
