using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TikTokLiveSharp.Tools.Extensions;
using TikTokLiveSharp.Tools.Toolset;
using TikTokLiveSharp.Win.Helper;

namespace TikTokLiveSharp.Win
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (InitResources())
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                string hostName = Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                //MessageBox.Show(hostName);
                NameObject no = NameObject.GetNameObject(hostName);
                Application.Run(new MainForm(no.UniqueID, no.Port));
            }
        }

        private static bool InitResources()
        {

            try
            {
                bool a = ResourcesHelper.CheckFont("CascadiaCode.ttf");
                bool b = ResourcesHelper.CheckFont("CascadiaMono.ttf");

                if (!a) ResourcesHelper.InstallFont("CascadiaCode.ttf");
                if (!b) ResourcesHelper.InstallFont("CascadiaMono.ttf");

                if( !a || !b)
                {
                    string str = "Resource installation is successful, please restart.";
                    str += !a ? "CascadiaCode.ttf" : null;
                    str += !b ? "CascadiaMono.ttf" : null;
                    MessageBox.Show(str, null, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, null, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
        }
    }

}
