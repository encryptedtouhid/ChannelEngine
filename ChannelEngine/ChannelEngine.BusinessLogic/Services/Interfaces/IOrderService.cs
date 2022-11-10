using ChannelEngine.Business.Models;
using ChannelEngine.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngine.Business.Services.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAllOrder(Search search);

        List<Product> GetTopFiveProducts(List<Order> orders);

        String UpdateProductQuantity(StockField stockField);
    }
}
