using RestaurantShared.DTO;
using RestaurantShared.Network;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RestaurantManagement.UI.Network
{
    public class TcpCustomer : TCPManager
    {
        private static readonly Lazy<TcpCustomer> CLIENT = new(() => new TcpCustomer());
        public static TcpCustomer Instance => CLIENT.Value;
        private TcpCustomer() { }
        public bool ConnectServer(string ip = "127.0.0.1", int port = 8080)
        {
            try
            {
                if (client != null && client.Connected) return true;
                client = new TcpClient();
                client.Connect(ip, port);
                return true;
            }
            catch
            {
                return false;
            }
        }
        // Gửi 1 gói tin và chờ gói tin phản hồi từ Server
        public async Task<NetworkPacket?> SendRequestAsync(NetworkPacket packet)
        {
            if (await SendAsync<NetworkPacket>(packet))
            {
                return await ReceiveAsync<NetworkPacket>();
            }
            return null;
        }

    }
}
