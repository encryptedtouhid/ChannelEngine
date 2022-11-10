using ChannelEngine.Business.Models;
using ChannelEngine.Business.Services.Interfaces;
using ChannelEngine.Business.Utility;
using ChannelEngine.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Product> Lines = new List<Product>();
            foreach (var order in orders)
            {
                foreach (var line in order.Lines)
                {
                    Product product = new Product();
                    product.ProductName = line.Description;
                    product.GTIN = line.Gtin;
                    product.TotalQuantity = line.Quantity;
                    Lines.Add(product);
                }
            }

            List<Product> sortedTopProducts = Lines
            .GroupBy(l => l.ProductName)
            .Select(cl => new Product
            {
                ProductName = cl.First().ProductName,
                GTIN = cl.First().GTIN,
                TotalQuantity = cl.Sum(c => c.TotalQuantity),
            }).ToList();
            return sortedTopProducts.Take(5).ToList();
        }

        public string UpdateProductQuantity(StockField stockField)
        {
            throw new NotImplementedException();
        }
    }
}
