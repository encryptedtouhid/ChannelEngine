using ChannelEngine.Business.Models;
using ChannelEngine.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngine.Business.Services.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAllOrder();

        List<Product> GetTopFiveProducts(List<Order> orders);


        StockField GetStockFieldData(List<Order> orders, Product product);

        String UpdateProductQuantity(StockField stockField);
    }
}
