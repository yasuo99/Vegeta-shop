using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.Domain.Models.BaseModel;

namespace VegetableShop.Domain.Models
{
    public class Product: AuditEntity<Guid>
    {
        public Product()
        {
            Carts = new List<Cart>();
            ProductImages = new List<ProductImage>();
        }
        public string DisplayName { get; set; }
        public string Detail { get; set; }
        
        public int Available { get; set; }
        public int SaleCount { get; set; }
        public double Price { get; set; }
        public double PreviousPrice { get; set; }
        [NotMapped]
        public int SaleOffPercent => (int) (Price / PreviousPrice) * 100;
        public bool IsPublish { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
