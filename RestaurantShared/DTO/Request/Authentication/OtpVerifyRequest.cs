using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantShared.DTO.Request.Authentication
{
    public class OtpVerifyRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Otp { get; set; } = string.Empty;
        public OtpVerifyRequest(string username,string otp) { Username = username; Otp = otp; }
    }
}
