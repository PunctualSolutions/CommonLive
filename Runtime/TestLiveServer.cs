using System;
using Cysharp.Threading.Tasks;
using OpenBLive.Runtime.Data;

namespace PunctualSolutionsTool.CommonLive
{
    internal class TestLiveServer : ILiveServer
    {
        public void SendCommentaries(Commentaries commentaries)
        {
            OnCommentaries?.Invoke(commentaries);
        }

        public void SendGift(Gift gift)
        {
            OnGift?.Invoke(gift);
        }

        UniTask<InitData> ILiveServer.Init()
        {
            return new UniTask<InitData>(new InitData());
        }

        public event Action<Guard> OnGuardBuy;
        public event Action<Gift> OnGift;
        public event Action<Commentaries> OnCommentaries;
        public event Action<LikeInfo> OnLike;

        public UniTask Close()
        {
            return new UniTask();
        }
    }
}