using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantShared.DTO.Request.Authentication
{
    public class ResendOtpRequest
    {
        public string username { get; set; } = string.Empty;
        public ResendOtpRequest() { }
        public ResendOtpRequest(string u) { username = u; }

    }
}
