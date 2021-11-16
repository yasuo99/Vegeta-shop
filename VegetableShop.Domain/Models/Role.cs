using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableShop.Domain.Models
{
    public class Role: IdentityRole<Guid>
    {
        public virtual ICollection<AccountRole> Accounts { get; set; }
    }
}
