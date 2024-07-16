#region

using System;
using ByteDance.LiveOpenSdk.Push;
using PunctualSolutionsTool.Tool;

#endregion

namespace PunctualSolutionsTool.CommonLive
{
    public class MessageInfo
    {
        public MessageInfo(string id, string type, long timestamp) : this(id, type, timestamp.UnixTimeStampToDateTime())
        {
        }

        public MessageInfo(string id, string type, DateTime sendTime)
        {
            Id       = id;
            Type     = type;
            SendTime = sendTime;
        }

        public MessageInfo(long     timestamp) => SendTime = timestamp.UnixTimeStampToDateTime();
        public MessageInfo(DateTime sendTime) => SendTime = sendTime;

        public MessageInfo(IPushMessage pushMessage) : this(pushMessage.MsgId, pushMessage.MsgType, pushMessage.Timestamp)
        {
        }

        /// <summary>
        ///     douyin only
        /// </summary>
        public string Id { get; protected set; }

        /// <summary>
        ///     douyin only
        /// </summary>
        public string Type { get; protected set; }

        public DateTime SendTime { get; protected set; }

        public override string ToString() => $"{Id}, {Type}, {SendTime}";
    }
}