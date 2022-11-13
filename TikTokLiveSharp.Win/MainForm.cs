using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TikTokLiveSharp.Client;
using TikTokLiveSharp.Client.Proxy;
using TikTokLiveSharp.Client.Requests;
using TikTokLiveSharp.Models;
using TikTokLiveSharp.Tools.Extensions;
using TikTokLiveSharp.Tools.Toolset;
using TikTokLiveSharp.Win.Controls;
using TikTokLiveSharp.Win.Helper;
using TikTokLiveSharp.Win.Models;



namespace TikTokLiveSharp.Win
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(string uniqueID, int port = -1)
        {
            _proxyPort = port;
            _uniqueID = uniqueID;
            InitializeComponent();
        }

        private string _uniqueID;

        private int _proxyPort;
        private string _srcTraType;
        private string _dstTraType;

        private async void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(850, 600);

            SwitchMode(this.debugModeToolStripMenuItem);
            InitLogger();
            InitPrivate();

            // 读取历史房间信息
            RoomData[] roomDatas = await HistoryHelper.GetRoomDates();
            Array.Sort(roomDatas);
            ToolStripMenuItem[] ts = new ToolStripMenuItem[roomDatas.Length];
            for (int i = 0; i < roomDatas.Length; i++)
            {
                ts[i] = new ToolStripMenuItem();
                ts[i].Text = $"{roomDatas[i].UniqueID} | {roomDatas[i].RoomID}";
                ts[i].Click += new EventHandler(this.ts_Click);
            }
            restoreCommentRecordsToolStripMenuItem.DropDownItems.AddRange(ts);
            LogHelper.Info("read historical room information");



            bool isDirect = false;
            Uri uri = null ;
            // 代理初始化
            if ( _proxyPort < 0)
            {
                isDirect = await ProxyHelper.DirectTiktok();
                uri = await ProxyHelper.CheckAvailableProxy();
            }else if( _proxyPort == 0)
            {
                isDirect = true;
            }
            else
            {
                isDirect = false;
                if (await ProxyHelper.Check("127.0.0.1", _proxyPort, "customize"))
                {
                    uri = new Uri($"http://127.0.0.1:{_proxyPort}");
                }
            }


            LiveCenter.IsDirect = isDirect;
            LiveCenter.Proxy = uri;

            // 转换器初始化
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.UseProxy = !isDirect;
            httpClientHandler.Proxy = new WebProxy(uri);
            HttpClient httpClient = new HttpClient(httpClientHandler);
            httpClient.Timeout = TimeSpan.FromSeconds(10);
            WebpConverter.HttpClient = httpClient;

            // 设置控件
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            this.cbCommentFontSize.SelectedIndex = 5;    // 14
            this.cbJoinedFontSize.SelectedIndex = 5;
            this.cbViewerFontSize.SelectedIndex = 5;
            this.cbUniqueID.Text = _uniqueID;
            clc.RawDoubleClickHandler += Cpc_DoubleClickHandler;
            clc.ChineseDoubleClickHandler += Clc_ChineseDoubleClickHandler;
            Language[] ls = new Language[]
            {
                new Language{ Name = "Auto", Code = "auto" },
                new Language{ Name = "English", Code = "en" },
                new Language{ Name = "Chinese", Code = "zh-CH"},
                new Language{ Name = "Malay", Code =  "ms"}
            };
            cbTraDstType.DataSource = ls;
            cbTraDstType.DisplayMember = "Name";
            cbTraDstType.ValueMember = "Code";
            cbTraSrcType.DataSource = (Language[])ls.Clone();
            cbTraSrcType.DisplayMember = "Name";
            cbTraSrcType.ValueMember = "Code";
            cbTraSrcType.SelectedIndex = 0;
            cbTraDstType.SelectedIndex = 2;

            
            InitConnectWaitTimer();
            InitTaskTimer();
            //InitFakeLive();
            //FakeTimerStart();

            if (_uniqueID.Legal())
            {
                btnConnection_Click(this.btnConnection, null);
            }
        }


        #region _private

        private Private _private;
        private void InitPrivate()
        {
            try
            {
                string str = PrivateHelper.GetPrivate();
                _private = JsonSerializer.Deserialize<Private>(str);
                
                // config
                txtPrivate.Text = str;

                // uniqueid list
                this.cbUniqueID.Items.AddRange(_private.UniqueIDList);

            }
            catch (Exception ex)
            {
                this.txtPrivate.ForeColor = Color.Red;
                LogHelper.Error(ex.Message);
            }
        }
        #endregion

        #region Logger
        private void InitLogger()
        {
            LogHelper.NewLineHandler += (sender, msg) =>
            {
                if( msg.Legal())
                {
                    this.BeginInvoke(new MethodInvoker(async () =>
                    {
                        if (!txtLog.Text.EndsWith("\r\n"))
                        {
                            txtLog.Text += "\r\n";
                        }
                        txtLog.AppendText(msg);
                    }));
                }


            };

            LogHelper.AppendHandler += (sender, msg) =>
            {
                if (msg.Legal())
                {
                    this.BeginInvoke(new MethodInvoker(async () =>
                    {
                        txtLog.AppendText(msg);
                    }));
                }
            };
        }
        #endregion

        #region _timerConnectWait
        private System.Windows.Forms.Timer _timerConnectWait; // 点击连接后等待计时器
        private int _timeConnectCount = 0;
        private void InitConnectWaitTimer()
        {
            _timerConnectWait = new System.Windows.Forms.Timer();
            _timerConnectWait.Interval = 1000;
            _timerConnectWait.Tick += _timerClientWait_Tick;
        }
        private void ConnectWaitTimerStart()
        {
            _timeConnectCount = 0;
            _timerConnectWait.Enabled = true;
            _timerConnectWait.Start();
        }
        private void ConnectWaitTimerStop()
        {
            _timerConnectWait.Stop();
            _timerConnectWait.Enabled = false;
            _timeConnectCount = 0;
        }
        private void _timerClientWait_Tick(object sender, EventArgs e)
        {
            _timeConnectCount++;
            LogHelper.Info($"connecting ... {_timeConnectCount}");
        }
        #endregion
        //Hans is a legend, this is some hidden code for him to find haha
        //I also think so
        #region _timerTask
        private System.Windows.Forms.Timer _timerTask; 
        private int _timeTaskCount;

        private void InitTaskTimer()
        {
            _timerTask = new System.Windows.Forms.Timer();
            _timerTask.Interval = 10*1000;
            _timerTask.Tick += _timerTask_Tick;
        }

        private async void _timerTask_Tick(object sender, EventArgs e)
        {
            _timeTaskCount++;

            Live live = LiveCenter.GetCurrentLive();
            if (null != live)
            {
                live.RoomData.UploadAddress = await ExtractExportIPAsync();

                if (live.Client.Connected)
                {
                    if (await HistoryHelper.SaveRoomAsync(live.RoomData.Clone()))
                    {
                        LogHelper.Info($"save room ... {live.RoomData.RoomID}");
                    }

                    if (await HistoryHelper.SaveCommentAsync(live.RoomData.RoomID, live.CommentList))
                    {
                        LogHelper.Append($" comment ..");
                    }
                    if (await HistoryHelper.SaveJoinedAsync(live.RoomData.RoomID, live.joinedList))
                    {
                        LogHelper.Append($" joined ...");
                    }
                }
            }
        }
        private void TaskTimerStart()
        {
            _timeTaskCount = 0;
            _timerTask.Enabled = true;
            _timerTask.Start();
        }
        private void TaskTimerStop()
        {
            _timerTask.Stop();
            _timerTask.Enabled = false;
            _timeTaskCount = 0;
        }

        private async Task<string> ExtractExportIPAsync()
        {
            string ip = "";
            await Task<string>.Run(() =>
            {
                try
                {
                    using (WebClient _client = new WebClient())
                    {
                        Encoding encode = Encoding.GetEncoding("utf-8");
                        _client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.84 Safari/537.36");
                        _client.Credentials = CredentialCache.DefaultCredentials;
                        var pageData = _client.DownloadData(new Uri("http://cip.cc"));
                        string page = encode.GetString(pageData);
                        string reg = @"(?:(?:(25[0-5])|(2[0-4]\d)|((1\d{2})|([1-9]?\d)))\.){3}(?:(25[0-5])|(2[0-4]\d)|((1\d{2})|([1-9]?\d)))";
                        Match m = Regex.Match(page, reg);
                        ip = m.Success ? m.Value : null;
                    }
                }catch(Exception e)
                {
                    ip = "";
                }
            });
            return ip;
        }

        #endregion

        #region _timerFake
        private System.Windows.Forms.Timer _timerFake;
        private int _timerFakeCount;
        private List<string> nameList = null;
        private bool _isFakeActive = false;
        private void InitFakeLive()
        {
            _isFakeActive = true;
            Live live = LiveCenter.CreateLive();
            LiveCenter.SetCurrentLive(live);
            RoomData roomData = live.RoomData;
            roomData.SetDisplayControl(this);
            this.txtRoomID.DataBindings.Clear();
            this.txtRoomID.DataBindings.Add(new Binding("Text", roomData, "RoomID"));
            this.dcViewers.DataBindings.Clear();
            this.dcViewers.DataBindings.Add(new Binding("Value", roomData, "Viewers"));
            this.dcLikes.DataBindings.Clear();
            this.dcLikes.DataBindings.Add(new Binding("Value", roomData, "Likes"));
            this.dcFollowers.DataBindings.Clear();
            this.dcFollowers.DataBindings.Add(new Binding("Value", roomData, "Followers"));
            this.dcJoined.DataBindings.Clear();
            this.dcJoined.DataBindings.Add(new Binding("Value", roomData, "Joined"));
            this.dcComments.DataBindings.Clear();
            this.dcComments.DataBindings.Add(new Binding("Value", roomData, "Comments"));

            _timerFake = new System.Windows.Forms.Timer();
            _timerFake.Interval = 1000;
            _timerFake.Tick += _timerFake_Tick;
            nameList = new List<string>();
        }

        private async void _timerFake_Tick(object sender, EventArgs e)
        {
            _timerFakeCount++;
            Live live = LiveCenter.GetCurrentLive();
            if (live != null)
            {
                // 每秒加入3人
                if (_timerFakeCount % 3 == 0)
                {
                    string v = ImmediateName.GenerateSurname();
                    nameList.Add(v);
                    live.RoomData.Joined++;
                    live.RoomData.Viewers++;
                    live.RoomData.Likes += 7;
                    live.joinedList.Add(v);
                    jlc.JoinedListAppend(v);
                }


                // 间隔5秒 随机退出若干人
                if (_timerFakeCount % 5 == 0)
                {
                    int c = new Random().Next(0, nameList.Count - 1);
                    for (int i = 0; i < c; i++)
                    {
                        nameList.RemoveAt(0);
                    }
                    live.RoomData.Viewers = nameList.Count;
                }

                // 间隔2秒 随机人员发送评论
                if (_timerFakeCount % 3 == 0 && nameList.Count > 1)
                {
                    int c = new Random().Next(0, 2);
                    int s = new Random().Next(0, nameList.Count - 1);
                    for (int i = s, j = 0; i < nameList.Count && j < c; i++, j++)
                    {
                        string name = nameList.ElementAt(i);

                        Comment comment = new Comment();
                        comment.NickName = name;
                        comment.Raw = "like this " + i;
                        comment.IsTranslate = true;
                        comment.IconUrl = @"https://p16-webcast.tiktokcdn.com/webcast-va/7117900406071577349~tplv-resize:400:400.webp";
                        comment.Chinese = await Translate.GetGoogleApiResAsync(comment.Raw, dstType:_dstTraType, srcType:_srcTraType, LiveCenter.Proxy);
                        live.RoomData.Comments++;
                        live.CommentList.Add(comment);
                        clc.CommentListAppend(comment);
                    }
                }

                // 间隔13秒 关注+1
                if (_timerFakeCount % 13 == 0 && nameList.Count > 1)
                {
                    live.RoomData.Followers++;
                    int s = new Random().Next(0, nameList.Count - 1);
                    string name = nameList.ElementAt(s);
                    FollowComment fc = new FollowComment(name);
                    live.CommentList.Add(fc);
                    clc.CommentListAppend(fc);
                }

            }
            

        }
        private void FakeTimerStart()
        {
            _timerFakeCount = 0;
            _timerFake.Enabled = true;
            _timerFake.Start();
        }
        private void FakeTimerStop()
        {
            _timerFake.Stop();
            _timerFake.Enabled = false;
            _timerFakeCount = 0;
        }

        #endregion


        private string ExtractSessionIDFromCookies(string json)
        {
            string sessionID = null;
            try
            {
                string str = json.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");
                LogHelper.Info("read ... ");
                if (!str.Contains('"') && !str.Contains(';') && !str.Contains(',') && !str.Contains('.'))
                {
                    LogHelper.Append("string " + str);
                    sessionID = str;
                }
                else if (str.Length > 50)
                {
                    Models.Cookie[] cookies = JsonSerializer.Deserialize<Models.Cookie[]>(str);
                    if (cookies != null)
                    {
                        LogHelper.Append("json " + str.Substring(0, 40) + "...");
                        Models.Cookie cookie = cookies.Where(c => c.name.Equals("sessionid")).FirstOrDefault();
                        sessionID = cookie?.value;
                    }
                }
                else
                {
                    LogHelper.Append("error");
                }

                if (sessionID.Legal())
                {
                    LogHelper.Info("read sessionid ... " + sessionID);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Append("error");
            }
            return sessionID;
        }

        private bool CheckLive()
        {
            // 测试数据
            if(LogHelper.Assert("fake live center", "yes", "false", _isFakeActive))
            {
                return false;
            }


            Live live = LiveCenter.GetCurrentLive();
            // 是否正在使用直播间
            bool isAvtive = LogHelper.Assert("active live center", "yes", "false", null != live);
            bool isConnected = false;
            if (isAvtive)
            {
                // 直播间已连接
                isConnected = LogHelper.Assert("connecting", "yes", "no", live.Client.Connected);
                if( isConnected)
                {
                    return false;
                }
            }

            bool isDirect = LogHelper.Assert("direct", "yes", "no", LiveCenter.IsDirect);
            bool isProxy = LogHelper.Assert("proxy", "yes", "false", LiveCenter.Proxy != null);
            if( isProxy)
            {
                LogHelper.Assert("proxy_url", LiveCenter.Proxy.AbsoluteUri, "false", true);
            }
            if( !isProxy && !isDirect)
            {
                return false;
            } 
            // 创建直播间
            bool isCreate = false;
            if(LogHelper.Assert("create live u_id", _uniqueID, "false", _uniqueID.Legal()))
            {
                isCreate = isAvtive ? live.RoomData.UniqueID != _uniqueID : true;
            }
            if (isCreate)    // 打算创建直播间
            {
                Live l = LiveCenter.CreateLive(_uniqueID);

                if(l.Client == null)
                {
                    RotatingProxy rotatingProxy = null;
                    TikTokLiveClient tc;
                    if (!isDirect && TikTokHttpRequest.WebProxy == null)
                    {
                        rotatingProxy = new RotatingProxy(isEnabled: true, RotationSettings.PINNED, LiveCenter.Proxy.AbsoluteUri);
                        tc = new TikTokLiveClient(_uniqueID, proxyHandler: rotatingProxy, timeout: TimeSpan.FromSeconds(15));
                    }
                    else
                    {
                        tc = new TikTokLiveClient(_uniqueID, timeout: TimeSpan.FromSeconds(15));
                    }

                    tc.OnConnected += _tiktokClient_OnConnected;
                    tc.OnDisconnected += _tiktokClient_OnDisconnected;
                    tc.OnViewerCountUpdated += _tiktokClient_OnViewerCountUpdated;
                    tc.OnJoin += _tiktokClient_OnJoin;
                    tc.OnCommentRecieved += _tiktokClient_OnCommentRecieved;
                    tc.OnLikesRecieved += _tiktokClient_OnLikesRecieved;
                    tc.OnFollow += _tiktokClient_OnFollow;
                    tc.OnShare += _tiktokClient_OnShare;
                    l.Client = tc;
                }
              


                RoomData roomData = l.RoomData;
                roomData.SetDisplayControl(this);
                roomData.SetPrintLog(true);
                this.txtRoomID.DataBindings.Clear();
                this.txtRoomID.DataBindings.Add(new Binding("Text", roomData, "RoomID"));
                this.dcViewers.DataBindings.Clear();
                this.dcViewers.DataBindings.Add(new Binding("Value", roomData, "Viewers"));
                this.dcLikes.DataBindings.Clear();
                this.dcLikes.DataBindings.Add(new Binding("Value", roomData, "Likes"));
                this.dcFollowers.DataBindings.Clear();
                this.dcFollowers.DataBindings.Add(new Binding("Value", roomData, "Followers"));
                this.dcJoined.DataBindings.Clear();
                this.dcJoined.DataBindings.Add(new Binding("Value", roomData, "Joined"));
                this.dcComments.DataBindings.Clear();
                this.dcComments.DataBindings.Add(new Binding("Value", roomData, "Comments"));


                this.clc.FontSize = l.CommentFontSize;
                this.jlc.FontSize = l.JoinedFontSize;
                foreach (RealTimeDataControl item in this.flpViewers.Controls)
                {
                    if(item is RealTimeDataControl r)
                    {
                        r.FontSize = l.ViewerFontSize;
                    }  
                }
                LiveCenter.SetCurrentLive(l);

                return true;
            }
           
            return false;
        }

        private async void ConnectTiktok()
        {
            if (CheckLive())
            {
                try
                {
                    Live live = LiveCenter.GetCurrentLive();
                    ConnectWaitTimerStart();
                    await Task.Run(() => live.Client.Run());
                }
                catch (Exception ex)
                {
                    LogHelper.Error("failed to connect to live room");
                    LogHelper.Error(ex.Message);
                    DisConnectTiktok();
                    this.clc.CommentListAppend(new ErrorComment("connect error in the live room, please restart the software after the network is normal."));
                }

            }
        }
        private async void DisConnectTiktok()
        {
            await LiveCenter.GetCurrentLive().Client.Stop();
            LiveCenter.SetCurrentLive(null);
            ConnectWaitTimerStop();
            TaskTimerStop();
            LogHelper.Info("disconnection");
        }

        private void _tiktokClient_OnShare(object sender, Events.ShareEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                ShareComment s = new ShareComment(e.User.uniqueId);
                LiveCenter.GetCurrentLive().CommentList.Add(s);
                clc.CommentListAppend(s);
            }));
            LogHelper.Webcast($"follow {e.User.Nickname}");
        }
        private void _tiktokClient_OnFollow(object sender, User e)
        {

            LiveCenter.GetCurrentLive().RoomData.Followers++;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                FollowComment f = new FollowComment(e.Nickname);
                LiveCenter.GetCurrentLive().CommentList.Add(f);
                clc.CommentListAppend(f);
            }));
            LogHelper.Webcast($"follow {e.Nickname}");
        }
        private void _tiktokClient_OnLikesRecieved(object sender, WebcastLikeMessage e)
        {
            LiveCenter.GetCurrentLive().RoomData.Likes = e.totalLikeCount;
            LogHelper.Webcast($"like total{e.totalLikeCount} current {e.likeCount} ");
        }
        private void _tiktokClient_OnCommentRecieved(object sender, WebcastChatMessage e)
        {
            Live live = LiveCenter.GetCurrentLive();
            live.RoomData.Comments++;
            this.BeginInvoke(new MethodInvoker(async () =>
            {
                Comment c = new Comment();
                c.IconUrl = e.User.profilePicture.Urls.FirstOrDefault();
                c.NickName = e.User.Nickname;
                c.Raw = e.Comment;
                c.IsTranslate = this.cbTranslation.Checked;
                c.Chinese = await Translate.GetGoogleApiResAsync(c.Raw, dstType:_dstTraType, srcType: _srcTraType, LiveCenter.Proxy);
                live.CommentList.Add(c);
                this.clc.CommentListAppend(c);
            }));
            LogHelper.Webcast($"{e.User.profilePicture.Urls.FirstOrDefault()}");
            string fileName = live.RoomData.UniqueID.Replace('.', '_') + '_' + live.RoomData.RoomID + ".txt";
            LogHelper.Record($"{e.User.Nickname} → {e.Comment}", fileName);
        }
        private void _tiktokClient_OnViewerCountUpdated(object sender, WebcastRoomUserSeqMessage e)
        {
            LiveCenter.GetCurrentLive().RoomData.Viewers = e.viewerCount;
            LogHelper.Webcast($"people current {e.viewerCount}");
        }
        private void _tiktokClient_OnJoin(object sender, User e)
        {
            LiveCenter.GetCurrentLive().RoomData.Joined += 1;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                LiveCenter.GetCurrentLive().joinedList.Add(e.Nickname);
                jlc.JoinedListAppend(e.Nickname);
            }));

            LogHelper.Webcast($"{e.Nickname} ---> joined");
        }
        private void _tiktokClient_OnDisconnected(object sender, TikTokLiveSharp.Events.ConnectionEventArgs e)
        {
            LogHelper.Info($"connection ... {e.IsConnected}");
        }
        private void _tiktokClient_OnConnected(object sender, TikTokLiveSharp.Events.ConnectionEventArgs e)
        {

            ConnectWaitTimerStop();
            Live live = LiveCenter.GetCurrentLive();
            RoomData roomData = live.RoomData;
            roomData.SetPrintLog(true);
            roomData.RoomID = live.Client.RoomID;
            roomData.UniqueID = live.Client.UniqueID;
            LogHelper.Info($"connection ... {e.IsConnected}");
            this.BeginInvoke(new MethodInvoker(async () =>
            {
                SwitchMode(this.normalToolStripMenuItem);
                this.Text += $" [{roomData.UniqueID}]";
                if (HistoryHelper.RoomExists(roomData.RoomID))
                {

                    live.CommentList = await HistoryHelper.RecoverCommentAsync(roomData.RoomID);
                    clc.CommentListClear();
                    clc.CommentListAppendRange(live.CommentList);
                    live.joinedList = await HistoryHelper.RecoverJoinedAsync(roomData.RoomID);
                    jlc.JoinedListClear();
                    jlc.JoinedListAppendRange(live.joinedList);
                    RoomData oRoom = await HistoryHelper.RecoverRoomAsync(roomData.RoomID);
                    roomData.Viewers = oRoom.Viewers;
                    roomData.Likes = oRoom.Likes;
                    roomData.Followers = oRoom.Followers;
                    roomData.Joined = oRoom.Joined;
                    roomData.Comments = oRoom.Comments;
                    LogHelper.Info($"recover room ... {roomData.RoomID}");

                }
                TaskTimerStart();
            }));
        }

        private void SwitchMode(object sender)
        {
            this.debugModeToolStripMenuItem.Checked = false;
            this.configureToolStripMenuItem.Checked = false;
            this.normalToolStripMenuItem.Checked = false;
            (sender as ToolStripMenuItem).Checked = true;

            this.panComment.Visible = false;
            this.panComment.Dock = DockStyle.None;
            this.panDebug.Visible = false;
            this.panDebug.Dock = DockStyle.None;
            this.panConfig.Visible = false;
            this.panConfig.Dock = DockStyle.None;

            switch ((sender as ToolStripMenuItem).Text)
            {
                case "configure":
                    this.panConfig.Visible = true;
                    this.panConfig.Dock = DockStyle.Fill;
                    LogHelper.Info("switch mode ... Configure");
                    break;
                case "debug":
                    this.panDebug.Visible = true;
                    this.panDebug.Dock = DockStyle.Fill;
                    LogHelper.Info("switch mode ... Debug");
                    break;
                default:
                    this.panComment.Visible = true;
                    this.panComment.Dock = DockStyle.Fill;
                    LogHelper.Info("switch mode ... Normal");
                    break;
            }
        }

        private void ConnectionToolStripMenuItem_Click(object sender, EventArgs e) { ConnectTiktok(); }

        private void btnConnection_Click(object sender, EventArgs e) { ConnectTiktok(); }

        private void UnConnectionToolStripMenuItem_Click(object sender, EventArgs e) { DisConnectTiktok();  }

        private void DebugModeToolStripMenuItem_Click(object sender, EventArgs e){ SwitchMode(sender); }

        private void ConfigureToolStripMenuItem_Click(object sender, EventArgs e){ SwitchMode(sender); }

        private void NormalToolStripMenuItem_Click(object sender, EventArgs e) { SwitchMode(sender); }


        private bool _isAlter = false;
        private void btnAlterPrivate_Click(object sender, EventArgs e)
        {
            if( !_isAlter)    // 修改操作
            {
                _isAlter = true;
                this.txtPrivate.BackColor = Color.White;
                this.txtPrivate.ForeColor = SystemColors.WindowText;
                this.txtPrivate.ReadOnly = false;
                this.btnAlterPrivate.Text = "save";
            }
            else    // 保存操作
            {
                string str = this.txtPrivate.Text;
                try
                {
                    Private @private = JsonSerializer.Deserialize<Private>(str);
                    _private = @private;
                    _isAlter = false;
                    this.txtPrivate.BackColor = SystemColors.Control;
                    this.txtPrivate.ReadOnly = true;
                    this.btnAlterPrivate.Text = "alter";
                    this.txtPrivate.ForeColor = SystemColors.WindowText;
                    // 更新combobox
                    string[] us = _private.UniqueIDList;
                    this.cbUniqueID.Items.Clear();
                    this.cbUniqueID.Items.AddRange(us);
                    PrivateHelper.SetPrivate(str);
                }
                catch(JsonException ex)
                {
                    this.txtPrivate.ForeColor = Color.Red;
                }
            }
        }

        private void cbUniqueID_TextChanged(object sender, EventArgs e)
        {
            if (cbUniqueID.Text.Legal())
            {
                _uniqueID = cbUniqueID.Text;
            }
        }

        private void panMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbTranslation_CheckStateChanged(object sender, EventArgs e)
        {
            this.flpTranslationOption.Visible = cbTranslation.Checked;
            clc.IsTranslate = cbTranslation.Checked;
        }

        private void openCommentrecordFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName;
            if (LiveCenter.GetCurrentLive() != null)
            {
                fileName = Path.Combine(LogHelper.RecordTempPath,  _uniqueID.Replace('.', '_') + '_' + LiveCenter.GetCurrentLive().RoomData.RoomID + ".txt");
                if (File.Exists(fileName))
                {
                    System.Diagnostics.Process.Start("explorer.exe", $"/select,{fileName}");
                }
                else
                {
                    System.Diagnostics.Process.Start("explorer.exe", LogHelper.RecordTempPath);
                }
            }
            else
            {
                System.Diagnostics.Process.Start("explorer.exe", LogHelper.RecordTempPath);
            }
        }

        private void openLiveStreamHistoryFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", HistoryHelper.HistoryTempPath);
        }
        private async void  ts_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ts = sender as ToolStripMenuItem;

            if (ts.Text.Legal())
            {
                string[] ss = ts.Text.Split("|");
                string roomid =  ss[1].Trim();
                if (HistoryHelper.RoomExists(roomid))
                {
                    LogHelper.Info($"recover room comment ... {roomid}");
                    List<Comment> comments = await HistoryHelper.RecoverCommentAsync(roomid);
                    clc.CommentListClear();
                    clc.CommentListAppendRange(comments);

                    LogHelper.Info($"recover room hoined last 100 ... {roomid}");
                    List<string> list = await HistoryHelper.RecoverJoinedAsync(roomid);
                    jlc.JoinedListClear();
                    jlc.JoinedListAppendRange(list);
                    RoomData oRoom = await HistoryHelper.RecoverRoomAsync(roomid);

                    dcViewers.Value = oRoom.Viewers;
                    dcLikes.Value = oRoom.Likes;
                    dcFollowers.Value = oRoom.Followers;
                    dcJoined.Value = oRoom.Joined;
                    dcComments.Value = oRoom.Comments;
                    LogHelper.Info($"recover room ... {roomid}");

                }
            }
        }

        private void cbCommentFontSize_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if( int.TryParse(comboBox.Text, out int i))
            {
                if(LiveCenter.GetCurrentLive() != null)
                {
                    LiveCenter.GetCurrentLive().CommentFontSize = i;
                }
                clc.FontSize = i;
            }
        }

        private void cbJoinedFontSize_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (int.TryParse(comboBox.Text, out int i))
            {
                if (LiveCenter.GetCurrentLive() != null)
                {
                    LiveCenter.GetCurrentLive().JoinedFontSize = i;
                }
                jlc.FontSize = i;
            }
        }

        private void cbViewerFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox comboBox = sender as ComboBox;
            if (int.TryParse(comboBox.Text, out int i))
            {
                if (LiveCenter.GetCurrentLive() != null)
                {
                    LiveCenter.GetCurrentLive().ViewerFontSize = i;
                }
                foreach (var item in flpViewers.Controls)
                {
                    if (item is RealTimeDataControl dc)
                    {
                        dc.FontSize = i;
                    }
                }

            }
        }

        private void Cpc_DoubleClickHandler(object sender, string e)
        {
            if (e.Legal())
            {
                string str = e;
                while (str[0] == ' ') str = str.Remove(0, 1);
                txtClipboard.Text = str;
            }

        }


        private async void Clc_ChineseDoubleClickHandler(object sender, string e)
        {
            if (e.Legal())
            {
                Label label = (sender as Label);
                string raw = e;
                if( !label.Text.Replace(clc.ChineseSpilt, "").Legal())
                {
                    label.Text = $"{clc.ChineseSpilt} ...";
                    label.Text =  $"{clc.ChineseSpilt}"+await Translate.GetGoogleApiResAsync(raw, dstType: _dstTraType, srcType: _srcTraType, LiveCenter.Proxy);
                }
            }
        }

        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);

        private void txtRoomID_MouseUp(object sender, MouseEventArgs e)
        {
            HideCaret(((TextBox)sender).Handle);
        }

        private void txtClipboard_MouseUp(object sender, MouseEventArgs e)
        {
            HideCaret(((TextBox)sender).Handle);
        }

        private void cbTraSrcType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).Text.Legal())
            {
                Language language = (sender as ComboBox).SelectedItem as Language;
                _srcTraType = language.Code;
            }
        }
        private void cbTraDstType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if ((sender as ComboBox).Text.Legal())
            {
                Language language = (sender as ComboBox).SelectedItem as Language;
                _dstTraType = language.Code;
            }
        }

        private void cbShowJoinedPanel_CheckStateChanged(object sender, EventArgs e)
        {
            this.scMain.Panel2Collapsed = !this.cbShowJoinedPanel.Checked;
        }
    }
}
