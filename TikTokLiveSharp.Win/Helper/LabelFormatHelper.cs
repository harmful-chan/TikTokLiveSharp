using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TikTokLiveSharp.Win.Helper
{
    internal static class LabelFormatHelper
    {
        internal static void SetFontSize(Control lable, float size)
        {
            FontFamily fontFamily = new FontFamily("Cascadia Mono Light");
            FontStyle fontStyle = lable.Font.Style;
            GraphicsUnit graphicsUnit = lable.Font.Unit;
            lable.Font = new Font(fontFamily, size, fontStyle, graphicsUnit);
        }
    }
}
