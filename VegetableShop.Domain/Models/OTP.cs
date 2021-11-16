using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.Domain.Enums;

namespace VegetableShop.Domain.Models
{
    public class OTP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Otp { get; set; }
        public LoginMethod Method { get; set; }
        public DateTime GeneratedAt { get; set; }
        public DateTime AvailableBefore { get; set; }
        public bool IsUsed { get; set; }
        public string Owner { get; set; }
    }
}
