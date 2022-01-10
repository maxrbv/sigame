
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nicknameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // add_session_button
            // 
            this.add_session_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.add_session_button.Location = new System.Drawing.Point(304, 57);
            this.add_session_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.add_session_button.Name = "add_session_button";
            this.add_session_button.Size = new System.Drawing.Size(172, 37);
            this.add_session_button.TabIndex = 0;
            this.add_session_button.Text = "Создать сессию";
            this.add_session_button.UseVisualStyleBackColor = true;
            // 
            // update_session_button
            // 
            this.update_session_button.Location = new System.Drawing.Point(16, 22);
            this.update_session_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.update_session_button.Name = "update_session_button";
            this.update_session_button.Size = new System.Drawing.Size(223, 37);
            this.update_session_button.TabIndex = 1;
            this.update_session_button.Text = "Обновить список сессий";
            this.update_session_button.UseVisualStyleBackColor = true;
            // 
            // sessionList_box
            // 
            this.sessionList_box.FormattingEnabled = true;
            this.sessionList_box.ItemHeight = 16;
            this.sessionList_box.Location = new System.Drawing.Point(16, 66);
            this.sessionList_box.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sessionList_box.Name = "sessionList_box";
            this.sessionList_box.Size = new System.Drawing.Size(221, 212);
            this.sessionList_box.TabIndex = 2;
            // 
            // delete_session_button
            // 
            this.delete_session_button.Location = new System.Drawing.Point(304, 133);
            this.delete_session_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.delete_session_button.Name = "delete_session_button";
            this.delete_session_button.Size = new System.Drawing.Size(172, 39);
            this.delete_session_button.TabIndex = 3;
            this.delete_session_button.Text = "Удалить сессию";
            this.delete_session_button.UseVisualStyleBackColor = true;
            // 
            // open_session_button
            // 
            this.open_session_button.Location = new System.Drawing.Point(16, 287);
            this.open_session_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.open_session_button.Name = "open_session_button";
            this.open_session_button.Size = new System.Drawing.Size(223, 39);
            this.open_session_button.TabIndex = 4;
            this.open_session_button.Text = "Войти";
            this.open_session_button.UseVisualStyleBackColor = true;
            this.open_session_button.Click += new System.EventHandler(this.open_session_button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(331, 101);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 22);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP";
            // 
            // nicknameTextBox
            // 
            this.nicknameTextBox.Location = new System.Drawing.Point(304, 255);
            this.nicknameTextBox.Name = "nicknameTextBox";
            this.nicknameTextBox.Size = new System.Drawing.Size(100, 22);
            this.nicknameTextBox.TabIndex = 7;
            this.nicknameTextBox.Text = "Имя";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 348);
            this.Controls.Add(this.nicknameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.open_session_button);
            this.Controls.Add(this.delete_session_button);
            this.Controls.Add(this.sessionList_box);
            this.Controls.Add(this.update_session_button);
            this.Controls.Add(this.add_session_button);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nicknameTextBox;
    }
}

