using System;
using OpenBLive.Runtime.Data;
using ZhengDianWaiBao.Tool;

namespace ZhengDianWaiBao.CommonLive
{
    public class AdvancedComments : MessageBase
    {
        public AdvancedComments(SuperChat superChat) : base(superChat.uid, superChat.userName, superChat.roomId,
            superChat.userFace, superChat.timeStamp, superChat.fansMedalLevel, superChat.fansMedalName,
            superChat.fansMedalWearingStatus, superChat.guardLevel)
        {
            Id = superChat.messageId;
            Message = superChat.message;
            Rmb = superChat.rmb;
            StartTime = superChat.startTime.UnixTimeStampToDateTime();
            EndTime = superChat.endTime.UnixTimeStampToDateTime();
        }

        public long Id { get; private set; }
        public string Message { get; private set; }
        public long Rmb { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
    }
}