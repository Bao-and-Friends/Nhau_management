using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
namespace RestaurantSever.Network
{
    using System;
    using System.Net;
    using System.Net.Sockets;

    namespace RestaurantSever.Network
    {
        internal sealed class TcpSever
        {
            private readonly TcpListener listener;

            // Properties
            public int Port { get; }

            public bool IsRunning { get; private set; }

            public EndPoint? LocalEndpoint => IsRunning ? listener.LocalEndpoint : null;

            // Singleton
            private static readonly Lazy<TcpSever> sv = new(() => new TcpSever(5000));

            public static TcpSever Instance => sv.Value;

            // Constructor
            private TcpSever(int port)
            {
                Port = port;
                listener = new TcpListener(IPAddress.Any, Port);
            }

            // Khởi động Server
            public bool Start()
            {
                if (IsRunning)
                    return true;

                try
                {
                    listener.Start();
                    IsRunning = true;

                    Console.WriteLine(
                        $"Server đang chạy tại port {Port}");

                    return true;
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(
                        $"Không thể khởi động Server: {ex.Message}");

                    return false;
                }
            }

            // Dừng Server
            public bool Stop()
            {
                if (!IsRunning)
                    return true;

                try
                {
                    listener.Stop();
                    IsRunning = false;

                    Console.WriteLine("Server đã dừng.");

                    return true;
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(
                        $"Không thể dừng Server: {ex.Message}");

                    return false;
                }
            }
        }
    }

}

