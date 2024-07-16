namespace PunctualSolutionsTool.CommonLive
{
    public class InitData
    {
        public InitData(bool successes = true, string errorMessage = null)
        {
            Successes    = successes;
            ErrorMessage = errorMessage;
        }

        public bool   Successes    { get; set; }
        public string ErrorMessage { get; set; }
    }
}