using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Core;
using Grpc.Net.Client;
namespace Sigame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            using (var channel = GrpcChannel.ForAddress("localhost:50051"))
            {
                var client = new SessionsDispatcher.SessionsDispatcherClient(channel);
                try
                {
                    var sessionsStream = client.GetSessions(new Void());
                    while (sessionsStream.ResponseStream.MoveNext().Result)
                    {
                        var session = sessionsStream.ResponseStream.Current;
                        sessionList_box.Items.Add(session.Ip);

                    }
                }
                catch
                {

                }
            } 
        }


    }
}
