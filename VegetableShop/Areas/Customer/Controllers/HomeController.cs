using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableShop.Areas.Customers.Controllers
{
    [Area("Customer")]
    public class HomeController: Controller
    {
        public HomeController()
        {

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
