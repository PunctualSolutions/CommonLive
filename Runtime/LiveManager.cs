using System;
using System.Threading;
using System.Threading.Tasks;
using NativeWebSocket;
using OpenBLive.Runtime;
using OpenBLive.Runtime.Data;
using OpenBLive.Runtime.Utilities;
using ZhengDianWaiBao.Tool;

namespace ZhengDianWaiBao.CommonLive
{
    public class LiveManager
    {
        private readonly string _accessKeySecret;
        private readonly string _accessKeyId;
        private readonly string _code;
        private readonly long _appId;
        private string _gameId;
        private WebSocketBLiveClient _client;
        public WebSocketState State => _client.ws.State;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessKeySecret"></param>
        /// <param name="accessKeyId"></param>
        /// <param name="code">bilibili is identification code </param>
        /// <param name="appId"></param>
        public LiveManager(string accessKeySecret, string accessKeyId, string code, long appId)
        {
            _accessKeySecret = accessKeySecret;
            _accessKeyId = accessKeyId;
            _code = code;
            _appId = appId;
            SignUtility.accessKeySecret = _accessKeySecret;
            SignUtility.accessKeyId = _accessKeyId;
        }

        public struct InitData
        {
            public InitData(bool successes = true, string errorMessage = null)
            {
                Successes = successes;
                ErrorMessage = errorMessage;
            }

            public bool Successes { get; set; }
            public string ErrorMessage { get; set; }
        }

        public async Task<InitData> Init()
        {
            var data = await BApi.StartInteractivePlay(_code, _appId.ToString());
            var appStartInfo = data.DeserializeObject<AppStartInfo>(); //处理开启游戏异常事件
            if (appStartInfo.Code != 0) return new InitData(false, appStartInfo.Message);
            _gameId = appStartInfo.GetGameId();
            _client = new WebSocketBLiveClient(appStartInfo.GetWssLink(), appStartInfo.GetAuthBody());
            _client.OnDanmaku += x => OnCommentaries?.Invoke(new(x));
            _client.OnGift += x => OnGift?.Invoke(new(x));
            _client.OnGuardBuy += x => OnGuardBuy?.Invoke(x);
            _client.OnSuperChat += x => OnAdvancedComments?.Invoke(new(x));
            try
            {
                _client.Connect(TimeSpan.FromSeconds(2), 10);
            }
            catch (Exception ex)
            {
                return new(false, ex.Message);
            }

            var beat = new InteractivePlayHeartBeat(_gameId);
            beat.Start();

            return new();
        }

        public event Action<Guard> OnGuardBuy;
        public event Action<Gift> OnGift;
        public event Action<Commentaries> OnCommentaries;
        public event Action<AdvancedComments> OnAdvancedComments;

        public Task<Guard> WaitGuardBuy(CancellationTokenSource source = default) =>
            TaskConvertTool.WaitTask<Guard>(x => OnGuardBuy += x, x => OnGuardBuy -= x, source);

        public Task<Gift> WaitGift(CancellationTokenSource source = default) =>
            TaskConvertTool.WaitTask<Gift>(x => OnGift += x, x => OnGift -= x, source);

        public Task<Commentaries> WaitCommentaries(CancellationTokenSource source = default) =>
            TaskConvertTool.WaitTask<Commentaries>(x => OnCommentaries += x, x => OnCommentaries -= x, source);

        public Task<AdvancedComments> WaitAdvancedComments(CancellationTokenSource source = default) =>
            TaskConvertTool.WaitTask<AdvancedComments>(x => OnAdvancedComments += x, x => OnAdvancedComments -= x,
                source);
    }
}