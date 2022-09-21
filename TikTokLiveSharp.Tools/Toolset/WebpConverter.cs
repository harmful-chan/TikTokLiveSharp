using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using TikTokLiveSharp.Tools.Extensions;

namespace TikTokLiveSharp.Tools.Toolset
{
    public static class WebpConverter
    {
        public static HttpClient HttpClient = null;
        private static readonly string _iconTempPath = Path.Combine(Path.GetTempPath(), "ttc", "icon");
        private static Dictionary<string, Bitmap> _sbDictionary = new Dictionary<string, Bitmap>();

        static WebpConverter()
        {
            if (!Directory.Exists(_iconTempPath))
                Directory.CreateDirectory(_iconTempPath);
        }


        public static string GenerateIconFileName(string urlPath)
        {
            return Path.GetFileName(urlPath).Replace(':', '_').Replace(".webp", ".jpeg");
        }

        public static async Task<Image> GetThumbnailAsync(string url, int size)
        {
            try
            {
                if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
                {
                    if (!_sbDictionary.ContainsKey(uri.AbsoluteUri))
                    {
                        string fileName = WebpConverter.GenerateIconFileName(uri.AbsolutePath);
                        string localFileName = await WebpConverter.StorageAsync(fileName, uri.AbsoluteUri);
                        Bitmap icon = new Bitmap(localFileName);
                        _sbDictionary[uri.AbsoluteUri] = icon;
                    }

                    //int size = (int)(_commentFontSize.Value * 1.5);
                    Image iconImage = _sbDictionary[uri.AbsoluteUri].GetThumbnailImage(size, size,
                        new Image.GetThumbnailImageAbort(() => { return false; }), IntPtr.Zero);

                    return iconImage;
                }
                return null;
            }
            catch { throw; }
        }
        public static async Task<string> StorageAsync(string fileName, string url)
        {
            if(new Uri(url).IsAbsoluteUri && HttpClient.Legal())
            {
                try
                {
                    string localFileName = Path.Combine(_iconTempPath, fileName);
                    if (!File.Exists(localFileName))
                    {
                        byte[] urlContents = await HttpClient.GetByteArrayAsync(url);
                        Bitmap img = new Imazen.WebP.SimpleDecoder().DecodeFromBytes(urlContents, urlContents.Length);
                        img.Save(localFileName);
                    }
                    return localFileName;
                }
                catch { throw;  }
            }
            return null;
        }
    }
}
