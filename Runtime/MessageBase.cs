using System;
using PunctualSolutionsTool.Tool;

namespace PunctualSolutionsTool.CommonLive
{
    public abstract class MessageBase
    {
        protected MessageBase(long userId, string userName, long roomId, string face, long timestamp, long fansMedalLevel = 0,
            string fansMedalName = "", bool fansMedalWearingStatus = false, long guardLevel = 0)
        {
            UserId = userId;
            UserName = userName;
            RoomId = roomId;
            Face = face;
            FansMedalLevel = fansMedalLevel;
            FansMedalName = fansMedalName;
            FansMedalWearingStatus = fansMedalWearingStatus;
            GuardLevel = guardLevel;
            SendTime = timestamp.UnixTimeStampToDateTime();
        }

        /// <summary>
        /// bilibili is uid
        /// </summary>
        public long UserId { get; protected set; }

        public string UserName { get; protected set; }
        public long RoomId { get; protected set; }
        public string Face { get; protected set; }

        /// <summary>
        /// bilibili captive
        /// </summary>
        public long FansMedalLevel { get; protected set; }

        /// <summary>
        /// bilibili captive
        /// </summary>
        public string FansMedalName { get; protected set; }

        /// <summary>
        /// bilibili captive
        /// </summary>
        public bool FansMedalWearingStatus { get; protected set; }

        /// <summary>
        /// bilibili captive
        /// </summary>
        public long GuardLevel { get; protected set; }

        public DateTime SendTime { get; protected set; }
    }
}