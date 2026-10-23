using RestaurantShared.DAO;
using RestaurantShared.Network;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestaurantSever.Network
{
    public class TcpSever: TCPManager
    {
        private static readonly Lazy<TcpSever> sv = new(() => new TcpSever());
        public static TcpSever Instance => sv.Value;
        private TcpSever() { }
        private TcpListener? sever;

        public void StartSever()
        {
            sever = new(iep);
            sever.Start();
            Console.WriteLine($"Server đang chạy tại cổng {iep.Port}...");
        }
     
        
     
    }
}
