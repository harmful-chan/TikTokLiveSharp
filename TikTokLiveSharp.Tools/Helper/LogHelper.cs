using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TikTokLiveSharp.Win.Helper
{
    public static class LogHelper
    {

        public static event EventHandler<string> NewLineHandler;
        public static event EventHandler<string> AppendHandler;
        public delegate bool Condition();
        private readonly static string _timeFormat = "yyyy-MM-dd hh:mm:ss";
        private readonly static string _recordTempPath = Path.Combine(Path.GetTempPath(), "ttc", "record");

        public static string RecordTempPath => _recordTempPath;
        static LogHelper()
        {
            if (!Directory.Exists(_recordTempPath))
                Directory.CreateDirectory(_recordTempPath);
        }

        // 普通信息
        public static void Info(string msg) => OnLine("info", msg);
        // 设置参数
        public static void Param(string msg) => OnLine("param", msg);
        // 错误
        public static void Error(string msg) => OnLine("error", msg);
        // 数据通信信息
        public static void Webcast(string msg) => OnLine("webcast", msg);

        private static void OnLine(string type, string msg)
        {
            if (NewLineHandler != null)
                NewLineHandler.Invoke(null, $"[{DateTime.Now.ToString(_timeFormat)}] [{type}] " + msg);
        }
        public static void Append(string msg)
        {
            if (AppendHandler != null)
                AppendHandler.Invoke(null, msg);
        }

        private static List<string> _usingLogFileNameList = new List<string>();
        public static void Record(string msg, string fileName = "empty")
        {
            if (NewLineHandler != null)
            {
                string now = DateTime.Now.ToString(_timeFormat);
                string recordFileName = Path.Combine(_recordTempPath, fileName);
                if( !_usingLogFileNameList.Contains(recordFileName))    // 首次使用，并且文件存在
                {
                    File.AppendAllText(recordFileName, $"[{now}] =======================>\r\n");
                    _usingLogFileNameList.Add(recordFileName);
                }

                NewLineHandler.Invoke($"[{now}] [record] " + msg, null);
                File.AppendAllText(recordFileName, $"[{now}] [record] " + msg + "\r\n");
            }
        }
        public static bool Assert(string msg, string tMsg, string fMsg, bool condition)
        {
            bool flag = false;
            if (NewLineHandler != null)
            {
                NewLineHandler.Invoke(null, $"[{DateTime.Now.ToString(_timeFormat)}] [assert] " + msg.PadRight(20, ' '));
                if (condition)
                {
                    flag = true;
                    Append(tMsg);
                }
                else
                {
                    Append(fMsg);
                }
            }
            return flag;
        }
    }
}
