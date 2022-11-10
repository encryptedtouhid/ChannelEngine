using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ChannelEngine.Business.Models
{
    public class Search
    {
        [JsonProperty(PropertyName = "statuses")]
        public string Status { get; set; }
        
        [JsonProperty(PropertyName = "apikey")]
        public string ApiKey { get; set; }

    }
}
