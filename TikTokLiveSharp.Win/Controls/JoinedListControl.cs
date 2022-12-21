using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TikTokLiveSharp.Win.Helper;
using TikTokLiveSharp.Win.Interfaces;
using TikTokLiveSharp.Win.Models;

namespace TikTokLiveSharp.Win.Controls
{
    public partial class JoinedListControl : UserControl, IAdaptiveable
    {

        List<Label> _joinedLabelList = new List<Label>();
        ScopeValue<int> _joinedFontSize = new ScopeValue<int>(9, 36, 14);

        public int FontSizeMaximum => _joinedFontSize.Maximum;
        public int FontSizeMinimum => _joinedFontSize.Minimum;
        public int FontSize
        {
            get { return _joinedFontSize.Value; }
            set
            {
                if (_joinedFontSize.Value != value && _joinedFontSize.Meet(value))
                {
                    _joinedFontSize.Value = value;
                    _joinedLabelList.ForEach(label =>
                    {
                        LabelFormatHelper.SetFontSize(label, _joinedFontSize.Value);
                    });
                }
            }
        }
        public JoinedListControl()
        {
            InitializeComponent();
        }

        public void JoinedListAppendRange(List<string> joinedList)
        {
            JoinedListAppend(joinedList.ToArray());
        }
        public void JoinedListAppend(params string[] nickNames)
        {
            List<Label> newJoinedLableList = new List<Label>();
            foreach (var item in nickNames)
            {
                Label label = new Label();
                label.AutoSize = true;
                label.Padding = new Padding(0, 0, 0, 0);
                label.Text = item;
                label.ForeColor = Color.Black;
                LabelFormatHelper.SetFontSize(label, _joinedFontSize.Value);
                newJoinedLableList.Add(label);
                _joinedLabelList.Add(label);
            }
            flpJoined.Controls.AddRange(newJoinedLableList.ToArray());

            // 保持最多显示100个人名
            for (; flpJoined.Controls.Count > 100; )
            {
                flpJoined.Controls.RemoveAt(0);
            }
            if(newJoinedLableList.Count > 0)
            {
                flpJoined.ScrollControlIntoView(newJoinedLableList.Last());
            }


        }
        public void JoinedListClear()
        {
            flpJoined.Controls.Clear();
            _joinedLabelList.Clear();
        }

        private void flpJoined_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
