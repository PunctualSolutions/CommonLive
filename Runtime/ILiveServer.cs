#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using OpenBLive.Runtime.Data;
using PunctualSolutions.Tool.UniTask;
using PunctualSolutionsTool.Tool;

#endregion

namespace PunctualSolutionsTool.CommonLive
{
    public interface ILiveServer
    {
        public UniTask<InitData>          Init();
        public event Action<Guard>        OnGuardBuy;
        public event Action<Gift>         OnGift;
        public event Action<Commentaries> OnCommentaries;
        public event Action<LikeInfo>     OnLike;
        public UniTask                    Close();

        public Task<Guard> WaitGuardBuy(CancellationTokenSource source = default) =>
                TaskConvertTool.WaitTask<Guard>(x => OnGuardBuy += x, x => OnGuardBuy -= x, source);

        public Task<Gift> WaitGift(CancellationTokenSource source = default) =>
                TaskConvertTool.WaitTask<Gift>(x => OnGift += x, x => OnGift -= x, source);

        public Task<Commentaries> WaitCommentaries(CancellationTokenSource source = default) =>
                TaskConvertTool.WaitTask<Commentaries>(x => OnCommentaries += x, x => OnCommentaries -= x, source);

        public Task<LikeInfo> WaitLike(CancellationTokenSource source = default) =>
                TaskConvertTool.WaitTask<LikeInfo>(x => OnLike += x, x => OnLike -= x, source);
    }
}