using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

using TcpClient client = new();
client.Connect("192.168.1.18", 5000);

using NetworkStream ns = client.GetStream();
using StreamWriter sw = new(ns, Encoding.UTF8);

sw.WriteLine("hello");
sw.Flush();