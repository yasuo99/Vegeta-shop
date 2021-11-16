using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.Domain.Models.BaseModel;

namespace VegetableShop.Domain.Models
{
    public class Address : AuditEntity<Guid>
    {
        public string HomeNumber { get; set; }
        public string Village { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string FullAddress { get; set; }
        public virtual ICollection<AccountAddress> Accounts { get; set; }
        public virtual ICollection<ProviderAddress> Providers { get; set; }
        public Func<string, string, string, string, string> SuggestAddress = (string homeAddress, string village, string district, string province) =>
        {
            StringBuilder suggestAddress = new StringBuilder();
            if (!string.IsNullOrEmpty(homeAddress))
            {
                suggestAddress.Append($"{homeAddress} '\n'");
            }
            if (!string.IsNullOrEmpty(village))
            {
                suggestAddress.Append($"{village} '\n'");
            }
            if (!string.IsNullOrEmpty(district))
            {
                suggestAddress.Append($"{village} '\n");
            }
            if (!string.IsNullOrEmpty(province))
            {
                suggestAddress.Append($"{province} '\n'");
            }
            return suggestAddress.ToString();
        };
    }
}
