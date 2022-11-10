using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngine.Business.Constants
{
    public static class StatusConstants
    {
        public const string InProgress = "IN_PROGRESS";
        public const string Shipped = "SHIPPED";
        public const string InBackOrder = "IN_BACKORDER";
        public const string Manco = "MANCO";
        public const string Canceled = "CANCELED";
        public const string InCombi = "IN_COMBI";
        public const string Closed = "CLOSED";
        public const string New = "NEW";
        public const string Returned = "RETURNED";
        public const string RequiresCorrection = "REQUIRES_CORRECTION";
        public const string AwaitingPayment = "AWAITING_PAYMENT";
    }
}
