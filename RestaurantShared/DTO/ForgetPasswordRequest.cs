using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantShared.DTO
{
    public class ForgetPasswordRequest
    {
        public string Username { get; set; } = string.Empty;
        public ForgetPasswordRequest() { }
        public ForgetPasswordRequest(string u) { Username = u; }
    }
}
