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
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Sigame
{

    public partial class GameSessionForm : Form
    {
        const string rabbitmqHost = "localhost";
        BackgroundWorker clientsAccepter = new BackgroundWorker();
        BackgroundWorker chatReciever = new BackgroundWorker();
        List<Socket> SessionSockets = new List<Socket>();

        delegate void updateUserListDelegate(object new_item);
        delegate string[][] getUsersListDelegate();
        delegate void updateQuestionTextDelegate(string question_text);
        delegate void updateChatTextDelegate(string message);
        delegate void updateScoreDelegate(string nickname);
        delegate void updateQuestionsFieldDelegate(bool enabled);

        updateUserListDelegate updateUserList;
        getUsersListDelegate getUsersList;
        updateQuestionTextDelegate updateQuestionText;
        updateChatTextDelegate updateChatText;
        updateScoreDelegate updateScore;
        updateQuestionsFieldDelegate updateQuestionsField;

        public Socket Socket { get; set; }

        string Nickname { get; set; }
        string Answer { get; set; }
        int Score { get; set; }
        string ServerIp { get; set; }
        int ServerPort { get; set; }
        bool IsServer { get; set; }

        int CurrentRow { get; set; }
        int CurrentColumn { get; set; }

        IConnection rabbitmqConnection;
        IModel sendChannel;

        public GameSessionForm(bool isServer, string nickname, string serverIp, int serverPort)
        {
            InitializeComponent();
            updateUserList += UpdateUsersListAction;
            getUsersList += GetUsersArrayAction;
            updateQuestionText += UpdateQuestionTextAction;
            updateChatText += UpdateChatTextAction;
            updateScore += UpdateScoreAction;
            updateQuestionsField += UpdateQuestionsFieldAction;

            var factory = new ConnectionFactory()
            {
                HostName = rabbitmqHost,
                UserName = "admin",
                Password = "admin",
            };

            rabbitmqConnection = factory.CreateConnection();
            sendChannel = rabbitmqConnection.CreateModel();
            sendChannel.ExchangeDeclare(serverIp, ExchangeType.Fanout);

            IsServer = isServer;
            ServerIp = serverIp;
            ServerPort = serverPort;
            Nickname = nickname;

            var connection_string_builder = new NpgsqlConnectionStringBuilder() { Host = "35.224.58.55", Username = "postgres", Password = "postgres", Database = "SIGame" };
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

                playersView.Items.Add(new ListViewItem(new[] { "", Nickname, "0" }));
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

                Helper.SendMes(Socket, JObject.FromObject(new { type = "new_player", player = new[] { "", Nickname, "0" } }));
            }


            

            chatReciever.DoWork += ChatReciever_DoWork;
            chatReciever.RunWorkerAsync();
        }

        private void ClientsAccepter_DoWork(object sender, DoWorkEventArgs e)
        {
            // Accept client connection and update array socket connections
            while (true)
            {
                try
                {
                    Socket client = Socket.Accept();
                    SessionSockets.Add(client);

                    BackgroundWorker messageReciver = new BackgroundWorker();
                    messageReciver.DoWork += MessageReciver_DoWork;
                    messageReciver.RunWorkerAsync(client);
                }
                catch
                {
                    e.Cancel = true;
                }
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
                    else if (IsServer && message["type"].ToString() == "close")
                    {
                        ((Socket)e.Argument).Close();
                        SessionSockets.Remove((Socket)e.Argument);
                    }
                    else if (message["type"].ToString() == "display_question")
                    {
                        Answer = message["answer"].ToString();
                        Score = message["score"].ToObject<int>();
                        CurrentRow = message["row"].ToObject<int>();
                        CurrentColumn = message["column"].ToObject<int>();
                        InvokeUpdateQuestionsField(false);
                        if (IsServer)
                        {
                            foreach (Socket client in SessionSockets)
                            { 
                                Helper.SendMes(client, message);
                            }

                            InvokeUpdateQuestionText(message["question_text"].ToString());
                        }
                        else
                        {
                            InvokeUpdateQuestionText(message["question_text"].ToString());
                        }
                        
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
                    int score = int.Parse(questionsField.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    var info = GetQuestionInfo(questionsField[questionsField.Columns.Count - 1, e.RowIndex].Value.ToString(), score);
                    
                    
                    if (!IsServer)
                    {
                        Helper.SendMes(Socket, JObject.FromObject(new { type = "display_question", question_text = info[0], answer = info[1], score=score, row=e.RowIndex, column=e.ColumnIndex }));
                    }
                    else
                    {
                        questionTextLabel.Text = info[0];
                        Answer = info[1];
                        Score = score;
                        questionsField.Enabled = false;
                        CurrentRow = e.RowIndex;
                        CurrentColumn = e.ColumnIndex;
                        foreach (Socket client in SessionSockets)
                        {
                            Helper.SendMes(client, JObject.FromObject(new { type = "display_question", question_text = info[0], answer = info[1], score=score, row = e.RowIndex, column = e.ColumnIndex }));
                        }
                    }
                }
            }
        }
        public string[] GetQuestionInfo(string theme, int score)
        {
            var connection_string_builder = new NpgsqlConnectionStringBuilder() { Host = "35.224.58.55", Username = "postgres", Password = "postgres", Database = "SIGame" };
            var connection = new NpgsqlConnection(connection_string_builder.ToString());

            connection.Open();

            var command = new NpgsqlCommand(cmdText: "select question, answer from questions inner join category on questions.category_id = category.id where value = @value and category.category_name = @category order by random() limit 1", connection: connection);
            command.Parameters.AddWithValue("@value", score);
            command.Parameters.AddWithValue("@category", theme);
            NpgsqlDataReader question = command.ExecuteReader();
            string questionText = string.Empty;
            string answerText = string.Empty;
            while (question.Read())
            {
                questionText = question[0].ToString();
                answerText = question[1].ToString();
            }
            return new[] { questionText, answerText };

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

        private void InvokeUpdateQuestionText(string question_text)
        {
            questionTextLabel.Invoke(updateQuestionText, question_text);
        }

        private void UpdateQuestionTextAction(string question_text)
        {
            questionTextLabel.Text = question_text;
        }

        private void GameSessionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Socket.Close();
        }

        private void InvokeUpdateChatText(string message)
        {
            chatTextBox.Invoke(updateChatText, message);
        }

        private void UpdateChatTextAction(string message)
        {
            chatTextBox.Items.Add(message);
        }

        private void InvokeUpdateScore(string nickname)
        {
            playersView.Invoke(updateScore, nickname);
        }

        private void UpdateScoreAction(string nickname)
        {
            foreach (ListViewItem row in playersView.Items)
            {
                if (row.SubItems[1].Text == nickname)
                    row.SubItems[2].Text = (int.Parse(row.SubItems[2].Text) + Score).ToString();
            }
        }

        private void InvokeUpdateQuestionsField(bool enabled)
        {
            questionsField.Invoke(updateQuestionsField, enabled);
        }

        private void UpdateQuestionsFieldAction(bool enabled)
        {
            questionsField.Enabled = enabled;
            if (enabled == true)
            {
                var cell = (DataGridViewButtonDisableCell)questionsField[CurrentColumn, CurrentRow];
                cell.Enabled = false;
                cell.Tag = "clicked";
                questionsField.Invalidate();
                questionsField.Update();
            }
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            if (!IsServer)
                Helper.SendMes(Socket, JObject.FromObject(new { type = "close" }));
            this.Close();
        }

        private void ChatReciever_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var channel = rabbitmqConnection.CreateModel())
                {
                    channel.ExchangeDeclare(ServerIp, ExchangeType.Fanout);

                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueBind(queue: queueName,
                                        exchange: ServerIp,
                                        routingKey: "");

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        string user = message.Split(':')[0];
                        
                        string answer = string.Join(" ", message.Split(' ').Skip(1).ToArray()).ToLower();

                        string cheat = string.Empty;
                        try
                        {
                            cheat = message.Split(';')[1].ToLower();
                        }
                        catch { }

                        if (answer == Answer.ToLower())
                        {
                            InvokeUpdateScore(user);
                            InvokeUpdateQuestionsField(true);
                        }

                        if (user != "host")
                        {
                            if (!string.IsNullOrEmpty(cheat) && cheat == "abrakadabra")
                                InvokeUpdateChatText(Answer + " " + Score);
                            else
                                InvokeUpdateChatText(message);
                        }
                    };
                    channel.BasicConsume(queue: queueName,
                                         autoAck: true,
                                         consumer: consumer);
                    while (true) { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void send_messege_button_Click(object sender, EventArgs e)
        {
            var body = Encoding.UTF8.GetBytes(Nickname + ": " + messageTextBox.Text);
            sendChannel.BasicPublish(exchange: ServerIp,
                                         routingKey: "",
                                         basicProperties: null,
                                         body: body);
            messageTextBox.Text = "";
        }
    }
}
