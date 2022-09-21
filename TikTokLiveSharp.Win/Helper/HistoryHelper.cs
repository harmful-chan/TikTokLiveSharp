using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TikTokLiveSharp.Tools.Extensions;
using TikTokLiveSharp.Win.Models;

namespace TikTokLiveSharp.Win.Helper
{
    internal static class HistoryHelper
    {
        private readonly static string _historyTempPath = ObjectSaveHelper.ObjectTempPath;

        internal static string HistoryTempPath => _historyTempPath;

        public static async Task<RoomData[]> GetRoomDates()
        {
            string[] strings = Directory.GetFiles(_historyTempPath);
            string[] ss = strings.Where(s => !Path.GetFileNameWithoutExtension(s).Contains('_')).ToArray();
            RoomData[] roomDatas = new RoomData[ss.Length];
            for (int i = 0; i < ss.Length; i++)
            {
                roomDatas[i] = await ObjectSaveHelper.ReStoreAsync<RoomData>(ss[i]);
            }

            return roomDatas;
        }

        public static bool RoomExists(string roomID)
        {
            string _historyRoomFileName = Path.Combine(_historyTempPath, roomID.Legal() ? roomID : "room");
            return File.Exists(_historyRoomFileName);
        }
        public static async Task<bool> SaveRoomAsync(RoomData room)
        {
            string _historyRoomFileName = Path.Combine(_historyTempPath, (room.RoomID.Legal() ? room.RoomID : "room"));
            return await ObjectSaveHelper.SaveAsync(_historyRoomFileName, room);
        }

        public static async Task<RoomData> RecoverRoomAsync(string roomID)
        {
            string _historyRoomFileName = Path.Combine(_historyTempPath, roomID.Legal() ? roomID : "room");
            return await ObjectSaveHelper.ReStoreAsync<RoomData>(_historyRoomFileName);
        }

        public static async Task<bool> SaveCommentAsync(string roomID, List<Comment> commentList)
        {
            string _historyCommentFileName = Path.Combine(_historyTempPath, $"{roomID}_comment");
            return await ObjectSaveHelper.SaveAsync<List<Comment>>(_historyCommentFileName, commentList);
        }

        public static async Task<List<Comment>> RecoverCommentAsync(string roomID)
        {
            string _historyRoomFileName = Path.Combine(_historyTempPath, $"{roomID}_comment");
            return await ObjectSaveHelper.ReStoreAsync<List<Comment>>(_historyRoomFileName);
        }

        public static async Task<bool> SaveJoinedAsync(string roomID, List<string> joinedList)
        {
            string _historyJoinedFileName = Path.Combine(_historyTempPath, $"{roomID}_joined");
            return await ObjectSaveHelper.SaveAsync<List<string>>(_historyJoinedFileName, joinedList);
        }

        public static async Task<List<string>> RecoverJoinedAsync(string roomID)
        {
            string _historyRoomFileName = Path.Combine(_historyTempPath, $"{roomID}_joined");
            return await ObjectSaveHelper.ReStoreAsync<List<string>>(_historyRoomFileName);
        }

    }
}
