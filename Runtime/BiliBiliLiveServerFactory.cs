namespace PunctualSolutionsTool.CommonLive
{
    public class BiliBiliLiveServerFactory : ILiveServerFactory
    {
        readonly BiliBiliLiveServer _liveServer;

        public BiliBiliLiveServerFactory(string accessKeySecret, string accessKeyId, string code, long appId) => _liveServer = new(accessKeySecret, accessKeyId, code, appId);
        protected override ILiveServer LiveServer => _liveServer;
    }
}