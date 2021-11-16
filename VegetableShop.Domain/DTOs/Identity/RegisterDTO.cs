using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableShop.Domain.DTOs.Identity
{
    public class RegisterDTO
    {
        [DisplayName("Số điện thoại"), DataType(DataType.PhoneNumber, ErrorMessage = "Số điện thoại phải đúng format")]
        public string PhoneNumber { get; set; }
        [DisplayName("Địa chỉ email"), DataType(DataType.EmailAddress, ErrorMessage = "Địa chỉ email phải đúng format")]
        public string Email { get; set; }
        [DisplayName("Tài khoản"),RegularExpression("^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$", ErrorMessage = "Tên tài khoản phải đúng định dạng")]
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsValidEmail { get; set; }
        public bool IsValidOTP { get; set; }
        public InfoDTO Info { get; set; }
        public int Counter { get; set; } = 0;
        public bool Succeeded { get; set; }
    }
    public class InfoDTO
    {
        [DisplayName("Tên")]
        public string FirstName { get; set; }
        [DisplayName("Tên đệm")]
        public string MiddleName { get; set; }
        [DisplayName("Họ")]
        public string LastName { get; set; }
    }
}
