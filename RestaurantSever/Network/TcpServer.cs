using RestaurantShared.DAO;
using RestaurantShared.DTO;
using RestaurantShared.Network;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestaurantSever.Network
{
    public class TcpServer: TCPManager
    {
        private static readonly Lazy<TcpServer> sv = new(() => new TcpServer());
        public static TcpServer Instance => sv.Value;
        private TcpServer() { }
        private TcpListener? server;

        public void StartServer()
        {
            server = new(iep);
            server.Start();
            Console.WriteLine($"[SERVER] Đang chạy tại cổng {iep.Port}...");
            // Vòng lặp chấp nhận kết nối đa luồng
            Task.Run(AcceptLoop);
        }
        private async Task AcceptLoop()
        {
            while (server != null)
            {
                try
                {
                    TcpClient clientSocket = await server.AcceptTcpClientAsync();
                    Console.WriteLine($"[+] Client kết nối: {clientSocket.Client.RemoteEndPoint}");

                    // Mỗi client được xử lý trên 1 Task riêng biệt
                    HandleClientAsync(clientSocket);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Accept Error]: {ex.Message}");
                    break;
                }
            }
        }
        // Vòng lặp nhận và xử lý gói tin của 1 Client cụ thể
        private async void HandleClientAsync(TcpClient clientSocket)
        {
            NetworkStream stream = clientSocket.GetStream();
            while (clientSocket.Connected)
            {
                // Nhận NetworkPacket từ Client
                NetworkPacket? request = await ReceiveAsync<NetworkPacket>(stream);
                if (request == null) break; // Client đã ngắt kết nối
                Console.WriteLine($"[Nhận lệnh]: {request.Action}");
                // Xử lý logic và tạo phản hồi
                NetworkPacket response = ProcessRequest(request);
                // Gửi phản hồi lại cho Client
                await SendAsync(stream, response);
            }
            clientSocket.Close();
            Console.WriteLine("[-] Client đã ngắt kết nối.");
        }
        // Bóc tách hành động nghiệp vụ
        private NetworkPacket ProcessRequest(NetworkPacket req)
        {
            switch (req.Action)
            {
                case "LOGIN":
                    var loginData = JsonSerializer.Deserialize<LoginRequest>(req.Payload);
                    string maNV = AccountDAO.Instance.Login(loginData?.Username ?? "", loginData?.Password ?? "");

                    if (!string.IsNullOrEmpty(maNV))
                    {
                        NhanVienDATA? nv = NhanVienDAO.Instance.GetNhanVienbyID(maNV);
                        return new NetworkPacket
                        {
                            Action = "LOGIN_RESPONSE",
                            IsSuccess = true,
                            Message = "Đăng nhập thành công!",
                            Payload = JsonSerializer.Serialize(nv)
                        };
                    }
                    return new NetworkPacket { Action = "LOGIN_RESPONSE", IsSuccess = false, Message = "Sai tài khoản hoặc mật khẩu!" };
                case "GET_TABLES":
                    var tables = TableDAO.Instance.GetListTable();
                    return new NetworkPacket
                    {
                        Action = "GET_TABLES_RESPONSE",
                        IsSuccess = true,
                        Payload = JsonSerializer.Serialize(tables)
                    };
                default:
                    return new NetworkPacket { Action = "UNKNOWN", IsSuccess = false, Message = "Lệnh không hợp lệ" };
            }
        }


    }
}
