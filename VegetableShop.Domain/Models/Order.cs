using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableShop.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid? AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatuses OrderStatuses { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
    public enum OrderStatuses
    {
        PendingPayment = 1,
        OnHold = 2,
        Processing = 3,
        Shipped = 4,
        Cancelled = 5,
        Refunded = 6,
        Failed = 7,
        Completed = 8
    }
}
