using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TikTokLiveSharp.Tools.Extensions;
using TikTokLiveSharp.Tools.Toolset;
using TikTokLiveSharp.Win.Helper;
using TikTokLiveSharp.Win.Interfaces;
using TikTokLiveSharp.Win.Models;

namespace TikTokLiveSharp.Win.Controls
{
    public partial class CommentListControl : UserControl, IAdaptiveable
    {
        //string _rawSpilt = " → ";
        string _rawSpilt = " : ";
        string _chineseSpilt = "┕▶";
        public string ChineseSpilt => _chineseSpilt;
        List<Label> _rawLabelList = new List<Label>();
        List<Label> _chineseLabelList = new List<Label>();
        ScopeValue<int> _commentFontSize = new ScopeValue<int>(9, 36, 14);
        public event EventHandler<string> RawDoubleClickHandler;
        public event EventHandler<string> ChineseDoubleClickHandler;
        private bool _isTranslate;
        public bool IsTranslate
        {
            set
            {
                _isTranslate = value;
                _chineseLabelList.ForEach(lable => lable.Visible = _isTranslate && (bool)(lable.Tag) );
            }
            get
            {
                return _isTranslate;
            }
        }

        public int FontSizeMaximum => _commentFontSize.Maximum;
        public int FontSizeMinimum => _commentFontSize.Minimum;
        public int FontSize
        {
            set
            {
                if (_commentFontSize.Value != value && _commentFontSize.Meet(value))
                {
                    _commentFontSize.Value = value;
                    _rawLabelList.ForEach(label =>
                    {
                        LabelFormatHelper.SetFontSize(label, _commentFontSize.Value);
                        SetThumbnailSize(label, _commentFontSize.Value);
                    });
                    _chineseLabelList.ForEach(label =>
                    {
                        LabelFormatHelper.SetFontSize(label, _commentFontSize.Value);
                        SetThumbnailSize(label, _commentFontSize.Value);
                    });
                }
            }
            get
            {
                return _commentFontSize.Value;
            }
        }

        public CommentListControl()
        {
            InitializeComponent();
        }

        public void CommentListAppendRange(List<Comment> commentList)
        {
            CommentListAppend(commentList.ToArray());
        }
        public  async void CommentListAppend(params Comment[] cs)
        {

            try
            {
                List<Label> cls = new List<Label>();
                foreach (var item in cs)
                {
                    // raw 
                    Label label = new Label();
                    label.Margin = new Padding(0, 0, 0, 0);
                    label.Padding = new Padding(0, 0, 0, 0);
                    label.ImageAlign = ContentAlignment.TopLeft;
                    label.AutoSize = true;
                    label.DoubleClick += Label_DoubleClick;
                    label.ForeColor = Color.DimGray;
                    LabelFormatHelper.SetFontSize(label, _commentFontSize.Value);
                    string empty = "";
                    if (item is FollowComment fc)  // follow 评论
                    {
                        label.ForeColor = Color.Gold;
                    }
                    else if (item is ShareComment sc)
                    {
                        label.ForeColor = Color.Blue;
                    }else if (item is ErrorComment ec)
                    {
                        label.ForeColor = Color.Crimson;
                    }
                    else
                    {
                        empty = "  ";
                        label.Paint += CommentLabel_Paint;
                        label.MouseMove += (sender, e) => (sender as Label).ForeColor = SystemColors.Highlight;
                        label.MouseLeave += (sender, e) => (sender as Label).ForeColor = Color.DimGray;
                    }
                    label.Text = $"{empty}{item.NickName}{_rawSpilt}{item.Raw}";
                    _rawLabelList.Add(label);
                    cls.Add(label);

                    // 中文
                    Label lc = new Label();
                    lc.Margin = new Padding(0, 0, 0, 0);
                    lc.Padding = new Padding(0, 0, 0, 0);
                    lc.ForeColor = Color.Red;
                    lc.AutoSize = true;
                    lc.DoubleClick += Lc_DoubleClick; ;
                    string chinese = item.Chinese;
                    if (!chinese.Legal())
                    {
                        chinese = "Translation error, please translate manually";
                    }
                    lc.Text = $"{_chineseSpilt}{item.Chinese}";
                    lc.Tag = item.IsTranslate;
                    LabelFormatHelper.SetFontSize(lc, _commentFontSize.Value);
                    lc.Visible = _isTranslate && item.IsTranslate;
                    _chineseLabelList.Add(lc);
                    cls.Add(lc);


                    // 图标
                    if (item.IconUrl.Legal())
                    {
                        label.Image = await WebpConverter.GetThumbnailAsync(item.IconUrl, (int)(_commentFontSize.Value * 1.5));
                        label.Tag = item.IconUrl;
                    }
         
                }
                flpComment.Controls.AddRange(cls.ToArray());

                // 保持最多显示50条评论
                while(flpComment.Controls.Count > 100)
                {
                    flpComment.Controls.RemoveAt(0);
                }

                Label lb = cls.FindLast(l => l.Visible);
                flpComment.ScrollControlIntoView(lb);
            }
            catch { }
        }



        public void CommentListClear() 
        {
            this.flpComment.Controls.Clear();
            this._rawLabelList.Clear();
            _chineseLabelList.Clear();
        } 

        private void CommentLabel_Paint(object sender, PaintEventArgs e)
        {
            System.Windows.Forms.Label label = sender as System.Windows.Forms.Label;
            string[] raws = label.Text.Split(_rawSpilt);
            System.Drawing.Point point = new System.Drawing.Point(label.Padding.Left, label.Padding.Top);
            TextRenderer.DrawText(e.Graphics, raws[0], label.Font, point, System.Drawing.Color.Black);
        }

        private void Label_DoubleClick(object sender, EventArgs e)
        {
            if(RawDoubleClickHandler != null)
            {
                if( sender is Label lb)
                {
                    RawDoubleClickHandler.Invoke(sender, lb.Text);
                }
            }
        }
        private void Lc_DoubleClick(object sender, EventArgs e)
        {
            if (ChineseDoubleClickHandler != null)
            {
                if (sender is Label lb)
                {
                    int i = _chineseLabelList.IndexOf(lb);
                    Label label = _rawLabelList.ElementAt(i);
                    ChineseDoubleClickHandler.Invoke(sender, label.Text.Split(_rawSpilt).Last());
                }
            }
        }

        private async void SetThumbnailSize(System.Windows.Forms.Label lable, float size)
        {
            string url = lable.Tag as string;
            if (url.Legal())
            {
                lable.Image = await WebpConverter.GetThumbnailAsync(url, (int)(size * 1.5));
            }
        }

        private void flpComment_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flpComment_DockChanged(object sender, EventArgs e)
        {

        }

        private void flpComment_DoubleClick(object sender, EventArgs e)
        {

        }


        private void CommentPanelControl_Load(object sender, EventArgs e)
        {

        }

    }
}
