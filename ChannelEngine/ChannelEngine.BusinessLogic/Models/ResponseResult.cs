using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngine.Business.Models
{
    public class ResponseResult
    {
        public Object Content { get; set; }
        public double Count { get; set; }
        public double TotalCount { get; set; }
        public double ItemsPerPage { get; set; }
        public double StatusCode { get; set; }
        public string RequestId { get; set; }
        public string LogId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public ValidationErrors ValidationErrors { get; set; }
    }
}
