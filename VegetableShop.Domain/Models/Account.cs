using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableShop.Domain.Models
{
    public class Account: IdentityUser<Guid>
    {
        public Account()
        {
            Roles = new HashSet<AccountRole>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [NotMapped]
        public string FullName => $"{LastName} {MiddleName} {FirstName}";
        public string Address { get; set; }
        public int Wallet { get; set; }
        public virtual ICollection<AccountAddress> Addresses { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<AccountRole> Roles { get; set; }
    }
}
