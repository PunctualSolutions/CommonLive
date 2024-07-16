#region

using ByteDance.LiveOpenSdk.Room;
using PunctualSolutions.CommonLive.DouYinInfo;

#endregion

namespace PunctualSolutionsTool.CommonLive
{
    public class UserInfo
    {
        public UserInfo(string openId, string avatarUrl, string nickname)
        {
            OpenId    = openId;
            AvatarUrl = avatarUrl;
            Nickname  = nickname;
        }

        public UserInfo(string openId, string avatarUrl, string nickname, long fansMedalLevel, string fansMedalName, bool fansMedalWearingStatus, long guardLevel) : this(openId, avatarUrl, nickname)
        {
            FansMedalLevel         = fansMedalLevel;
            FansMedalName          = fansMedalName;
            FansMedalWearingStatus = fansMedalWearingStatus;
            GuardLevel             = guardLevel;
        }

        public UserInfo(IUserInfo userInfo) : this(userInfo.OpenId, userInfo.AvatarUrl, userInfo.Nickname)
        {
        }

        public UserInfo(BaseInfo baseInfo) : this(baseInfo.OpenId, baseInfo.AvatarUrl, baseInfo.NikeName)
        {
        }

        public string OpenId    { get; protected set; }
        public string AvatarUrl { get; protected set; }
        public string Nickname  { get; protected set; }

        /// <summary>
        ///     bilibili captive
        /// </summary>
        public long FansMedalLevel { get; protected set; }

        /// <summary>
        ///     bilibili captive
        /// </summary>
        public string FansMedalName { get; protected set; }

        /// <summary>
        ///     bilibili captive
        /// </summary>
        public bool FansMedalWearingStatus { get; protected set; }

        /// <summary>
        ///     bilibili captive
        /// </summary>
        public long GuardLevel { get; protected set; }

        public override string ToString() => $"{Nickname}({OpenId})";
    }
}