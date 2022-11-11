using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngine.Business.Models
{
    public class StockField
    {
        public string MerchantProductNo { get; set; }

        public List<StockLocations> StockLocations { get; set; }
    }
}
