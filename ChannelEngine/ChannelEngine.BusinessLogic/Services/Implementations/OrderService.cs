using ChannelEngine.Business.Models;
using ChannelEngine.Business.Services.Interfaces;
using ChannelEngine.Business.Utility;
using ChannelEngine.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine.Business.Services.Implementations
{
    public class OrderService : IOrderService
    {
        public List<Order> GetAllOrder(Search search)
        {
            ResponseResult TotalOrder = Translator.TranslateToResponseData(Task.Run(async () => { return await ChannelEngineClient.GetOrderDataAsync(search); }).Result);

            return TotalOrder.Content;
        }

        public List<Product> GetTopFiveProducts(List<Order> orders)
        {
            throw new NotImplementedException();
        }

        public string UpdateProductQuantity(StockField stockField)
        {
            throw new NotImplementedException();
        }
    }
}
