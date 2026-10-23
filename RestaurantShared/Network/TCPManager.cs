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
        public virtual bool Send<T>(T data)
        {
            if (client == null || !client.Connected) return false;
            if (data == null) return false;
            NetworkStream stream = client.GetStream();
            byte[] byteData = SerializeData(data);
            return SendData(stream, byteData);
        }

        public virtual T? Receive<T>()
        {
            if (client == null || !client.Connected) return default;
            NetworkStream stream = client.GetStream();
            if (ReceiveData(stream, out byte[]? byteData) && byteData != null)
            {
                return DeserializeData<T>(byteData);
            }
            return default;
        }

        private bool SendData(NetworkStream stream, byte[] data)
        {
            try
            {
                byte[] lengthPrefix = BitConverter.GetBytes(data.Length);

                stream.Write(lengthPrefix, 0, 4);
                stream.Write(data, 0, data.Length);
                stream.Flush();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ReceiveData(NetworkStream stream, out byte[]? data)
        {
            data = null;
            try
            {
                byte[]? lengthBuffer = ReadExactBytes(stream, 4);
                if (lengthBuffer == null) return false;

                int dataLength = BitConverter.ToInt32(lengthBuffer, 0);
                if (dataLength <= 0) return false;

                data = ReadExactBytes(stream, dataLength);
                if (data == null) return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        private byte[]? ReadExactBytes(NetworkStream stream, int count) // dùng để đọc đủ 4 byte
        {
            byte[] buffer = new byte[count];
            int totalRead = 0;
            while (totalRead < count)
            {
                int read = stream.Read(buffer, totalRead, count - totalRead);
                if (read == 0) return null;
                totalRead += read;
            }
            return buffer;
        }




    }
}
