using Newtonsoft.Json;

namespace PunctualSolutions.CommonLive.DouYinInfo
{
    public class Like : BaseInfo
    {
        [JsonProperty("like_num")] public int Number { get; set; }
    }
}