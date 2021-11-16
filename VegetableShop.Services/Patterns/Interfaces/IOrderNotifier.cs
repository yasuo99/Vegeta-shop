using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.Domain.Models;

namespace VegetableShop.Services.Patterns.Interfaces
{
    public interface IOrderNotifier
    {
        void Attach(IOrderObserver orderObserver);
        void Detach(IOrderObserver orderObserver);

        void Notify(Order order);

    }
}
