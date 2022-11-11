using ChannelEngine.Business.Models;
using ChannelEngine.Business.Services.Implementations;
using ChannelEngine.Business.Services.Interfaces;
using ChannelEngine.Business.ViewModels;
using ChannelEngine.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEngine.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;
        private static List<Order> AllOrders = new List<Order>();
        private static List<Product> TopFiveProduct = new List<Product>();
        public HomeController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            AllOrders = _orderService.GetAllOrder();
            return View(AllOrders);
        }
        public IActionResult TopFiveProductShow()
        {
            TopFiveProduct = _orderService.GetTopFiveProducts(AllOrders);
            return View(TopFiveProduct);
        }
        public IActionResult StockUpdate(int Id)
        {
            Product SelectedProduct = TopFiveProduct.Where(c => c.Id == Id).Select(c => c).FirstOrDefault();
            StockField stockField = _orderService.GetStockFieldData(AllOrders, SelectedProduct);
            TempData["msg"] = _orderService.UpdateProductQuantity(stockField);
            return RedirectToAction("TopFiveProductShow");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
