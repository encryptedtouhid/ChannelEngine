using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngine.Business.Models
{
    public class BillingAddress
    {
        public string Line1 { get; set; }
        public object Line2 { get; set; }
        public object Line3 { get; set; }
        public string Gender { get; set; }
        public object CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public object HouseNrAddition { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public object Region { get; set; }
        public string CountryIso { get; set; }
        public object Original { get; set; }
    }
}
