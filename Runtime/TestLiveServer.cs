#region

using System;
using Cysharp.Threading.Tasks;
using OpenBLive.Runtime.Data;

#endregion

namespace PunctualSolutionsTool.CommonLive
{
    class TestLiveServer : ILiveServer
    {
        UniTask<InitData> ILiveServer.Init() => new(new());

        public event Action<Guard>        OnGuardBuy;
        public event Action<Gift>         OnGift;
        public event Action<Commentaries> OnCommentaries;
        public event Action<LikeInfo>     OnLike;

        public UniTask Close() => new();

        public void SendCommentaries(Commentaries commentaries) => OnCommentaries?.Invoke(commentaries);

        public void SendGift(Gift gift) => OnGift?.Invoke(gift);

        public void SendLike(LikeInfo like) => OnLike?.Invoke(like);
    }
}