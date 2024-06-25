using System;
using ByteDance.LiveOpenSdk;
using ByteDance.LiveOpenSdk.Push;
using ByteDance.LiveOpenSdk.Report;
using ByteDance.LiveOpenSdk.Room;
using ByteDance.LiveOpenSdk.Runtime;
using ByteDance.LiveOpenSdk.Utilities;
using Cysharp.Threading.Tasks;
using OpenBLive.Runtime.Data;

namespace PunctualSolutionsTool.CommonLive
{
    internal class DouYinServer : ILiveServer
    {
        private ILiveOpenSdk _sdk => LiveOpenSdk.Instance;
        private IRoomInfoService _roomInfoService => _sdk.GetRoomInfoService();
        private IMessagePushService _messagePushService => _sdk.GetMessagePushService();
        private IMessageAckService _messageAckService => _sdk.GetMessageAckService();

        private string[] GetMegTypes() => new[] { PushMessageTypes.LiveComment, PushMessageTypes.LiveGift, PushMessageTypes.LiveLike, PushMessageTypes.LiveFansClub };

        public DouYinServer(string appId, string token = null)
        {
            _sdk.Env.AppId = appId;
            if (token is not null) _sdk.Env.Token = token;
        }

        public async UniTask<InitData> Init()
        {
            _sdk.Initialize();
            await _roomInfoService.WaitForRoomInfoAsync();
            var msgTypes = GetMegTypes();
            _messagePushService.OnMessage += MessagePushServiceOnOnMessage;

            await UniTask.WhenAll(msgTypes.Select(Push));
            return new InitData();
            UniTask Push(string messageType) => _messagePushService.StartPushTaskAsync(messageType).AsUniTask();

            void MessagePushServiceOnOnMessage(IPushMessage message)
            {
                switch (message)
                {
                    case ICommentMessage commentMessage:
                        OnCommentaries?.Invoke(new(commentMessage));
                        break;
                    case IFansClubMessage:

                        break;
                    case IGiftMessage giftMessage:
                        OnGift?.Invoke(new(giftMessage));
                        break;
                    case ILikeMessage likeMessage:
                        OnLike?.Invoke(new(likeMessage));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(message));
                }

                _messageAckService.ReportAck(message);
            }
        }

        public event Action<Guard> OnGuardBuy;
        public event Action<Gift> OnGift;
        public event Action<Commentaries> OnCommentaries;
        public event Action<LikeInfo> OnLike;

        public async UniTask Close()
        {
            await UniTask.WhenAll(GetMegTypes().Select(StopPush));
            _sdk.Uninitialize();
            return;
            UniTask StopPush(string messageType) => _messagePushService.StopPushTaskAsync(messageType).AsUniTask();
        }
    }
}