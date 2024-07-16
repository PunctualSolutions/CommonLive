using Newtonsoft.Json;

namespace PunctualSolutions.CommonLive.DouYinInfo
{
    public struct MainInfo
    {
        [JsonProperty("data")]     public string       Data { get; set; }
        [JsonProperty("msg_id")]   public string       Id   { get; set; }
        [JsonProperty("msg_type")] public MessageType? Type { get; set; }
    }
}