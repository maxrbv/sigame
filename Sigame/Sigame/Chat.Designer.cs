
namespace Sigame
{
    partial class Chat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chatBox = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.questionText = new System.Windows.Forms.Label();
            this.send_messege_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chatBox
            // 
            this.chatBox.FormattingEnabled = true;
            this.chatBox.Location = new System.Drawing.Point(12, 84);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(363, 251);
            this.chatBox.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 343);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(271, 20);
            this.textBox1.TabIndex = 1;
            // 
            // questionText
            // 
            this.questionText.AutoSize = true;
            this.questionText.Location = new System.Drawing.Point(12, 25);
            this.questionText.Name = "questionText";
            this.questionText.Size = new System.Drawing.Size(69, 13);
            this.questionText.TabIndex = 2;
            this.questionText.Text = "Question text";
            // 
            // send_messege_button
            // 
            this.send_messege_button.Location = new System.Drawing.Point(289, 341);
            this.send_messege_button.Name = "send_messege_button";
            this.send_messege_button.Size = new System.Drawing.Size(84, 23);
            this.send_messege_button.TabIndex = 3;
            this.send_messege_button.Text = "Отправить";
            this.send_messege_button.UseVisualStyleBackColor = true;
            this.send_messege_button.Click += new System.EventHandler(this.send_messege_button_Click);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 375);
            this.Controls.Add(this.send_messege_button);
            this.Controls.Add(this.questionText);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chatBox);
            this.Name = "Chat";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox chatBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label questionText;
        private System.Windows.Forms.Button send_messege_button;
    }
}