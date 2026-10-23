using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using RestaurantShared.Network;
using System.Net;

namespace RestaurantManagement.UI.Network
{
    public class TcpCustomer : TCPManager
    {
        private static readonly Lazy<TcpCustomer> CLIENT = new(() => new TcpCustomer());
        public static TcpCustomer Instance => CLIENT.Value;
        private TcpCustomer() { }
        public bool ConnectSever()
        {
            client = new();
            try
            {
                client.Connect(iep);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}
