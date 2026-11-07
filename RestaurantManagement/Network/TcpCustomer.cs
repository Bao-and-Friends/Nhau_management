using RestaurantShared;
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
        public bool ConnectServer()
        {
            try
            {
                if (client != null && client.Connected) return true;
                client = new TcpClient(AppConfig.Instance.clientconfig!.IpServer, AppConfig.Instance.clientconfig.PortSever);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DisConnectServer()
        {
            try
            {
                if (client != null)
                {
                    // 1. Đóng luồng dữ liệu trước (nếu bạn có lưu biến stream riêng)
                    //stream?.Close();
                    //stream?.Dispose();
                    //stream = null;

                    // 2. Đóng và giải phóng TcpClient (bất kể Connected đang true hay false)
                    client.Close();
                    client = null;

                    return true;
                }
            }
            catch (Exception ex)
            {
                // Ghi log nếu có lỗi phát sinh khi đóng socket
                Console.WriteLine($"Lỗi khi ngắt kết nối: {ex.Message}");
            }

            return false;
        }
        // Gửi 1 gói tin và chờ gói tin phản hồi từ Server
        public async Task<NetworkPacket?> SendRequestAndWaitResponseAsync(NetworkPacket packet)
        {
            if (await SendAsync<NetworkPacket>(packet).ConfigureAwait(false))
            {
                return await ReceiveAsync<NetworkPacket>().ConfigureAwait(false);
            }
            return null;
        }

    }
}
