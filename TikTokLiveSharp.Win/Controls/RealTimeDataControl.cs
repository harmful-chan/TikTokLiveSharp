using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TikTokLiveSharp.Win.Helper;
using TikTokLiveSharp.Win.Interfaces;
using TikTokLiveSharp.Win.Models;

namespace TikTokLiveSharp.Win.Controls
{
    public partial class RealTimeDataControl : UserControl, IAdaptiveable
    {
        ScopeValue<int> _fontSize = new ScopeValue<int>(9, 36, 12);
        public RealTimeDataControl()
        {
            InitializeComponent();
        }

        public int FontSizeMaximum => _fontSize.Maximum;

        public int FontSizeMinimum => _fontSize.Minimum;

        public int FontSize
        {
            get
            {
                return _fontSize.Value;
            }
            set
            {
                _fontSize.Value = value;
                LabelFormatHelper.SetFontSize(this.lbHeader, _fontSize.Value);
                LabelFormatHelper.SetFontSize(this.lb, _fontSize.Value);
                LabelFormatHelper.SetFontSize(this.lbValue, _fontSize.Value);
                ResizeControl();
            }
        }

        private string _header;
        public string Header
        {
            get { return _header; }
            set { _header = value; this.lbHeader.Text = _header; }
        }

        private long _value;
        public long Value
        {
            get { return _value; }
            set { _value = value; this.lbValue.Text = _value.ToString().PadRight(6, ' '); }
        }


        private void ResizeControl()
        {
            this.Height = this.lbHeader.Height;
            this.Width = this.lbHeader.Width + this.lbValue.Width + this.lb.Width;
        }


        private void lbHeader_Click(object sender, EventArgs e)
        {

        }

        private void lbValue_Click(object sender, EventArgs e)
        {

        }

        private void lb_Click(object sender, EventArgs e)
        {

        }

        private void RealTimeDataControl_Load(object sender, EventArgs e)
        {
            FontSize = 14;
        }
    }
}
