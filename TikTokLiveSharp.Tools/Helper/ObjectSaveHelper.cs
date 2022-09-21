using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TikTokLiveSharp.Tools.Extensions;

namespace TikTokLiveSharp.Win.Helper
{
    public static class ObjectSaveHelper
    {
        private readonly static string _objectTempPath = Path.Combine(Path.GetTempPath(), "ttc", "history");
        public static string ObjectTempPath => _objectTempPath;
        static ObjectSaveHelper()
        {
            if(!Directory.Exists(_objectTempPath))
                Directory.CreateDirectory(_objectTempPath);
        }

        public static async Task<bool> SaveAsync<T>(string fileName, T t) where T : class
        {
            return await Task.Run(() =>
            {
                if (!fileName.Legal() || t == null)
                    return false;

                lock (fileName)
                {
                    if (!File.Exists(fileName))
                        File.Create(fileName);
                    try
                    {
                        string ser = JsonSerializer.Serialize(t);
                        File.WriteAllText(fileName, ser);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    return true;
                }

            });
        }

        public static async Task<T> ReStoreAsync<T>(string fileName) where T : class, new()
        {
            return await Task.Run(() =>
            {
                if (!fileName.Legal() )
                    return null;

                lock (fileName)
                {
                    T t=null;
                    if (File.Exists(fileName))
                    {
                        try
                        {
                            string v = File.ReadAllText(fileName);
                            t = JsonSerializer.Deserialize<T>(v);
                        }
                        catch (Exception e)
                        {
                            return new T();
                        }
                    }
                    return t;
                }

            });
        }
    }
}
