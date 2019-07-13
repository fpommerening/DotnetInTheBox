﻿using Newtonsoft.Json;

namespace FP.DotnetnTheBox.Webhock.Model
{
    public class DockerhubWebhock
    {
        [JsonProperty("push_data")]
        public PushData PushData { get; set; }

        [JsonProperty("callback_url")]
        public  string CallbackUrl { get; set; }

        [JsonProperty("repository")]
        public Repository Repository { get; set; }
    }
}
