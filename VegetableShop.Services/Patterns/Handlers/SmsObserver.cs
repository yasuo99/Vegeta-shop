using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.Domain.Models;
using VegetableShop.Services.Patterns.Interfaces;

namespace VegetableShop.Services.Patterns.Handlers
{
    public class SmsObserver : IOrderObserver
    {
        public void Update(Order order)
        {
            Console.WriteLine($"Order {order.Id} has been updated and sent sms to user");
        }
    }
}
