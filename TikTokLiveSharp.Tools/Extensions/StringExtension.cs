namespace TikTokLiveSharp.Tools.Extensions
{
    public static class StringExtension
    {
        public static bool Legal(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }
    }
}
