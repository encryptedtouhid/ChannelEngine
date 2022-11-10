using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngine.Business.Models
{
    public class ExtraDatas
    {
        [JsonProperty("Extra Data")]
        public string ExtraData { get; set; }
    }
}
