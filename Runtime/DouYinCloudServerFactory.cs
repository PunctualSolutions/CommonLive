namespace PunctualSolutionsTool.CommonLive
{
    public class DouYinCloudServerFactory : ILiveServerFactory
    {
        public DouYinCloudServerFactory(string appId, string envId, string serviceId, string token = null, bool isDebug = false) => LiveServer = new DouYinCloudServer(appId, envId, serviceId, token, isDebug);
        protected override ILiveServer LiveServer { get; }
    }
}