using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.Services.Abstractions;

namespace VegetableShop.Services.Handlers
{
    public class OtpHandler : Otp
    {
        private string _input { get; set; }
        public OtpHandler(string key)
        {
            _input = key;
        }
        public override string ComputeOtp()
        {
            var bytes = Encoding.ASCII.GetBytes(_input);
            StringBuilder stringBuider = new StringBuilder();
            stringBuider.Append(bytes.Length);
            if (_input.Contains("@")) // Input is email
            {
                stringBuider.Append((int)InputType.Email);
            }
            else
            {
                stringBuider.Append((int)InputType.Phone);
            }
            return stringBuider.ToString();
        }

        public override int GetRemainTimeFromOtp(string otp)
        {
            throw new NotImplementedException();
        }
    }
    public enum InputType
    {
        Phone = 1,
        Email = 2
    }
}
