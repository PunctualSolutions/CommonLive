namespace PunctualSolutionsTool.CommonLive
{
    public class DouYinServerFactory : ILiveServerFactory
    {
        public DouYinServerFactory(string appId, string token = null) => LiveServer = new DouYinServer(appId, token);
        protected override ILiveServer LiveServer { get; }
    }
}