using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Text.Encodings;
namespace Sigame
{
    public static class Helper
    {
        public static JObject RecieveMes(Socket socket)
        {

            List<byte> builder = new List<byte>();
            int bytes = 0;
            byte[] data = new byte[256]; 
            do
            {
                bytes = socket.Receive(data);
                for (int i = 0; i < bytes; i++)
                    builder.Add(data[i]);
            } while (socket.Available > 0);

            return JObject.Parse(Encoding.UTF8.GetString(builder.ToArray()));
       
        }
        public static void SendMes(Socket socket,JObject message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message.ToString());
            socket.Send(BitConverter.GetBytes(data.Length), 4, SocketFlags.None);
            socket.Send(data,SocketFlags.None);
        }

    }
}
