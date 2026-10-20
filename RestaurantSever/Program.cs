using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

IPEndPoint ep = new(IPAddress.Any, 5000);
TcpListener server = new(ep);

server.Start();
Console.WriteLine("Server dang cho ket noi...");

while (true)
{
    using TcpClient client = server.AcceptTcpClient();
    using NetworkStream ns = client.GetStream();
    using StreamReader sr = new(ns, Encoding.UTF8);

    string? data = sr.ReadLine();

    if (data != null)
    {
        Console.WriteLine($"Client gui: {data}");
    }
}