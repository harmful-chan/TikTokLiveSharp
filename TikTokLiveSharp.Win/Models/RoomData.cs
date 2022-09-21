using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Windows.Forms;
using TikTokLiveSharp.Win.Helper;

namespace TikTokLiveSharp.Win.Models
{
    internal class RoomData : INotifyPropertyChanged, IComparable<RoomData>
    {
        private Control _control;
        private bool _isPrintLog = false;
        public RoomData()
        {

        }

        public void SetPrintLog(bool flag)
        {
            _isPrintLog = flag;
        }
        public void SetDisplayControl(Control control)
        {
            _control = control;
        }

        public Control GetDisplayControl()
        {
            return _control;
        }

        private string _uniqueID = "";
        public string UniqueID
        {
            get { return _uniqueID; }
            set 
            { 
                _uniqueID = value; SendChangeInfo("UniqueID");
                if (_isPrintLog)
                {
                    LogHelper.Param($"UniqueID ... {_uniqueID}");
                }
            }
        }


        private string _roomID = "";
        public string RoomID
        {
            get { return _roomID; }
            set
            {
                _roomID = value; SendChangeInfo("RoomID");
                if (_isPrintLog)
                {
                    LogHelper.Param($"RoomID ... {_roomID}");
                }
            }
        }


        private long _viewers = 0;
        public long Viewers
        {
            get { return _viewers; }
            set { _viewers = value; SendChangeInfo("Viewers"); }
        }

        private long _likes = 0;
        public long Likes
        {
            get { return _likes; }
            set { _likes = value; SendChangeInfo("Likes"); }
        }

        private long _followers = 0;
        public long Followers
        {
            get { return _followers; }
            set { _followers = value; SendChangeInfo("Followers"); }
        }

        private long _joined = 0;
        public long Joined
        {
            get { return _joined; }
            set { _joined = value; SendChangeInfo("Joined"); }
        }

        private long _comments = 0;
        public long Comments
        {
            get { return _comments; }
            set { _comments = value; SendChangeInfo("Comments"); }
        }
        private string _uploadAddress;
        public string UploadAddress
        {
            get { return _uploadAddress; }
            set
            {
                _uploadAddress = value; SendChangeInfo("UploadAddress");
                if (_isPrintLog)
                {
                    LogHelper.Param($"UploadAddress ... {_uploadAddress}");
                }
            }
        }


        private void SendChangeInfo(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                if( _control !=null)
                {
                    _control.BeginInvoke(new MethodInvoker(() =>
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    }));
                }
                else
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        public RoomData Clone()
        {
            return (RoomData)this.MemberwiseClone();
        }

        public int CompareTo([AllowNull] RoomData other)
        {
            if (other == null) return 1;

            if (_uniqueID.Equals(other._uniqueID))
            {
                return _roomID.CompareTo(other._roomID);
            }
            else
            {
                return _uniqueID.CompareTo(other._uniqueID);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
