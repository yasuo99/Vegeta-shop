using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.Domain.Models;
using VegetableShop.Services.Patterns.Interfaces;

namespace VegetableShop.Services.Patterns.Handlers
{
    public class EmailObserver : IOrderObserver
    {
        public void Update(Order order)
        {
            Console.WriteLine($"The order {order.Id} has been updated and sent the information to user through email");
        }
    }
}
