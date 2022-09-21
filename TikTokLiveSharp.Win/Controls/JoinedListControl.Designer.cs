namespace TikTokLiveSharp.Win.Controls
{
    partial class JoinedListControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.flpJoined = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpJoined
            // 
            this.flpJoined.AutoScroll = true;
            this.flpJoined.AutoSize = true;
            this.flpJoined.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpJoined.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpJoined.Location = new System.Drawing.Point(0, 0);
            this.flpJoined.Name = "flpJoined";
            this.flpJoined.Size = new System.Drawing.Size(134, 101);
            this.flpJoined.TabIndex = 0;
            this.flpJoined.WrapContents = false;
            this.flpJoined.Paint += new System.Windows.Forms.PaintEventHandler(this.flpJoined_Paint);
            // 
            // JoinedListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flpJoined);
            this.Name = "JoinedListControl";
            this.Size = new System.Drawing.Size(134, 101);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpJoined;
    }
}
