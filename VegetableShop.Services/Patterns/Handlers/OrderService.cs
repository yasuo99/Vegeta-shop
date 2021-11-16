using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.Domain.Models;
using VegetableShop.Services.Patterns.Interfaces;

namespace VegetableShop.Services.Patterns.Handlers
{
    public class OrderService : IOrderService
    {
        private List<IOrderObserver> orderObservers = new List<IOrderObserver>();
        public void Attach(IOrderObserver orderObserver)
        {
            orderObservers.Add(orderObserver);
        }

        public void Detach(IOrderObserver orderObserver)
        {
            orderObservers.Remove(orderObserver);
        }

        public void Notify(Order order)
        {
            foreach(var observer in orderObservers)
            {
                observer.Update(order);
            }
        }

        public void UpdateOrder(Order order)
        {
            Notify(order);
        }
    }
}
