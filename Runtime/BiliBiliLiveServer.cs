#region

using System;
using Cysharp.Threading.Tasks;
using NativeWebSocket;
using OpenBLive.Runtime;
using OpenBLive.Runtime.Data;
using OpenBLive.Runtime.Utilities;
using PunctualSolutions.Tool.UniTask;
using PunctualSolutionsTool.Tool;

#endregion

namespace PunctualSolutionsTool.CommonLive
{
    class BiliBiliLiveServer : ILiveServer
    {
        readonly long            _appId;
        readonly string          _code;
        InteractivePlayHeartBeat _beat;
        WebSocketBLiveClient     _client;
        string                   _gameId;


        public BiliBiliLiveServer(string accessKeySecret, string accessKeyId, string code, long appId)
        {
            _code                       = code;
            _appId                      = appId;
            SignUtility.accessKeySecret = accessKeySecret;
            SignUtility.accessKeyId     = accessKeyId;
        }

        WebSocketState State => _client.ws.State;

        public async UniTask<InitData> Init()
        {
            var data         = await BApi.StartInteractivePlay(_code, _appId.ToString());
            var appStartInfo = data.JsonToObject<AppStartInfo>(); //处理开启游戏异常事件
            if (appStartInfo.Code != 0) return new(false, appStartInfo.Message);
            _gameId            =  appStartInfo.GetGameId();
            _client            =  new(appStartInfo.GetWssLink(), appStartInfo.GetAuthBody());
            _client.OnDanmaku  += x => { OnCommentaries?.Invoke(new(x)); };
            _client.OnGift     += x => OnGift?.Invoke(new(x));
            _client.OnGuardBuy += x => OnGuardBuy?.Invoke(x);
            try
            {
                _client.Connect(TimeSpan.FromSeconds(2), 10);
            }
            catch (Exception ex)
            {
                return new(false, ex.Message);
            }

            _beat = new(_gameId);
            _beat.Start();
            OpenInfo();
            return new();

            async void OpenInfo()
            {
                while (true)
                {
                    await 0.1.Delay();
                    if (_client is not { ws: { State: WebSocketState.Open } }) continue;
                    _client.ws.DispatchMessageQueue();
                }
                // ReSharper disable once FunctionNeverReturns
            }
        }

        public event Action<Guard>        OnGuardBuy;
        public event Action<Gift>         OnGift;
        public event Action<Commentaries> OnCommentaries;
        public event Action<LikeInfo>     OnLike;

        public async UniTask Close()
        {
            _beat?.Dispose();
            await BApi.EndInteractivePlay(_appId.ToString(), _gameId);
            _client?.Dispose();
        }
    }
}