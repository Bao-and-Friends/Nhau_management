using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantShared.DTO
{
    public class ChangePasswordRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ChangePasswordRequest() { }
        public ChangePasswordRequest(string user, string pass) { Username = user; Password = pass; }
    }
}
