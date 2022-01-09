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
        }

        private void CellClickHandler(object sender, DataGridViewCellEventArgs e) 
        {
            DataGridView view = (DataGridView)sender;
            if (view[e.ColumnIndex, e.RowIndex] is DataGridViewButtonDisableCell @cell)
            {
                if (cell.Tag == null)
                {
                    cell.Enabled = false;
                    cell.Tag = "clicked";
                }
            }
        }
    }
}
