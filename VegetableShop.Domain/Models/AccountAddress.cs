using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableShop.Domain.Models
{
    public class AccountAddress
    {
        public Guid AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public virtual  Account Account { get; set; }
        public Guid AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }
        public bool IsPrimary { get; set; }
    }
}
