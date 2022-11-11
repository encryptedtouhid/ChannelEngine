using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngine.Business.ViewModels
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string GTIN { get; set; }
        public double TotalQuantity { get; set; }
  
    }
}
