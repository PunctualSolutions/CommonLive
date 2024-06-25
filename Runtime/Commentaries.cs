using System;
using ByteDance.LiveOpenSdk.Push;
using OpenBLive.Runtime.Data;

namespace PunctualSolutionsTool.CommonLive
{
    public class Commentaries : MessageInfo
    {
        public UserInfo UserInfo { get; }

        public Commentaries(Dm dm) : base("", string.Empty, dm.timestamp)
        {
            Content = dm.msg;
            UserInfo = new UserInfo(dm.openId, dm.userFace, dm.userName, dm.fansMedalLevel, dm.fansMedalName, dm.fansMedalWearingStatus, dm.guardLevel);
        }

        public Commentaries(int userId, string content)
            : base("", string.Empty, DateTime.Now)
        {
            Content = content;
            UserInfo = new UserInfo(userId.ToString(), "", "");
        }

        public Commentaries(ICommentMessage commentMessage) : base(commentMessage)
        {
            Content = commentMessage.Content;
            UserInfo = new UserInfo(commentMessage.Sender);
        }

        public string Content { get; }

        public override string ToString() => $"{base.ToString()}:{Content}\nUserInfo: {UserInfo}";
    }
}