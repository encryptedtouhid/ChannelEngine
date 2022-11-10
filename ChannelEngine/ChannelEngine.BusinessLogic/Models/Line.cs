using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ChannelEngine.Business.Models
{
    public class Line
    {
        public string Status { get; set; }
        public bool IsFulfillmentByMarketplace { get; set; }
        public string Gtin { get; set; }
        public string Description { get; set; }
        public StockLocation StockLocation { get; set; }
        public double UnitVat { get; set; }
        public double LineTotalInclVat { get; set; }
        public double LineVat { get; set; }
        public double OriginalUnitPriceInclVat { get; set; }
        public double OriginalUnitVat { get; set; }
        public double OriginalLineTotalInclVat { get; set; }
        public double OriginalLineVat { get; set; }
        public int OriginalFeeFixed { get; set; }
        public object BundleProductMerchantProductNo { get; set; }
        public object JurisCode { get; set; }
        public object JurisName { get; set; }
        public int VatRate { get; set; }
        public List<object> ExtraData { get; set; }
        public string ChannelProductNo { get; set; }
        public string MerchantProductNo { get; set; }
        public int Quantity { get; set; }
        public int CancellationRequestedQuantity { get; set; }
        public double UnitPriceInclVat { get; set; }
        public int FeeFixed { get; set; }
        public int FeeRate { get; set; }
        public string Condition { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
    }
}
