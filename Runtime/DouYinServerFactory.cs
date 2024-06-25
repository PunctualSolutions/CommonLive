namespace PunctualSolutionsTool.CommonLive
{
    public class DouYinServerFactory : ILiveServerFactory
    {
        protected override ILiveServer LiveServer { get; }

        public DouYinServerFactory(string appId, string token = null) => LiveServer = new DouYinServer(appId, token);
    }
}