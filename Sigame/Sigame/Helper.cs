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
            JObject message;
            int size;

            /* Get size message */
            {
                byte[] size_data = new byte[4];
                socket.Receive(size_data, 4, SocketFlags.None);
                size = BitConverter.ToInt32(size_data, 0);
            }

            /* Get entire message */
            {
                byte[] message_data = new byte[size];
                socket.Receive(message_data, size, SocketFlags.None);
                message = JObject.Parse(Encoding.UTF8.GetString(message_data));
            }

            return message;
       
        }
        public static void SendMes(Socket socket,JObject message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message.ToString());
            socket.Send(BitConverter.GetBytes(data.Length), 4, SocketFlags.None);
            socket.Send(data,SocketFlags.None);
        }

    }
}
