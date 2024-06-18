using System;
using OpenBLive.Runtime.Data;

namespace PunctualSolutionsTool.CommonLive
{
    public class Commentaries : MessageBase
    {
        public Commentaries(Dm dm) : base(dm.uid, dm.userName, dm.roomId, dm.userFace, dm.timestamp, dm.fansMedalLevel,
            dm.fansMedalName, dm.fansMedalWearingStatus, dm.guardLevel)
        {
            Content = dm.msg;
        }

        public Commentaries(long uid, string content) : base(uid, string.Empty, 0, "", new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds())
        {
            Content = content;
        }

        public string Content { get; private set; }

        public override string ToString() => $"{base.ToString()}, Content: {Content}";
    }
}