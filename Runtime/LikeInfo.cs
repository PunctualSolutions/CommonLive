#region

using ByteDance.LiveOpenSdk.Push;
using Like = PunctualSolutions.CommonLive.DouYinInfo.Like;

#endregion

namespace PunctualSolutionsTool.CommonLive
{
    public class LikeInfo : MessageInfo
    {
        public LikeInfo(ILikeMessage likeMessage) : base(likeMessage)
        {
            Count    = likeMessage.LikeCount;
            UserInfo = new(likeMessage.Sender);
        }

        public LikeInfo(Like likeMessage) : base(likeMessage.OpenId, string.Empty, 0)
        {
            Count    = likeMessage.Number;
            UserInfo = new(likeMessage);
        }

        public long     Count    { get; }
        public UserInfo UserInfo { get; }
    }
}