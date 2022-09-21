namespace TikTokLiveSharp.Win.Interfaces
{
    internal interface IAdaptiveable
    {
        public int FontSizeMaximum { get; }
        public int FontSizeMinimum { get; }
        public int FontSize { get; set; }
    }
}