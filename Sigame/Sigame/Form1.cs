using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;

namespace Sigame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var channel = new Channel("localhost:50051", ChannelCredentials.Insecure );
            {
                var client = new SessionsDispatcher.SessionsDispatcherClient(channel);

                var sessionsStream = client.GetSessions(new Void());
                while (sessionsStream.ResponseStream.MoveNext().Result)
                {
                    var session = sessionsStream.ResponseStream.Current;
                    sessionList_box.Items.Add(session.Ip);
                }
            } 
        }

        private void open_session_button_Click(object sender, EventArgs e)
        {
            GameSessionForm game = new GameSessionForm();
            game.ShowDialog();
        }
    }
}
