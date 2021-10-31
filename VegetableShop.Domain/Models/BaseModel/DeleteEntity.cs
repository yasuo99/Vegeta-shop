using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableShop.Domain.Models.BaseModel
{
    public class DeleteEntity<T>: AuditEntity<T>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
