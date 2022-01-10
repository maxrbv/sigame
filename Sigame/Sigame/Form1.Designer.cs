
namespace Sigame
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.add_session_button = new System.Windows.Forms.Button();
            this.update_session_button = new System.Windows.Forms.Button();
            this.sessionList_box = new System.Windows.Forms.ListBox();
            this.delete_session_button = new System.Windows.Forms.Button();
            this.open_session_button = new System.Windows.Forms.Button();
            this.myIpTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nicknameTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.myPortTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // add_session_button
            // 
            this.add_session_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.add_session_button.Location = new System.Drawing.Point(237, 46);
            this.add_session_button.Name = "add_session_button";
            this.add_session_button.Size = new System.Drawing.Size(129, 30);
            this.add_session_button.TabIndex = 0;
            this.add_session_button.Text = "Создать сессию";
            this.add_session_button.UseVisualStyleBackColor = true;
            this.add_session_button.Click += new System.EventHandler(this.add_session_button_Click);
            // 
            // update_session_button
            // 
            this.update_session_button.Location = new System.Drawing.Point(12, 18);
            this.update_session_button.Name = "update_session_button";
            this.update_session_button.Size = new System.Drawing.Size(167, 30);
            this.update_session_button.TabIndex = 1;
            this.update_session_button.Text = "Обновить список сессий";
            this.update_session_button.UseVisualStyleBackColor = true;
            // 
            // sessionList_box
            // 
            this.sessionList_box.FormattingEnabled = true;
            this.sessionList_box.Location = new System.Drawing.Point(12, 54);
            this.sessionList_box.Name = "sessionList_box";
            this.sessionList_box.Size = new System.Drawing.Size(167, 173);
            this.sessionList_box.TabIndex = 2;
            // 
            // delete_session_button
            // 
            this.delete_session_button.Location = new System.Drawing.Point(228, 170);
            this.delete_session_button.Name = "delete_session_button";
            this.delete_session_button.Size = new System.Drawing.Size(129, 32);
            this.delete_session_button.TabIndex = 3;
            this.delete_session_button.Text = "Удалить сессию";
            this.delete_session_button.UseVisualStyleBackColor = true;
            this.delete_session_button.Click += new System.EventHandler(this.delete_session_button_Click);
            // 
            // open_session_button
            // 
            this.open_session_button.Location = new System.Drawing.Point(12, 233);
            this.open_session_button.Name = "open_session_button";
            this.open_session_button.Size = new System.Drawing.Size(167, 32);
            this.open_session_button.TabIndex = 4;
            this.open_session_button.Text = "Войти";
            this.open_session_button.UseVisualStyleBackColor = true;
            this.open_session_button.Click += new System.EventHandler(this.open_session_button_Click);
            // 
            // myIpTextBox
            // 
            this.myIpTextBox.Location = new System.Drawing.Point(257, 82);
            this.myIpTextBox.Name = "myIpTextBox";
            this.myIpTextBox.Size = new System.Drawing.Size(109, 20);
            this.myIpTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP";
            // 
            // nicknameTextBox
            // 
            this.nicknameTextBox.Location = new System.Drawing.Point(228, 207);
            this.nicknameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.nicknameTextBox.Name = "nicknameTextBox";
            this.nicknameTextBox.Size = new System.Drawing.Size(76, 20);
            this.nicknameTextBox.TabIndex = 7;
            this.nicknameTextBox.Text = "Имя";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(225, 111);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 9;
            this.portLabel.Text = "Port";
            // 
            // myPortTextBox
            // 
            this.myPortTextBox.Location = new System.Drawing.Point(257, 108);
            this.myPortTextBox.Name = "myPortTextBox";
            this.myPortTextBox.Size = new System.Drawing.Size(109, 20);
            this.myPortTextBox.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 283);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.myPortTextBox);
            this.Controls.Add(this.nicknameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myIpTextBox);
            this.Controls.Add(this.open_session_button);
            this.Controls.Add(this.delete_session_button);
            this.Controls.Add(this.sessionList_box);
            this.Controls.Add(this.update_session_button);
            this.Controls.Add(this.add_session_button);
            this.Name = "Form1";
            this.Text = "SIGAME";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add_session_button;
        private System.Windows.Forms.Button update_session_button;
        private System.Windows.Forms.ListBox sessionList_box;
        private System.Windows.Forms.Button delete_session_button;
        private System.Windows.Forms.Button open_session_button;
        private System.Windows.Forms.TextBox myIpTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nicknameTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox myPortTextBox;
    }
}

