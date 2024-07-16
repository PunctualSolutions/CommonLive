using Newtonsoft.Json;

namespace PunctualSolutions.CommonLive.DouYinInfo
{
    public class BaseInfo
    {
        [JsonProperty("msg_id")]     public string MessageId { get; set; }
        [JsonProperty("sec_openid")] public string OpenId    { get; set; }
        [JsonProperty("avatar_url")] public string AvatarUrl { get; set; }
        [JsonProperty("nickname")]   public string NikeName  { get; set; }
        [JsonProperty("timestamp")]  public long   Timestamp { get; set; }
    }
}