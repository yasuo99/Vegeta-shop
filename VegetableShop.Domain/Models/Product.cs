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
            Carts = new HashSet<Cart>();
            ProductImages = new HashSet<ProductImage>();
        }
        public string DisplayName { get; set; }
        public string Detail { get; set; }
        
        public int Available { get; set; }
        public int SaleCount { get; set; }
        public double Price { get; set; }
        public double PreviousPrice { get; set; }
        [NotMapped]
        public int SaleOffPercent => (int) (Price / PreviousPrice) * 100;
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
