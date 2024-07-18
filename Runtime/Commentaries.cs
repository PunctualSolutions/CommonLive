#region

using System;
using ByteDance.LiveOpenSdk.Push;
using OpenBLive.Runtime.Data;
using PunctualSolutions.CommonLive.DouYinInfo;

#endregion

namespace PunctualSolutionsTool.CommonLive
{
    public class Commentaries : MessageInfo
    {
        public Commentaries(Dm dm) : base("", string.Empty, dm.timestamp)
        {
            Content  = dm.msg;
            UserInfo = new(dm.openId, dm.userFace, dm.userName, dm.fansMedalLevel, dm.fansMedalName, dm.fansMedalWearingStatus, dm.guardLevel);
        }

        public Commentaries(int userId, string content)
                : base("", string.Empty, DateTime.Now)
        {
            Content  = content;
            UserInfo = new(userId.ToString(), "", userId.ToString());
        }

        public Commentaries(ICommentMessage commentMessage) : base(commentMessage)
        {
            Content  = commentMessage.Content;
            UserInfo = new(commentMessage.Sender);
        }

        public Commentaries(Comment commentMessage) : base(commentMessage.MessageId, string.Empty, 0)
        {
            Content  = commentMessage.Content;
            UserInfo = new(commentMessage);
        }

        public UserInfo UserInfo { get; }

        public string Content { get; }

        public override string ToString() => $"{base.ToString()}:{Content}\nUserInfo: {UserInfo}";
    }
}