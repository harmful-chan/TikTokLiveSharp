using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

namespace TikTokLiveSharp.Win.Helper
{


    public static class ResourcesHelper
    {
        private readonly static string _resourcesPath = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Resources");
        private readonly static string _exePath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int WriteProfileString(string lpszSection, string lpszKeyName, string lpszString);

        [DllImport("gdi32")]
        public static extern int AddFontResource(string lpFileName);

        public static bool InstallFont(string fontName)
        {
            try
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);

                //判断当前登录用户是否为管理员
                if (principal.IsInRole(WindowsBuiltInRole.Administrator) == false)
                {
                    throw new UnauthorizedAccessException("The current user does not have administrator rights and cannot install fonts.");
                }
                //获取Windows字体文件夹路径
                string fontPath = Path.Combine(System.Environment.GetEnvironmentVariable("WINDIR"), "fonts", Path.GetFileName(fontName));
                //检测系统是否已安装该字体
                if (!File.Exists(fontPath))
                {
                    // File.Copy(System.Windows.Forms.Application.StartupPath + "\\font\\" + FontFileName, FontPath); //font是程序目录下放字体的文件夹
                    //将某路径下的字体拷贝到系统字体文件夹下
                    File.Copy(Path.Combine(_resourcesPath, fontName), fontPath); //font是程序目录下放字体的文件夹
                    AddFontResource(fontPath);

                    //Res = SendMessage(HWND_BROADCAST, WM_FONTCHANGE, 0, 0); 
                    //WIN7下编译会出错，不清楚什么问题。注释就行了。  
                    //安装字体
                    WriteProfileString("fonts", Path.GetFileNameWithoutExtension(fontName) + "(TrueType)", Path.GetFileName(fontName));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format($"[{Path.GetFileNameWithoutExtension(fontName)}] fail ！reason: {ex.Message}"));
            }
            return true;
        }

        public static bool CheckFont(string familyName)
        {
            string FontPath = Path.Combine(System.Environment.GetEnvironmentVariable("WINDIR"), "fonts", Path.GetFileName(familyName));
            //检测系统是否已安装该字体
            return File.Exists(FontPath);
        }


        public static bool CheckLib(string libNmae)
        {
            return File.Exists(Path.Combine(_exePath, libNmae));
        }
        public static bool InstallLib(string libNmae)
        {
            File.Copy(Path.Combine(_resourcesPath, libNmae), Path.Combine(_exePath, libNmae));
            return CheckFont(libNmae);
        }
    }
}
