using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController: Controller
    {
        public DashboardController()
        {

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ProductManage()
        {
            return PartialView();
        }
    }
}
