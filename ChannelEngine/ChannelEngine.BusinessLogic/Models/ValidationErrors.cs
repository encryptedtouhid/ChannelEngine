using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngine.Business.Models
{
    public class ValidationErrors
    {
        [JsonProperty("additionalProp1")]
        public List<string> AdditionalProp1 { get; set; }

        [JsonProperty("additionalProp2")]
        public List<string> AdditionalProp2 { get; set; }

        [JsonProperty("additionalProp3")]
        public List<string> AdditionalProp3 { get; set; }
    }
}
