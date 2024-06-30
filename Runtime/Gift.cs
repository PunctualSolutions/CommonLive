using System;
using ByteDance.LiveOpenSdk.Push;
using Cysharp.Threading.Tasks.Triggers;
using OpenBLive.Runtime.Data;

namespace PunctualSolutionsTool.CommonLive
{
    public class Gift : MessageInfo
    {
        public UserInfo UserInfo { get; private set; }
        public AnchorInfo AnchorInfo { get; private set; }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public long Number { get; private set; }

        /// <summary>
        /// 单位厘
        /// </summary>
        public long Price { get; private set; }

        /// <summary>
        /// really money bilibili only
        /// </summary>
        public bool Paid { get; private set; }

        public override string ToString() => $"{base.ToString()},GiftId:{Id},GiftName:{Name},GiftNumber:{Number},GiftPrice:{Price},Paid:{Paid},AnchorInfo:{AnchorInfo}";

        public Gift(SendGift gift) : base(gift.timestamp)
        {
            Id = gift.giftId.ToString();
            Name = gift.giftName;
            Number = gift.giftNum;
            Price = gift.price;
            Paid = gift.paid;
            AnchorInfo = new AnchorInfo(gift.anchorInfo);
            UserInfo = new UserInfo(gift.openId, gift.userFace, gift.userName, gift.fansMedalLevel, gift.fansMedalName, gift.fansMedalWearingStatus, gift.guardLevel);
        }

        public Gift(IGiftMessage giftMessage) : base(giftMessage)
        {
            Id = giftMessage.SecGiftId;
            Number = giftMessage.GiftCount;
            Price = giftMessage.GiftValue * 10;
            UserInfo = new UserInfo(giftMessage.Sender);
        }

        public Gift(string id, int number, long price,string userId) : base(DateTime.Now)
        {
            Id = id;
            Number = number;
            Price = price;
            UserInfo = new(userId, "", userId);
        }
    }
}