namespace PunctualSolutionsTool.CommonLive
{
    public class TestLiveServerFactory : ILiveServerFactory
    {
        readonly           TestLiveServer _liveServer = new();
        protected override ILiveServer    LiveServer => _liveServer;

        internal TestLiveServer GetCore() => _liveServer;
    }
}