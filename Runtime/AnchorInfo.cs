using BiliInfo = OpenBLive.Runtime.Data.AnchorInfo;

namespace PunctualSolutionsTool.CommonLive
{
    /// <summary>
    /// bilibili only
    /// </summary>
    public class AnchorInfo
    {
        public long Uid;
        public string UserName;
        public string UserFace;

        public AnchorInfo(BiliInfo anchorInfo)
        {
            Uid = anchorInfo.uid;
            UserName = anchorInfo.userName;
            UserFace = anchorInfo.userFace;
        }
    }
}