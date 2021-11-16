using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableShop.Services.Abstractions
{
    public abstract class Otp
    {
        public abstract string ComputeOtp();
        public abstract int GetRemainTimeFromOtp(string otp);
    }
}
