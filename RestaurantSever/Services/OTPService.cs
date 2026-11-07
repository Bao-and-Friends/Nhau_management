using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Runtime.Caching;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace RestaurantSever.Services
{
    public class OTPService
    {
        private static readonly Lazy<OTPService> OTP = new(() => new OTPService());
        public static OTPService Instance => OTP.Value;
        private OTPService() { }
        private MemoryCache cache = MemoryCache.Default;

        public string CreateOTP()
        {
           return new Random().Next(100000, 999999).ToString();
        }

        public bool isOTPSended(string username)
        {
            if (cache.Contains(username)) return true;
            return false;
        }
        public void SaveOTP(string username, string otp)
        {
            cache.Set(username, otp,DateTimeOffset.Now.AddMinutes(2));
        }
        public bool VerifyOTP(string username, string InputOtp)
        {
            if(cache.Contains(username))
            {
                string otp = cache.Get(username).ToString()!;
                if(otp.CompareTo(InputOtp)==0)
                {
                    cache.Remove(username);
                    return true;
                }
            }
            return false;
        }
    }
}
