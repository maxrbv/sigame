using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
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
        private Socket server;
        private string MyAddress { 
            get { 
                return string.Format("{0}:{1}", myIpTextBox.Text, myPortTextBox.Text);
            } 
        }

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
            myIpTextBox.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList[2].ToString();
        }

        private void open_session_button_Click(object sender, EventArgs e)
        {
            GameSessionForm game;

            if (sessionList_box.SelectedItem == null)
            {
                MessageBox.Show("Выберите сессию");
                return;
            }

            if (sessionList_box.SelectedItem.ToString() == MyAddress)
                game = new GameSessionForm(true, nicknameTextBox.Text, myIpTextBox.Text, int.Parse(myPortTextBox.Text));
            else
            {
                string[] serverAddress = sessionList_box.SelectedItem.ToString().Split(':');
                game = new GameSessionForm(false, nicknameTextBox.Text, serverAddress[0], int.Parse(serverAddress[1]));
            }
            server = game.Socket;
            this.Visible = false;

            game.ShowDialog();

            this.Visible = true;
        }

        private void add_session_button_Click(object sender, EventArgs e)
        {
            sessionList_box.Items.Add(MyAddress);
            var channel = new Channel("localhost:50051", ChannelCredentials.Insecure);
            {
                var client = new SessionsDispatcher.SessionsDispatcherClient(channel);

                var reply = client.AddSession(new Session() { Ip = MyAddress });
                if (reply.Status == 1)
                {
                    MessageBox.Show("Сессия создана");
                }
            }
        }

        private void delete_session_button_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                server.Close();
            }
            sessionList_box.Items.Remove(MyAddress);
            var channel = new Channel("localhost:50051", ChannelCredentials.Insecure);
            {
                var client = new SessionsDispatcher.SessionsDispatcherClient(channel);

                var reply = client.DeleteSession(new Session() { Ip = MyAddress });
                if (reply.Status == 1)
                    MessageBox.Show("Сессия удалена");
            }
        }
    }
}
