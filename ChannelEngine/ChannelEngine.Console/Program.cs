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
using System.Threading.Tasks;

namespace ChannelEngine.Console
{
    public class Program
    {
        static void Main(string[] args)
        {           

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IOrderService, OrderService>()
                .BuildServiceProvider();

            System.Console.WriteLine("Fetch all orders with status IN_PROGRESS from the API : \n");
            Search search = new Search();
            search.Status = StatusConstants.InProgress;
            var OrderService = serviceProvider.GetService<IOrderService>();            
            Table TotalTable = new Table();
            TotalTable.From<Order>(OrderService.GetAllOrder(search));
            System.Console.Write(TotalTable.ToString());
            if (Debugger.IsAttached)
            {
                System.Console.ReadLine();
            }

        }
    }
}
