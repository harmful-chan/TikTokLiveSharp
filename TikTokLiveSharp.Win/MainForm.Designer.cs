namespace TikTokLiveSharp.Win
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openCommentRecordFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openLiveStreamHistoryFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreCommentRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panMain = new System.Windows.Forms.Panel();
            this.panComment = new System.Windows.Forms.Panel();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.clc = new TikTokLiveSharp.Win.Controls.CommentListControl();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.jlc = new TikTokLiveSharp.Win.Controls.JoinedListControl();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRoomID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClipboard = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.flpViewers = new System.Windows.Forms.FlowLayoutPanel();
            this.dcViewers = new TikTokLiveSharp.Win.Controls.RealTimeDataControl();
            this.dcLikes = new TikTokLiveSharp.Win.Controls.RealTimeDataControl();
            this.dcFollowers = new TikTokLiveSharp.Win.Controls.RealTimeDataControl();
            this.dcJoined = new TikTokLiveSharp.Win.Controls.RealTimeDataControl();
            this.dcComments = new TikTokLiveSharp.Win.Controls.RealTimeDataControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panConfig = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrivate = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCommentFontSize = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbJoinedFontSize = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAlterPrivate = new System.Windows.Forms.Button();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.cbViewerFontSize = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbTranslation = new System.Windows.Forms.CheckBox();
            this.flpTranslationOption = new System.Windows.Forms.FlowLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.cbTraSrcType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbTraDstType = new System.Windows.Forms.ComboBox();
            this.cbShowJoinedPanel = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panDebug = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUniqueID = new System.Windows.Forms.ComboBox();
            this.btnConnection = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip2.SuspendLayout();
            this.panMain.SuspendLayout();
            this.panComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel9.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flpViewers.SuspendLayout();
            this.panConfig.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel8.SuspendLayout();
            this.flowLayoutPanel10.SuspendLayout();
            this.flpTranslationOption.SuspendLayout();
            this.panDebug.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip2.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.SetupToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1078, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectionToolStripMenuItem,
            this.UnConnectionToolStripMenuItem,
            this.toolStripSeparator1,
            this.openCommentRecordFolderToolStripMenuItem,
            this.toolStripSeparator2,
            this.openLiveStreamHistoryFolderToolStripMenuItem,
            this.restoreCommentRecordsToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.FileToolStripMenuItem.Text = "file";
            // 
            // ConnectionToolStripMenuItem
            // 
            this.ConnectionToolStripMenuItem.Name = "ConnectionToolStripMenuItem";
            this.ConnectionToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.ConnectionToolStripMenuItem.Text = "Connection";
            this.ConnectionToolStripMenuItem.Click += new System.EventHandler(this.ConnectionToolStripMenuItem_Click);
            // 
            // UnConnectionToolStripMenuItem
            // 
            this.UnConnectionToolStripMenuItem.Name = "UnConnectionToolStripMenuItem";
            this.UnConnectionToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.UnConnectionToolStripMenuItem.Text = "Disconnection";
            this.UnConnectionToolStripMenuItem.Click += new System.EventHandler(this.UnConnectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(288, 6);
            // 
            // openCommentRecordFolderToolStripMenuItem
            // 
            this.openCommentRecordFolderToolStripMenuItem.Name = "openCommentRecordFolderToolStripMenuItem";
            this.openCommentRecordFolderToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.openCommentRecordFolderToolStripMenuItem.Text = "Open comment record folder";
            this.openCommentRecordFolderToolStripMenuItem.Click += new System.EventHandler(this.openCommentrecordFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(288, 6);
            // 
            // openLiveStreamHistoryFolderToolStripMenuItem
            // 
            this.openLiveStreamHistoryFolderToolStripMenuItem.Name = "openLiveStreamHistoryFolderToolStripMenuItem";
            this.openLiveStreamHistoryFolderToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.openLiveStreamHistoryFolderToolStripMenuItem.Text = "Open live stream history folder";
            this.openLiveStreamHistoryFolderToolStripMenuItem.Click += new System.EventHandler(this.openLiveStreamHistoryFolderToolStripMenuItem_Click);
            // 
            // restoreCommentRecordsToolStripMenuItem
            // 
            this.restoreCommentRecordsToolStripMenuItem.Name = "restoreCommentRecordsToolStripMenuItem";
            this.restoreCommentRecordsToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.restoreCommentRecordsToolStripMenuItem.Text = "Restore live stream history";
            // 
            // SetupToolStripMenuItem
            // 
            this.SetupToolStripMenuItem.Checked = true;
            this.SetupToolStripMenuItem.CheckOnClick = true;
            this.SetupToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.debugModeToolStripMenuItem,
            this.configureToolStripMenuItem});
            this.SetupToolStripMenuItem.Name = "SetupToolStripMenuItem";
            this.SetupToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.SetupToolStripMenuItem.Text = "setup";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.normalToolStripMenuItem.Text = "comment";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.NormalToolStripMenuItem_Click);
            // 
            // debugModeToolStripMenuItem
            // 
            this.debugModeToolStripMenuItem.CheckOnClick = true;
            this.debugModeToolStripMenuItem.Name = "debugModeToolStripMenuItem";
            this.debugModeToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.debugModeToolStripMenuItem.Text = "debug";
            this.debugModeToolStripMenuItem.Click += new System.EventHandler(this.DebugModeToolStripMenuItem_Click);
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Checked = true;
            this.configureToolStripMenuItem.CheckOnClick = true;
            this.configureToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.configureToolStripMenuItem.Text = "configure";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.ConfigureToolStripMenuItem_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLog.Location = new System.Drawing.Point(10, 30);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(839, 221);
            this.txtLog.TabIndex = 3;
            // 
            // panMain
            // 
            this.panMain.BackColor = System.Drawing.Color.White;
            this.panMain.Controls.Add(this.panComment);
            this.panMain.Controls.Add(this.panConfig);
            this.panMain.Controls.Add(this.panDebug);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(0, 24);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(1078, 738);
            this.panMain.TabIndex = 9;
            this.panMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panMain_Paint);
            // 
            // panComment
            // 
            this.panComment.BackColor = System.Drawing.Color.Transparent;
            this.panComment.Controls.Add(this.scMain);
            this.panComment.Controls.Add(this.flowLayoutPanel6);
            this.panComment.Controls.Add(this.panel5);
            this.panComment.Controls.Add(this.flpViewers);
            this.panComment.Controls.Add(this.panel4);
            this.panComment.Location = new System.Drawing.Point(65, 477);
            this.panComment.Name = "panComment";
            this.panComment.Size = new System.Drawing.Size(869, 339);
            this.panComment.TabIndex = 16;
            // 
            // scMain
            // 
            this.scMain.BackColor = System.Drawing.Color.Transparent;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(10, 50);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.clc);
            this.scMain.Panel1.Controls.Add(this.flowLayoutPanel7);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.jlc);
            this.scMain.Panel2.Controls.Add(this.flowLayoutPanel9);
            this.scMain.Size = new System.Drawing.Size(849, 267);
            this.scMain.SplitterDistance = 587;
            this.scMain.TabIndex = 10;
            // 
            // clc
            // 
            this.clc.BackColor = System.Drawing.Color.Transparent;
            this.clc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clc.Font = new System.Drawing.Font("Cascadia Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clc.FontSize = 14;
            this.clc.IsTranslate = true;
            this.clc.Location = new System.Drawing.Point(0, 16);
            this.clc.Name = "clc";
            this.clc.Size = new System.Drawing.Size(587, 251);
            this.clc.TabIndex = 17;
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.AutoSize = true;
            this.flowLayoutPanel7.Controls.Add(this.label8);
            this.flowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(587, 16);
            this.flowLayoutPanel7.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label8.Size = new System.Drawing.Size(136, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "comment list panel";
            // 
            // jlc
            // 
            this.jlc.BackColor = System.Drawing.Color.Transparent;
            this.jlc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jlc.FontSize = 14;
            this.jlc.Location = new System.Drawing.Point(0, 16);
            this.jlc.Name = "jlc";
            this.jlc.Size = new System.Drawing.Size(258, 251);
            this.jlc.TabIndex = 19;
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.AutoSize = true;
            this.flowLayoutPanel9.Controls.Add(this.label9);
            this.flowLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(258, 16);
            this.flowLayoutPanel9.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "joined list panel";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.AutoSize = true;
            this.flowLayoutPanel6.Controls.Add(this.label4);
            this.flowLayoutPanel6.Controls.Add(this.txtRoomID);
            this.flowLayoutPanel6.Controls.Add(this.label6);
            this.flowLayoutPanel6.Controls.Add(this.txtClipboard);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(10, 317);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(849, 22);
            this.flowLayoutPanel6.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "RoomID:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRoomID
            // 
            this.txtRoomID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRoomID.Location = new System.Drawing.Point(65, 3);
            this.txtRoomID.Multiline = true;
            this.txtRoomID.Name = "txtRoomID";
            this.txtRoomID.ReadOnly = true;
            this.txtRoomID.Size = new System.Drawing.Size(140, 16);
            this.txtRoomID.TabIndex = 3;
            this.txtRoomID.Text = "7130109583712471814";
            this.txtRoomID.WordWrap = false;
            this.txtRoomID.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtRoomID_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "double click to copy text:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtClipboard
            // 
            this.txtClipboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClipboard.Location = new System.Drawing.Point(406, 3);
            this.txtClipboard.Multiline = true;
            this.txtClipboard.Name = "txtClipboard";
            this.txtClipboard.ReadOnly = true;
            this.txtClipboard.Size = new System.Drawing.Size(306, 16);
            this.txtClipboard.TabIndex = 4;
            this.txtClipboard.WordWrap = false;
            this.txtClipboard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtClipboard_MouseUp);
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(859, 50);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 289);
            this.panel5.TabIndex = 13;
            // 
            // flpViewers
            // 
            this.flpViewers.AutoSize = true;
            this.flpViewers.Controls.Add(this.dcViewers);
            this.flpViewers.Controls.Add(this.dcLikes);
            this.flpViewers.Controls.Add(this.dcFollowers);
            this.flpViewers.Controls.Add(this.dcJoined);
            this.flpViewers.Controls.Add(this.dcComments);
            this.flpViewers.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpViewers.Location = new System.Drawing.Point(10, 0);
            this.flpViewers.Name = "flpViewers";
            this.flpViewers.Size = new System.Drawing.Size(859, 50);
            this.flpViewers.TabIndex = 8;
            // 
            // dcViewers
            // 
            this.dcViewers.AutoSize = true;
            this.dcViewers.BackColor = System.Drawing.Color.Transparent;
            this.dcViewers.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dcViewers.FontSize = 14;
            this.dcViewers.Header = "viewers";
            this.dcViewers.Location = new System.Drawing.Point(0, 0);
            this.dcViewers.Margin = new System.Windows.Forms.Padding(0);
            this.dcViewers.Name = "dcViewers";
            this.dcViewers.Size = new System.Drawing.Size(202, 25);
            this.dcViewers.TabIndex = 0;
            this.dcViewers.Value = ((long)(0));
            // 
            // dcLikes
            // 
            this.dcLikes.AutoSize = true;
            this.dcLikes.BackColor = System.Drawing.Color.Transparent;
            this.dcLikes.FontSize = 14;
            this.dcLikes.Header = "likes";
            this.dcLikes.Location = new System.Drawing.Point(202, 0);
            this.dcLikes.Margin = new System.Windows.Forms.Padding(0);
            this.dcLikes.Name = "dcLikes";
            this.dcLikes.Size = new System.Drawing.Size(180, 25);
            this.dcLikes.TabIndex = 1;
            this.dcLikes.Value = ((long)(0));
            // 
            // dcFollowers
            // 
            this.dcFollowers.AutoSize = true;
            this.dcFollowers.BackColor = System.Drawing.Color.Transparent;
            this.dcFollowers.FontSize = 14;
            this.dcFollowers.Header = "followers";
            this.dcFollowers.Location = new System.Drawing.Point(382, 0);
            this.dcFollowers.Margin = new System.Windows.Forms.Padding(0);
            this.dcFollowers.Name = "dcFollowers";
            this.dcFollowers.Size = new System.Drawing.Size(224, 25);
            this.dcFollowers.TabIndex = 2;
            this.dcFollowers.Value = ((long)(0));
            // 
            // dcJoined
            // 
            this.dcJoined.AutoSize = true;
            this.dcJoined.BackColor = System.Drawing.Color.Transparent;
            this.dcJoined.FontSize = 14;
            this.dcJoined.Header = "joined";
            this.dcJoined.Location = new System.Drawing.Point(606, 0);
            this.dcJoined.Margin = new System.Windows.Forms.Padding(0);
            this.dcJoined.Name = "dcJoined";
            this.dcJoined.Size = new System.Drawing.Size(191, 25);
            this.dcJoined.TabIndex = 3;
            this.dcJoined.Value = ((long)(0));
            // 
            // dcComments
            // 
            this.dcComments.AutoSize = true;
            this.dcComments.BackColor = System.Drawing.Color.Transparent;
            this.dcComments.FontSize = 14;
            this.dcComments.Header = "comments";
            this.dcComments.Location = new System.Drawing.Point(0, 25);
            this.dcComments.Margin = new System.Windows.Forms.Padding(0);
            this.dcComments.Name = "dcComments";
            this.dcComments.Size = new System.Drawing.Size(213, 25);
            this.dcComments.TabIndex = 4;
            this.dcComments.Value = ((long)(0));
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 339);
            this.panel4.TabIndex = 12;
            // 
            // panConfig
            // 
            this.panConfig.Controls.Add(this.tableLayoutPanel1);
            this.panConfig.Controls.Add(this.panel3);
            this.panConfig.Controls.Add(this.panel2);
            this.panConfig.Location = new System.Drawing.Point(949, 495);
            this.panConfig.Name = "panConfig";
            this.panConfig.Size = new System.Drawing.Size(537, 523);
            this.panConfig.TabIndex = 15;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPrivate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel8, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel10, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.cbShowJoinedPanel, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(517, 523);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "private information";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrivate
            // 
            this.txtPrivate.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrivate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrivate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrivate.Location = new System.Drawing.Point(3, 25);
            this.txtPrivate.Multiline = true;
            this.txtPrivate.Name = "txtPrivate";
            this.txtPrivate.ReadOnly = true;
            this.txtPrivate.Size = new System.Drawing.Size(511, 94);
            this.txtPrivate.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.cbCommentFontSize);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 164);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(511, 30);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(168, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "comment panel font size";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbCommentFontSize
            // 
            this.cbCommentFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCommentFontSize.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbCommentFontSize.FormattingEnabled = true;
            this.cbCommentFontSize.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32"});
            this.cbCommentFontSize.Location = new System.Drawing.Point(177, 3);
            this.cbCommentFontSize.Name = "cbCommentFontSize";
            this.cbCommentFontSize.Size = new System.Drawing.Size(49, 24);
            this.cbCommentFontSize.TabIndex = 16;
            this.cbCommentFontSize.TextChanged += new System.EventHandler(this.cbCommentFontSize_TextChanged);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.AutoSize = true;
            this.flowLayoutPanel5.Controls.Add(this.label5);
            this.flowLayoutPanel5.Controls.Add(this.cbJoinedFontSize);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 200);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(511, 30);
            this.flowLayoutPanel5.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label5.Size = new System.Drawing.Size(161, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "joined panel font size";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbJoinedFontSize
            // 
            this.cbJoinedFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJoinedFontSize.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbJoinedFontSize.FormattingEnabled = true;
            this.cbJoinedFontSize.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32"});
            this.cbJoinedFontSize.Location = new System.Drawing.Point(170, 3);
            this.cbJoinedFontSize.Name = "cbJoinedFontSize";
            this.cbJoinedFontSize.Size = new System.Drawing.Size(49, 24);
            this.cbJoinedFontSize.TabIndex = 17;
            this.cbJoinedFontSize.TextChanged += new System.EventHandler(this.cbJoinedFontSize_TextChanged);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.Controls.Add(this.btnAlterPrivate);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 125);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(511, 33);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // btnAlterPrivate
            // 
            this.btnAlterPrivate.AutoSize = true;
            this.btnAlterPrivate.Location = new System.Drawing.Point(433, 3);
            this.btnAlterPrivate.Name = "btnAlterPrivate";
            this.btnAlterPrivate.Size = new System.Drawing.Size(75, 27);
            this.btnAlterPrivate.TabIndex = 1;
            this.btnAlterPrivate.Text = "alter";
            this.btnAlterPrivate.UseVisualStyleBackColor = true;
            this.btnAlterPrivate.Click += new System.EventHandler(this.btnAlterPrivate_Click);
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.AutoSize = true;
            this.flowLayoutPanel8.Controls.Add(this.label7);
            this.flowLayoutPanel8.Controls.Add(this.cbViewerFontSize);
            this.flowLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel8.Location = new System.Drawing.Point(3, 236);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(511, 30);
            this.flowLayoutPanel8.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label7.Size = new System.Drawing.Size(161, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "viewer panel font size";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbViewerFontSize
            // 
            this.cbViewerFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbViewerFontSize.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbViewerFontSize.FormattingEnabled = true;
            this.cbViewerFontSize.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32"});
            this.cbViewerFontSize.Location = new System.Drawing.Point(170, 3);
            this.cbViewerFontSize.Name = "cbViewerFontSize";
            this.cbViewerFontSize.Size = new System.Drawing.Size(49, 24);
            this.cbViewerFontSize.TabIndex = 17;
            this.cbViewerFontSize.SelectedIndexChanged += new System.EventHandler(this.cbViewerFontSize_SelectedIndexChanged);
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.Controls.Add(this.cbTranslation);
            this.flowLayoutPanel10.Controls.Add(this.flpTranslationOption);
            this.flowLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel10.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel10.Location = new System.Drawing.Point(3, 298);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(511, 94);
            this.flowLayoutPanel10.TabIndex = 18;
            // 
            // cbTranslation
            // 
            this.cbTranslation.AutoSize = true;
            this.cbTranslation.Checked = true;
            this.cbTranslation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTranslation.Location = new System.Drawing.Point(6, 3);
            this.cbTranslation.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.cbTranslation.Name = "cbTranslation";
            this.cbTranslation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbTranslation.Size = new System.Drawing.Size(138, 20);
            this.cbTranslation.TabIndex = 0;
            this.cbTranslation.Text = "show translation";
            this.cbTranslation.UseVisualStyleBackColor = true;
            this.cbTranslation.CheckStateChanged += new System.EventHandler(this.cbTranslation_CheckStateChanged);
            // 
            // flpTranslationOption
            // 
            this.flpTranslationOption.AutoSize = true;
            this.flpTranslationOption.BackColor = System.Drawing.Color.Transparent;
            this.flpTranslationOption.Controls.Add(this.label16);
            this.flpTranslationOption.Controls.Add(this.cbTraSrcType);
            this.flpTranslationOption.Controls.Add(this.label10);
            this.flpTranslationOption.Controls.Add(this.cbTraDstType);
            this.flpTranslationOption.Location = new System.Drawing.Point(3, 29);
            this.flpTranslationOption.Name = "flpTranslationOption";
            this.flpTranslationOption.Size = new System.Drawing.Size(413, 30);
            this.flpTranslationOption.TabIndex = 19;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(26, 3);
            this.label16.Margin = new System.Windows.Forms.Padding(26, 3, 3, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(147, 16);
            this.label16.TabIndex = 17;
            this.label16.Text = "translation language";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbTraSrcType
            // 
            this.cbTraSrcType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTraSrcType.FormattingEnabled = true;
            this.cbTraSrcType.Location = new System.Drawing.Point(179, 3);
            this.cbTraSrcType.Name = "cbTraSrcType";
            this.cbTraSrcType.Size = new System.Drawing.Size(100, 24);
            this.cbTraSrcType.TabIndex = 18;
            this.cbTraSrcType.SelectedIndexChanged += new System.EventHandler(this.cbTraSrcType_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(285, 3);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 21);
            this.label10.TabIndex = 2;
            this.label10.Text = "⇒";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbTraDstType
            // 
            this.cbTraDstType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTraDstType.FormattingEnabled = true;
            this.cbTraDstType.Location = new System.Drawing.Point(310, 3);
            this.cbTraDstType.Name = "cbTraDstType";
            this.cbTraDstType.Size = new System.Drawing.Size(100, 24);
            this.cbTraDstType.TabIndex = 20;
            this.cbTraDstType.SelectedIndexChanged += new System.EventHandler(this.cbTraDstType_SelectedIndexChanged_1);
            // 
            // cbShowJoinedPanel
            // 
            this.cbShowJoinedPanel.AutoSize = true;
            this.cbShowJoinedPanel.Checked = true;
            this.cbShowJoinedPanel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowJoinedPanel.Location = new System.Drawing.Point(6, 272);
            this.cbShowJoinedPanel.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.cbShowJoinedPanel.Name = "cbShowJoinedPanel";
            this.cbShowJoinedPanel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cbShowJoinedPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbShowJoinedPanel.Size = new System.Drawing.Size(148, 20);
            this.cbShowJoinedPanel.TabIndex = 19;
            this.cbShowJoinedPanel.Text = "show joined panel";
            this.cbShowJoinedPanel.UseVisualStyleBackColor = true;
            this.cbShowJoinedPanel.CheckStateChanged += new System.EventHandler(this.cbShowJoinedPanel_CheckStateChanged);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(527, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 523);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 523);
            this.panel2.TabIndex = 5;
            // 
            // panDebug
            // 
            this.panDebug.Controls.Add(this.txtLog);
            this.panDebug.Controls.Add(this.flowLayoutPanel3);
            this.panDebug.Controls.Add(this.panel1);
            this.panDebug.Location = new System.Drawing.Point(747, 33);
            this.panDebug.Name = "panDebug";
            this.panDebug.Size = new System.Drawing.Size(849, 251);
            this.panDebug.TabIndex = 14;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Controls.Add(this.cbUniqueID);
            this.flowLayoutPanel3.Controls.Add(this.btnConnection);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(10, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(839, 30);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "UniqueID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbUniqueID
            // 
            this.cbUniqueID.FormattingEnabled = true;
            this.cbUniqueID.Location = new System.Drawing.Point(82, 3);
            this.cbUniqueID.Name = "cbUniqueID";
            this.cbUniqueID.Size = new System.Drawing.Size(121, 24);
            this.cbUniqueID.TabIndex = 15;
            this.cbUniqueID.TextChanged += new System.EventHandler(this.cbUniqueID_TextChanged);
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(209, 3);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(91, 24);
            this.btnConnection.TabIndex = 13;
            this.btnConnection.Text = "Connection";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 251);
            this.panel1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 762);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.menuStrip2);
            this.Font = new System.Drawing.Font("Cascadia Mono Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 473);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TTC - TikTok Comment System For Windows x64";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panMain.ResumeLayout(false);
            this.panComment.ResumeLayout(false);
            this.panComment.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flpViewers.ResumeLayout(false);
            this.flpViewers.PerformLayout();
            this.panConfig.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel8.PerformLayout();
            this.flowLayoutPanel10.ResumeLayout(false);
            this.flowLayoutPanel10.PerformLayout();
            this.flpTranslationOption.ResumeLayout(false);
            this.flpTranslationOption.PerformLayout();
            this.panDebug.ResumeLayout(false);
            this.panDebug.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UnConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugModeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.FlowLayoutPanel flpViewers;
        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Panel panDebug;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbUniqueID;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.Panel panConfig;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPrivate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Panel panComment;
        private Controls.RealTimeDataControl dcViewers;
        private Controls.RealTimeDataControl dcLikes;
        private Controls.RealTimeDataControl dcFollowers;
        private Controls.RealTimeDataControl dcJoined;
        private Controls.RealTimeDataControl dcComments;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAlterPrivate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private System.Windows.Forms.CheckBox cbTranslation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openCommentRecordFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLiveStreamHistoryFolderToolStripMenuItem;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flpTranslationOption;
        private System.Windows.Forms.Label label16;
        private Controls.CommentListControl clc;
        private System.Windows.Forms.ComboBox cbCommentFontSize;
        private System.Windows.Forms.ComboBox cbJoinedFontSize;
        private System.Windows.Forms.ComboBox cbViewerFontSize;
        private Controls.JoinedListControl jlc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.TextBox txtClipboard;
        private System.Windows.Forms.ComboBox cbTraSrcType;
        private System.Windows.Forms.ComboBox cbTraDstType;
        private System.Windows.Forms.ToolStripMenuItem restoreCommentRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.CheckBox cbShowJoinedPanel;
    }
}
