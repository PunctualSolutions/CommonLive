using OpenBLive.Runtime.Data;

namespace ZhengDianWaiBao.CommonLive
{
    public class Gift : MessageBase
    {
        public Gift(SendGift gift) : base(gift.uid, gift.userName, gift.roomId, gift.userFace, gift.timestamp,
            gift.fansMedalLevel,
            gift.fansMedalName, gift.fansMedalWearingStatus, gift.guardLevel)
        {
            AnchorInfo = new(gift.anchorInfo);
            Id = gift.giftId;
            Name = gift.giftName;
            Number = gift.giftNum;
            Price = gift.price;
            Paid = gift.paid;
        }

        public AnchorInfo AnchorInfo { get; private set; }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public long Number { get; private set; }
        public long Price { get; private set; }

        /// <summary>
        /// really money bilibili only
        /// </summary>
        public bool Paid { get; private set; }
    }
}