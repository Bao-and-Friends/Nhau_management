using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Xml.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestaurantShared.Network
{
    public abstract class TCPManager
    {
        private const int MaxPacketSize = 10 * 1024 * 1024;
        protected IPEndPoint iep = new(IPAddress.Loopback,8080);
        protected TcpClient? client = null;

        public byte[] SerializeData<T>(T obj)
        {
            string json = JsonSerializer.Serialize(obj);
            return Encoding.UTF8.GetBytes(json);
        }

        public T? DeserializeData<T>(byte[] data)
        {
            string json = Encoding.UTF8.GetString(data);
            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task<T?> ReceiveAsync<T>(NetworkStream stream)
        {
            try
            {
                byte[]? lengthBuffer = await ReadExactBytesAsync(stream, 4).ConfigureAwait(false);
                if (lengthBuffer == null) return default;
                int dataLength = BitConverter.ToInt32(lengthBuffer, 0);
                if (dataLength <= 0 || dataLength > MaxPacketSize) return default;
                byte[]? dataBuffer = await ReadExactBytesAsync(stream, dataLength).ConfigureAwait(false);
                if (dataBuffer == null) return default;
                return DeserializeData<T>(dataBuffer);
            }
            catch
            {
                return default;
            }
        }

        public virtual async Task<bool> SendAsync<T>(T data)
        {
            if (client == null || !client.Connected || data == null) return false;
            return await SendAsync(client.GetStream(), data).ConfigureAwait(false);
        }

        public virtual async Task<T?> ReceiveAsync<T>()
        {
            if (client == null || !client.Connected) return default;
            return await ReceiveAsync<T>(client.GetStream()).ConfigureAwait(false);
        }

        public async Task<bool> SendAsync<T>(NetworkStream stream, T data)
        {
            try
            {
                byte[] byteData = SerializeData(data);
                byte[] lengthPrefix = BitConverter.GetBytes(byteData.Length);
                byte[] packet = new byte[4 + byteData.Length];
                Buffer.BlockCopy(lengthPrefix, 0, packet, 0, 4);
                Buffer.BlockCopy(byteData, 0, packet, 4, byteData.Length);
                await stream.WriteAsync(packet.AsMemory(0, packet.Length)).ConfigureAwait(false);
                await stream.FlushAsync().ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<byte[]?> ReadExactBytesAsync(NetworkStream stream, int count)
        {
            byte[] buffer = new byte[count];
            int totalRead = 0;
            while (totalRead < count)
            {
                int read = await stream.ReadAsync(buffer.AsMemory(totalRead, count - totalRead)).ConfigureAwait(false);
                if (read == 0) return null;
                totalRead += read;
            }
            return buffer;
        }
    }
}
