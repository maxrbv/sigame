using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json.Linq;
namespace Sigame
{
    public partial class GameSessionForm : Form
    {
        
        BackgroundWorker clientsAccepter = new BackgroundWorker();
        List<Socket> SessionSockets = new List<Socket>();

        delegate void updateUserListDelegate(object new_item);
        delegate string[][] getUsersListDelegate();

        updateUserListDelegate updateUserList;
        getUsersListDelegate getUsersList;

        Socket Socket { get; set; }

        string ServerIp { get; set; }
        int ServerPort { get; set; }
        bool IsServer { get; set; }

        public GameSessionForm(bool isServer, string nickname, string serverIp, int serverPort)
        {
            InitializeComponent();
            updateUserList += UpdateUsersListAction;
            getUsersList += GetUsersArrayAction;

            IsServer = isServer;
            ServerIp = serverIp;
            ServerPort = serverPort;

            var connection_string_builder = new NpgsqlConnectionStringBuilder() { Host = "localhost", Port = 5432, Username = "postgres", Password = "postgres", Database = "SIGame" };
            var connection = new NpgsqlConnection(connection_string_builder.ToString());

            connection.Open();

            var command = new NpgsqlCommand(cmdText: "select distinct category_name as \"Темы\" from category", connection: connection);
            NpgsqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                DataTable data = new DataTable();
                data.Load(dataReader);
                questionsField.DataSource = data;

            }

            command.Dispose();
            connection.Close();

            for (int i = 0; i < questionsField.Columns.Count; i++)
            {
                if (i == questionsField.Columns.Count - 1)
                {
                    questionsField.Columns[i].DisplayIndex = 0;
                }
                else
                {
                    questionsField.Columns[i].DisplayIndex = i + 1;
                }
            }
            questionsField.CellClick += CellClickHandler;


            /* if client is host then create socket server*/
            if (IsServer)
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIp), ServerPort);
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket.Bind(endPoint);
                Socket.Listen(10);

                clientsAccepter.DoWork += ClientsAccepter_DoWork; ;
                clientsAccepter.RunWorkerAsync();

                playersView.Items.Add(new ListViewItem(new[] { "", nickname, "0" }));
            }
            /* else connect to server */
            else
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIp), ServerPort);
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                Socket.Connect(endPoint);
                BackgroundWorker messageReciver = new BackgroundWorker();
                messageReciver.DoWork += MessageReciver_DoWork;
                messageReciver.RunWorkerAsync(Socket);

                Helper.SendMes(Socket, JObject.FromObject(new { type = "new_player", player = new[] { "", nickname, "0" } }));
            }
        }

        private void ClientsAccepter_DoWork(object sender, DoWorkEventArgs e)
        {
            // Accept client connection and update array socket connections
            while (true)
            {
                Socket client = Socket.Accept();
                SessionSockets.Add(client);

                BackgroundWorker messageReciver = new BackgroundWorker();
                messageReciver.DoWork += MessageReciver_DoWork;
                messageReciver.RunWorkerAsync(client);
            }
        }

        private void MessageReciver_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get message from client if current socket is host or from server if current socket is client
            while (true)
            {
                try
                {
                    var message = Helper.RecieveMes((Socket)e.Argument);

                    if (message["type"].ToString() == "new_player")
                    {
                        var users = InvokeGetUsersList();
                        users = users.Append(message["player"].ToObject<string[]>()).ToArray();
                        InvokeUpdateUsersList(users);

                        // Send message to all clients
                        foreach (Socket client in SessionSockets)
                            Helper.SendMes(client, JObject.FromObject(new { type="update_users_list", users=users }));
                    }
                    else if (message["type"].ToString() == "update_users_list")
                    {
                        InvokeUpdateUsersList(message["users"].ToObject<string[][]>());
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
        }

        private void CellClickHandler(object sender, DataGridViewCellEventArgs e) 
        {
            DataGridView view = (DataGridView)sender;
            if (e.ColumnIndex > -1 && e.RowIndex > -1 && view[e.ColumnIndex, e.RowIndex] is DataGridViewButtonDisableCell @cell)
            {
                if (cell.Tag == null)
                {              
                    questionsField.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    Chat chat = new Chat();
                    chat.ShowDialog();
                    cell.Enabled = false;
                    cell.Tag = "clicked";
                }
            }
        }
        public string GetQuestionText(string theme, string cost)
        {
            var connection_string_builder = new NpgsqlConnectionStringBuilder() { Host = "localhost", Port = 5432, Username = "postgres", Password = "postgres", Database = "SIGame" };
            var connection = new NpgsqlConnection(connection_string_builder.ToString());

            connection.Open();

            var command = new NpgsqlCommand(cmdText: "select distinct question where value=@loc_name and  from questions order by rand() limit 1", connection: connection);

            
            NpgsqlDataReader dataReader = command.ExecuteReader();
            string questionText="";
            return questionText;
        }

        private void InvokeUpdateUsersList(object new_item)
        {
            playersView.Invoke(updateUserList, new_item);
        }

        private void UpdateUsersListAction(object new_item)
        {
            playersView.Items.Clear();

            string[][] users = (string[][])new_item;
            foreach(string[] user in users)
                playersView.Items.Add(new ListViewItem(user));
        }

        private string[][] InvokeGetUsersList()
        {
            return (string[][])playersView.Invoke(getUsersList);
        }

        private string[][] GetUsersArrayAction()
        {
            List<string[]> rows = new List<string[]>();
            foreach(ListViewItem row in playersView.Items)
            {
                
                {
                    List<string> cells = new List<string>() ;
                    foreach (ListViewItem.ListViewSubItem cell in row.SubItems)
                    {
                            cells.Add(cell.Text);
                    }
                    rows.Add(cells.ToArray());
                }
            }
            return rows.ToArray();
        }
    }
}
