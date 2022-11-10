using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngine.Business.Models
{
    public class ResponseResult
    {
        public List<Content> Content { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int StatusCode { get; set; }
        public object RequestId { get; set; }
        public object LogId { get; set; }
        public bool Success { get; set; }
        public object Message { get; set; }
        public ValidationErrors ValidationErrors { get; set; }
    }
}
