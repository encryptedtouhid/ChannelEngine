using BetterConsoleTables;
using ChannelEngine.Business.Constants;
using ChannelEngine.Business.Models;
using ChannelEngine.Business.Services.Implementations;
using ChannelEngine.Business.Services.Interfaces;
using ChannelEngine.Business.Utility;
using ChannelEngine.Business.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ChannelEngine.Console
{
    public class Program
    {
        public static List<Order> AllOrders = new List<Order>();
        public static List<Product> TopFiveProduct = new List<Product>();
        public static void Main(string[] args)
        {
            int ProductIdInput;

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IOrderService, OrderService>()
                .BuildServiceProvider();

            var OrderService = serviceProvider.GetService<IOrderService>();


            System.Console.WriteLine("Fetch all orders with status IN_PROGRESS from the API : \n");
            
            AllOrders = OrderService.GetAllOrder();
            Table TotalTable = new Table();
            TotalTable.From<Order>(AllOrders);
            System.Console.Write(TotalTable.ToString());


            System.Console.WriteLine("List of top 5 products sold in descending order : \n");
            TopFiveProduct = OrderService.GetTopFiveProducts(AllOrders);
            Table TotalProductTable = new Table();
            TotalProductTable.From<Product>(TopFiveProduct);
            System.Console.Write(TotalProductTable.ToString());


            System.Console.WriteLine("Select Product ID To Stock Update : \n");
            String userInput = System.Console.ReadLine();
            while (!Int32.TryParse(userInput, out ProductIdInput))
            {
                System.Console.WriteLine("Invalid Input. Select Product ID To Stock Update : \n");
                userInput = System.Console.ReadLine();
            }

           
            Product SelectedProduct = TopFiveProduct.Where(c => c.Id == ProductIdInput).Select(c => c).FirstOrDefault();
            System.Console.WriteLine("You Selected Product : " + SelectedProduct.ProductName);
            System.Console.WriteLine("Now Updating it with 25 Stocks.");
            StockField stockField = OrderService.GetStockFieldData(AllOrders, SelectedProduct);
            System.Console.WriteLine(OrderService.UpdateProductQuantity(stockField));

            if (Debugger.IsAttached)
            {
                System.Console.ReadLine();
            }

        }
    }
}
