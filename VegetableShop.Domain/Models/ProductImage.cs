using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.Domain.Models.BaseModel;

namespace VegetableShop.Domain.Models
{
    public class ProductImage: AuditEntity<Guid>
    {
        public string ImageUrl { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
    }
}
