using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantShared.DTO.Configuration
{
    public class EmailConfig
    {
        public string SenderEmail { get; set; } = string.Empty;
        public string AppPassword{ get; set; } = string.Empty;
    }
}
