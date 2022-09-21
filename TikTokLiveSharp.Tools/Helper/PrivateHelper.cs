using System.IO;
using TikTokLiveSharp.Tools.Extensions;

namespace TikTokLiveSharp.Win.Helper
{
    public static class PrivateHelper
    {
        private static readonly string _privateTempPath = Path.Combine(Path.GetTempPath(), "ttc", "private");
        private static readonly string _privateFileName = Path.Combine(Path.GetTempPath(), "ttc", "private", "private.json");
        public static string PrivateFileName => _privateFileName;

        private static string TempPrivate()
        {
            return "{ \r\n\t\"UniqueIDList\": [ \"fbs.students\", \"lamore.girl\", \"yoyo.babies\", \"go.pukka\", \"hibobi.uk\"]," +
                   "\r\n\t\"PublicSessionID\": \"aaeeb8db89c07eba82bb01127cbf149d\"," +
                   "\r\n\t\"Expiration\": 1665290552 \r\n}";
        }


        static PrivateHelper()
        {
            if (!Directory.Exists(_privateTempPath))
                Directory.CreateDirectory(_privateTempPath);

            if (!File.Exists(_privateFileName))
                File.WriteAllText(_privateFileName, TempPrivate());
        }


        public static string GetPrivate()
        {
            string str = File.ReadAllText(_privateFileName);

            return str.Legal() ? str : TempPrivate();
        }
        public static void SetPrivate(string str)
        {
            File.WriteAllText(_privateFileName, str);
        }
    }
}
