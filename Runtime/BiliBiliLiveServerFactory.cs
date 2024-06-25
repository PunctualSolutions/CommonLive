namespace PunctualSolutionsTool.CommonLive
{
    public class BiliBiliLiveServerFactory : ILiveServerFactory
    {
        private readonly BiliBiliLiveServer _liveServer;
        protected override ILiveServer LiveServer => _liveServer;

        public BiliBiliLiveServerFactory(string accessKeySecret, string accessKeyId, string code, long appId) => _liveServer = new BiliBiliLiveServer(accessKeySecret, accessKeyId, code, appId);
    }
}