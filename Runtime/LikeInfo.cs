using ByteDance.LiveOpenSdk.Push;

namespace PunctualSolutionsTool.CommonLive
{
    public class LikeInfo : MessageInfo
    {
        public long Count { get; }
        public UserInfo UserInfo { get; }

        public LikeInfo(ILikeMessage likeMessage) : base(likeMessage)
        {
            Count = likeMessage.LikeCount;
            UserInfo = new UserInfo(likeMessage.Sender);
        }
    }
}