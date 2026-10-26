using RestaurantSever.DAO;
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
                    TcpClient clientSocket = await server.AcceptTcpClientAsync().ConfigureAwait(false);
                    Console.WriteLine($"[+] Client kết nối: {clientSocket.Client.RemoteEndPoint}");

                    // Mỗi client được xử lý trên 1 Task riêng biệt
                   await HandleClientAsync(clientSocket);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Accept Error]: {ex.Message}");
                    break;
                }
            }
        }
        // Vòng lặp nhận và xử lý gói tin của 1 Client cụ thể
        private async Task HandleClientAsync(TcpClient clientSocket)
        {
            // Bọc cả clientSocket và stream trong using
            using (clientSocket)
            await using (NetworkStream stream = clientSocket.GetStream())
            {
                string clientEndPoint = clientSocket.Client.RemoteEndPoint?.ToString() ?? "Unknown";

                try
                {
                    while (clientSocket.Connected)
                    {
                        // 1. Nhận gói tin
                        NetworkPacket? request = await ReceiveAsync<NetworkPacket>(stream);
                        if (request == null) break; // Client ngắt kết nối chủ động

                        Console.WriteLine($"[Nhận lệnh]: {request.Action} từ {clientEndPoint}");

                        // 2. Xử lý nghiệp vụ
                        NetworkPacket response = ProcessRequest(request);

                        // 3. Gửi phản hồi
                        await SendAsync(stream, response);
                    }
                }
                catch (IOException)
                {
                    // Xảy ra khi Client ngắt kết nối đột ngột giữa chừng
                    Console.WriteLine($"[!] Kết nối từ {clientEndPoint} bị đứt đột ngột.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Lỗi xử lý Client {clientEndPoint}]: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine($"[-] {clientEndPoint} đã ngắt kết nối.");
                }
            }
        }
        // Bóc tách hành động nghiệp vụ
        private NetworkPacket ProcessRequest(NetworkPacket req)
        {
            switch (req.Action)
            {
                case NetworkAction.LOGIN:
                    var loginData = JsonSerializer.Deserialize<LoginRequest>(req.Payload);
                    string maNV = AccountDAO.Instance.Login(loginData?.Username ?? "", loginData?.Password ?? "");

                    if (!string.IsNullOrEmpty(maNV))
                    {
                        NhanVienDATA? nv = NhanVienDAO.Instance.GetNhanVienbyID(maNV);
                        return new NetworkPacket
                        {
                            Action = NetworkAction.LOGIN_RESPONSE,
                            IsSuccess = true,
                            Message = "Đăng nhập thành công!",
                            Payload = JsonSerializer.Serialize(nv)
                        };
                    }
                    return new NetworkPacket { Action = NetworkAction.LOGIN_RESPONSE, IsSuccess = false, Message = "Sai tài khoản hoặc mật khẩu!" };
                case NetworkAction.GET_TABLE_LIST:
                    var tables = TableDAO.Instance.GetListTable();
                    return new NetworkPacket
                    {
                        Action = NetworkAction.GET_TABLE_LIST_RESPONSE,
                        IsSuccess = true,
                        Payload = JsonSerializer.Serialize(tables)
                    };
                case NetworkAction.REGISTER:
                    var registerData = JsonSerializer.Deserialize<RegisterRequest>(req.Payload);
                    if (registerData != null)
                    {
                        var result = AccountDAO.Instance.RegisterAccount(registerData);
                        return new NetworkPacket
                        {
                            Action = NetworkAction.REGISTER_RESPONSE,
                            IsSuccess = result.IsSuccess,
                            Message = result.Message
                        };
                    }
                    return new NetworkPacket
                    {
                        Action = NetworkAction.REGISTER_RESPONSE,
                        IsSuccess = false,
                        Message = "không nhận được phản hồi từ máy chủ!"
                    };
                default:
                    return new NetworkPacket { Action = NetworkAction.UNKNOW, IsSuccess = false, Message = "Lệnh không hợp lệ" };
            }
        }


    }
}
