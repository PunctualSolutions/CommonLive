using Newtonsoft.Json;

namespace PunctualSolutions.CommonLive.DouYinInfo
{
    public class Gift : BaseInfo
    {
        [JsonProperty("sec_gift_id")] public string Id     { get; set; }
        [JsonProperty("gift_num")]    public int    Number { get; set; }
        [JsonProperty("gift_value")]  public int    Value  { get; set; }
    }
}