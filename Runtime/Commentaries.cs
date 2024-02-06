using OpenBLive.Runtime.Data;

namespace ZhengDianWaiBao.CommonLive
{
    public class Commentaries : MessageBase
    {
        public Commentaries(Dm dm) : base(dm.uid, dm.userName, dm.roomId, dm.userFace,dm.timestamp ,dm.fansMedalLevel,
            dm.fansMedalName, dm.fansMedalWearingStatus, dm.guardLevel)
        {
            Content = dm.msg;
        }

        public string Content { get; private set; }
    }
}