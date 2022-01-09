using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Sigame
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
        }

        private void send_messege_button_Click(object sender, EventArgs e)
        {
            chatBox.Items.Add(textBox1.Text);
        }
    }
}
