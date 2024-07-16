#region

using System;
using System.Collections.Generic;
using ByteDance.LiveOpenSdk;
using ByteDance.LiveOpenSdk.DyCloud;
using ByteDance.LiveOpenSdk.Report;
using ByteDance.LiveOpenSdk.Runtime;
using ByteDance.LiveOpenSdk.Utilities;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using OpenBLive.Runtime.Data;
using PunctualSolutions.CommonLive.DouYinInfo;
using UnityEngine;
using Like = PunctualSolutions.CommonLive.DouYinInfo.Like;

#endregion

namespace PunctualSolutionsTool.CommonLive
{
    class DouYinCloudServer : ILiveServer
    {
        readonly DyCloudInitParams initParams;

        public DouYinCloudServer(string appId, string envId, string serviceId, string token = null, bool isDebug = false)
        {
            initParams = new()
            {
                    EnvId            = envId,
                    DefaultServiceId = serviceId,
                    DebugIpAddress   = "",
                    IsDebug          = isDebug,
            };
            _sdk.Env.AppId = appId;
            if (token is not null) _sdk.Env.Token = token;
        }

        static ILiveOpenSdk       _sdk               => LiveOpenSdk.Instance;
        static IMessageAckService _messageAckService => _sdk.GetMessageAckService();
        static IDyCloudApi        _dyCloud           => _sdk.GetDyCloudApi();
        static IDyCloudWebSocket  _webSocket;

        public async UniTask<InitData> Init()
        {
            _sdk.Initialize();
            await _dyCloud.InitializeAsync(initParams);
            const string startTasksPath = "/start_game";
            var response = await _dyCloud.CallContainerAsync(
                                   startTasksPath,
                                   "",
                                   "POST",
                                   "",
                                   new Dictionary<string, string>());

            if (response.StatusCode != 200)
            {
                Debug.Log($"抖音云开始推送任务：失败 HTTP {response.StatusCode} {response.Body}");
                return new(false, "start fail");
            }

            Debug.Log(response.Body);
            const string webSocketPath = "/websocket_callback";
            if (_webSocket == null)
            {
                _webSocket           =  _dyCloud.WebSocket;
                _webSocket.OnOpen    += OnOpen;
                _webSocket.OnMessage += OnMessage;
                _webSocket.OnError   += OnError;
                _webSocket.OnClose   += OnClose;
            }

            await _webSocket.ConnectContainerAsync(webSocketPath);
            Debug.Log("抖音云连接 WebSocket：成功");
            return new();
        }

        static void OnError(IDyCloudWebSocketError error)
        {
            Debug.Log(error.Message);
        }

        static void OnClose()
        {
            Debug.Log("dou yin close");
        }

        void OnMessage(string message)
        {
            var json = JsonConvert.DeserializeObject<MainInfo>(message);
            switch (json.Type)
            {
                case MessageType.Comment:
                    var data = JsonConvert.DeserializeObject<Comment>(json.Data);
                    OnCommentaries?.Invoke(new(data));
                    break;
                case MessageType.Like:
                    var like = JsonConvert.DeserializeObject<Like>(json.Data);
                    OnLike?.Invoke(new(like));
                    break;
                case MessageType.Gift:
                    var gift = JsonConvert.DeserializeObject<PunctualSolutions.CommonLive.DouYinInfo.Gift>(json.Data);
                    OnGift?.Invoke(new(gift));
                    break;
                case null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _messageAckService.ReportAck("", "");
        }

        static void OnOpen()
        {
            Debug.Log("dou yin open");
        }

        public event Action<Guard>        OnGuardBuy;
        public event Action<Gift>         OnGift;
        public event Action<Commentaries> OnCommentaries;
        public event Action<LikeInfo>     OnLike;

        public UniTask Close()
        {
            _webSocket.Close();
            _sdk.Uninitialize();
            return UniTask.CompletedTask;
        }
    }
}