using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableShop.Domain.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; }
        [NotMapped]
        public bool IsAnswerd => string.IsNullOrEmpty(Answer);
    }
}
