using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.Domain.Models.BaseModel;

namespace VegetableShop.Domain.Models
{
    public class Cart: DeleteEntity<Guid>
    {
        public Guid AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        public double TotalPrice => Quantity * Product.Price;
    }
}
