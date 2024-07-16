using Newtonsoft.Json;

namespace PunctualSolutions.CommonLive.DouYinInfo
{
    public enum MessageType
    {
        [JsonProperty("live_comment")] Comment,
        [JsonProperty("live_like")]    Like,
        [JsonProperty("live_gift")]    Gift,
    }
}