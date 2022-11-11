using ChannelEngine.Business.Models;
using ChannelEngine.Business.Services.Implementations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace ChannelEngine.UnitTests
{
    public class UnitTest1
    {

        [Fact]
        public async Task List_should_return_top_five_products()
        {
            Assembly _assembly;
            StreamReader _textStreamReader;
            string content;
            _assembly = Assembly.GetExecutingAssembly();

            using (_textStreamReader = new StreamReader(Directory.GetCurrentDirectory() + "/Resources/dummydata.json"))
            {
                content = _textStreamReader.ReadToEnd();
            }

            // Act
            var orderService = new OrderService();
            List<Order> AllOrders = JsonConvert.DeserializeObject<List<Order>>(content);
            var result = orderService.GetTopFiveProducts(AllOrders);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count);
        }
    }
}
