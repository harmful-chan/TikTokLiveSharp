using System;
using System.Collections.Generic;
using System.Text;
using TikTokLiveSharp.Tools.Extensions;

namespace TikTokLiveSharp.Tools.Toolset
{
    public enum NameObjectTypes
    {
        Whole,
        OnlyUniqueID,
        OnlyPort,
        None
    }
    public class NameObject
    {

        
        public string Name { get; set; }
        public NameObjectTypes Type { get; set; } = NameObjectTypes.None;
        public string UniqueID { get; set; }
        public int Port { get; set; } = -1;



        public static NameObject GetNameObject(string str)
        {
            NameObject no = new NameObject();
            if (!str.Legal())
                return null;

            string[] ss = GetFeature(str);
            int i = -1;
            if (ss.Length == 2)
            {
                if(int.TryParse(ss[0], out i))
                {
                    no.Port = i;
                    no.UniqueID = ss[1];
                    no.Type = NameObjectTypes.Whole;
                }
                else if(int.TryParse(ss[1], out i))
                {
                    no.Port = i;
                    no.UniqueID = ss[0];
                    no.Type = NameObjectTypes.Whole;
                }
            }else if(ss.Length == 1)
            {
                if (int.TryParse(ss[0], out i))
                {
                    no.Port = i;
                    no.Type = NameObjectTypes.OnlyPort;
                }
                else
                {
                    no.UniqueID = ss[0];
                    no.Type = NameObjectTypes.OnlyUniqueID;
                }
            }

            int i1 = str.IndexOf('.');
            no.Name = str.Substring(0, i1);
            return no;
        }
        private static string[] GetFeature(string str)
        {
            List<string> list = new List<string>();
            string tmp = str;
            while (true)
            {
                int i1 = tmp.IndexOf('[');
                int i2 = tmp.IndexOf(']');
                if (i1 < 0 || i2 < 0)
                {
                    return list.ToArray();
                }
                else
                {
                    string feature = tmp.Substring(i1 + 1, i2 - i1 - 1);
                    tmp = tmp.Substring(i2 + 1);
                    list.Add(feature);
                }
            }
        }
    }
}
