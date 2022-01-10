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
        BackgroundWorker messageReciver = new BackgroundWorker();
        Socket socket;
        public GameSessionForm(string nickname)
        {
            InitializeComponent();

            var connection_string_builder = new NpgsqlConnectionStringBuilder() { Host = "localhost", Port = 5432, Username = "postgres", Password = "maxrbv", Database = "SIGame" };
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

            for(int i = 0; i < questionsField.Columns.Count; i++)
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

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            messageReciver.DoWork += MessageReciver_DoWork; ;
            messageReciver.RunWorkerAsync();

            socket.Connect(endPoint);
            
            Helper.SendMes(socket, JObject.FromObject(new { session_name = "1" } ) );
            Helper.SendMes(socket, JObject.FromObject(new { type = "new_player", player_name = nickname } ) );

            playersView.Items.Add(nickname);
        }

        private void MessageReciver_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
                try
                {
                    var message = Helper.RecieveMes(socket);
                    if (message["type"].ToString() == "new_player")
                    {
                        playersView.Items.Add(message["player_name"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
    }
}
