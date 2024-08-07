#region

using System;
using ByteDance.LiveOpenSdk.Push;
using OpenBLive.Runtime.Data;

#endregion

namespace PunctualSolutionsTool.CommonLive
{
    public class Gift : MessageInfo
    {
        public Gift(SendGift gift) : base(gift.timestamp)
        {
            Id         = gift.giftId.ToString();
            Name       = gift.giftName;
            Number     = gift.giftNum;
            Price      = gift.price;
            Paid       = gift.paid;
            AnchorInfo = new(gift.anchorInfo);
            UserInfo   = new(gift.openId, gift.userFace, gift.userName, gift.fansMedalLevel, gift.fansMedalName, gift.fansMedalWearingStatus, gift.guardLevel);
        }

        public Gift(IGiftMessage giftMessage) : base(giftMessage)
        {
            Id       = giftMessage.SecGiftId;
            Number   = giftMessage.GiftCount;
            Price    = giftMessage.GiftValue * 10;
            UserInfo = new(giftMessage.Sender);
        }

        public Gift(string id, int number, long price, string userId) : base(DateTime.Now)
        {
            Id       = id;
            Number   = number;
            Price    = price;
            UserInfo = new(userId, "https://pic.616pic.com/photoone/00/02/02/618cf1bbce7a77755.jpg!/fw/1120", userId);
        }

        public Gift(PunctualSolutions.CommonLive.DouYinInfo.Gift giftMessage) : base(giftMessage.OpenId, string.Empty, 0)
        {
            Id        = giftMessage.Id;
            Number    = giftMessage.Number;
            Price     = giftMessage.Value * 10;
            AvatarUrl = giftMessage.AvatarUrl;
            UserInfo  = new(giftMessage);
        }

        public UserInfo   UserInfo   { get; private set; }
        public AnchorInfo AnchorInfo { get; }
        public string     Id         { get; }
        public string     Name       { get; }
        public long       Number     { get; }
        public string     AvatarUrl  { get; set; } ="https://pic.616pic.com/photoone/00/02/02/618cf1bbce7a77755.jpg!/fw/1120";

        /// <summary>
        ///     单位厘
        /// </summary>
        public long Price { get; }

        /// <summary>
        ///     really money bilibili only
        /// </summary>
        public bool Paid { get; }

        public override string ToString() => $"{base.ToString()},GiftId:{Id},GiftName:{Name},GiftNumber:{Number},GiftPrice:{Price},Paid:{Paid},AnchorInfo:{AnchorInfo}";
    }
}