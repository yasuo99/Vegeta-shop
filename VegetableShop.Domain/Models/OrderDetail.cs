using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VegetableShop.Domain.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public double Product_Price { get; set; }
        [NotMapped]
        public double Sum => Quantity * Product_Price;
    }
}