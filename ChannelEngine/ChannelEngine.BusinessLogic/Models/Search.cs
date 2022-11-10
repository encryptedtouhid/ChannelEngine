using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ChannelEngine.Business.Models
{
    public class Search
    {
        [DisplayName("statuses")]
        public string Status { get; set; }
        
        [DisplayName("apikey")]
        public string ApiKey { get; set; }

    }
}
