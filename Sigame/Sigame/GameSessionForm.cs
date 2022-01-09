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
        public GameSessionForm()
        {
            InitializeComponent();

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

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("localhost"), 8000);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endPoint);
            
            Helper.SendMes(socket, JObject.FromObject(new {session_name = "1" } ) );
        }

        private void CellClickHandler(object sender, DataGridViewCellEventArgs e) 
        {
            DataGridView view = (DataGridView)sender;
            if (view[e.ColumnIndex, e.RowIndex] is DataGridViewButtonDisableCell @cell)
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
