using ChannelEngine.Business.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ChannelEngine.Business.Utility
{
    public class Translator
    {
        public static ResponseResult TranslateToResponseData(string Content)
        {
            return JsonConvert.DeserializeObject<ResponseResult>(Content);
        }
        


    }
}
