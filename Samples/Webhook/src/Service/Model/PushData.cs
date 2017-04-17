using Newtonsoft.Json;

namespace FP.Spartakiade2017.Docker.WebHook.Service.Model
{
    public class PushData
    {
        [JsonProperty("pushed_at")]
        public int PushedAt { get; set; }

        [JsonProperty("images")]
        public string[] Images { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("pusher")]
        public string Pusher { get; set; }
    }
}
