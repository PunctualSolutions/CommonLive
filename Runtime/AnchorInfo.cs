#region

using BiliInfo = OpenBLive.Runtime.Data.AnchorInfo;

#endregion

namespace PunctualSolutionsTool.CommonLive
{
    /// <summary>
    ///     bilibili only
    /// </summary>
    public class AnchorInfo
    {
        public long   Uid;
        public string UserFace;
        public string UserName;

        public AnchorInfo(BiliInfo anchorInfo)
        {
            Uid      = anchorInfo.uid;
            UserName = anchorInfo.userName;
            UserFace = anchorInfo.userFace;
        }
    }
}