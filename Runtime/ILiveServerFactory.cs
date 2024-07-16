#region

using Cysharp.Threading.Tasks;
using UnityEngine;

#endregion

namespace PunctualSolutionsTool.CommonLive
{
    public abstract class ILiveServerFactory
    {
        protected abstract ILiveServer LiveServer { get; }

        public async UniTask<ILiveServer> Get()
        {
            var data = await LiveServer.Init();
            if (!data.Successes) Debug.LogError(data.ErrorMessage);
            return LiveServer;
        }
    }
}