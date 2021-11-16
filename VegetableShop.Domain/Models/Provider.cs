using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.Domain.Models.BaseModel;

namespace VegetableShop.Domain.Models
{
    public class Provider: AuditEntity<Guid>
    {
        public string ProviderName { get; set; }
        public string ProviderLogo { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public int MyProperty { get; set; }
    }
}
