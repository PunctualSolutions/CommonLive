using Newtonsoft.Json;

namespace PunctualSolutions.CommonLive.DouYinInfo
{
    public class Comment : BaseInfo
    {
        [JsonProperty("content")] public string Content { get; set; }
    }
}