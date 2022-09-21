namespace TikTokLiveSharp.Tools.Extensions
{
    public static class ObjectExtension
    {
        public static bool Legal(this object o)
        {
            return o != null && o.GetType() != typeof(string);
        }
    }
}
