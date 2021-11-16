using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VegetableShop.Domain.Models
{
    public class ProviderAddress
    {
        public Guid ProviderId { get; set; }
        [ForeignKey(nameof(ProviderId))]
        public virtual Provider Provider { get; set; }
        public Guid AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }
        public bool IsPrimary { get; set; }
    }
}