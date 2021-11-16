using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.Domain.Models;
using VegetableShop.Services.Interfaces;
using VegetableShop.Services.Patterns.Handlers;
using VegetableShop.Services.Patterns.Interfaces;

namespace VegetableShop.Areas.Customers.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IOrderService _orderService;
        public HomeController(IAuthenticationService authenticationService, IOrderService orderService)
        {
            _authenticationService = authenticationService;
            _orderService = orderService;
        }
        [HttpGet]
        public IActionResult Test()
        {
            Console.WriteLine("Attaching Observers...");

            var smsObserver = new SmsObserver();
            var emailObserver = new EmailObserver();

            _orderService.Attach(smsObserver);
            _orderService.Attach(emailObserver);

            Console.WriteLine("Updating Order Status...");
            var order = new Order
            {
                Id = 1
            }; 
            _orderService.UpdateOrder(order);
            return Json(new { Otp = _authenticationService.GenerateEmailOTP("thanhpro") });
        }
        [HttpGet]
        public IActionResult Check([FromQuery] string otp)
        {
            return Content(_authenticationService.CheckValidOTP("0983961054") ? "Valid" : "Invalid");
        }
        [HttpGet]
        public IActionResult Remain([FromQuery] string otp)
        {
            return Content(_authenticationService.GetRemainTimeOfOTP(otp).ToString());
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Detail()
        {
            return View();
        }
    }
}
