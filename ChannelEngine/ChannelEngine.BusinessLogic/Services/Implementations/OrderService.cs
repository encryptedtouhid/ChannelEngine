using ChannelEngine.Business.Constants;
using ChannelEngine.Business.Models;
using ChannelEngine.Business.Services.Interfaces;
using ChannelEngine.Business.Utility;
using ChannelEngine.Business.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine.Business.Services.Implementations
{
    public class OrderService : IOrderService
    {
        public List<Order> GetAllOrder()
        {
            Search search = new Search();
            search.Status = StatusConstants.InProgress;
            ResponseResult TotalOrder = Translator.TranslateToResponseData(Task.Run(async () => { return await ChannelEngineClient.GetOrderDataAsync(search); }).Result);
            List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(TotalOrder.Content.ToString());
            return orders;
        }        

        public List<Product> GetTopFiveProducts(List<Order> orders)
        {
            int Sequence = 1;
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
                Id = Sequence++
            }).ToList();
            return sortedTopProducts.Take(5).ToList();
        }


        public StockField GetStockFieldData(List<Order> AllOrders, Product product)
        {
            StockField stockField = new StockField();
            foreach (var order in AllOrders)
            {
                List<StockLocations> stockLocationItems = new List<StockLocations>();
                foreach (var lines in order.Lines)
                {
                    stockField.MerchantProductNo = lines.MerchantProductNo;

                    if (!stockLocationItems.Any(c => c.StockLocationId == lines.StockLocation.Id))
                    {
                        StockLocations stockLocationItem = new StockLocations();
                        stockLocationItem.StockLocationId = Convert.ToInt32(lines.StockLocation.Id);
                        stockLocationItem.Stock = 25;
                        stockLocationItems.Add(stockLocationItem);
                    }
                }
                stockField.StockLocations = stockLocationItems;
            }
            return stockField;
        }
        public string UpdateProductQuantity(StockField stockField)
        {
            Search search = new Search();
            ResponseResult result = Translator.TranslateToResponseData(Task.Run(async () => { return await ChannelEngineClient.UpdateProductStockDataAsync(search, stockField); }).Result);
            return result.Message;
        }
    }
}
