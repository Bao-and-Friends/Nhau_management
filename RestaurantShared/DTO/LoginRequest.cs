using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantShared.DTO
{
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public LoginRequest() { }
        public LoginRequest(string u, string p) { Username = u; Password = p; }
    }
}
