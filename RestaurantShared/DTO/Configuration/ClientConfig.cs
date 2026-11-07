using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantShared.DTO.Configuration
{
    public class ClientConfig
    {
        public string IpServer { get; set; } = string.Empty;
        public int PortSever { get; set; } = 8080;
    }
}
