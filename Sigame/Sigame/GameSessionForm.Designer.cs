
namespace Sigame
{
    partial class GameSessionForm
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
            this.questionsField = new System.Windows.Forms.DataGridView();
            this.th200 = new Sigame.DataGridViewButtonDisableColumn();
            this.th400 = new Sigame.DataGridViewButtonDisableColumn();
            this.th600 = new Sigame.DataGridViewButtonDisableColumn();
            this.th800 = new Sigame.DataGridViewButtonDisableColumn();
            this.th1000 = new Sigame.DataGridViewButtonDisableColumn();
            this.playersView = new System.Windows.Forms.ListView();
            this.Empy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.points = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.questionlabel = new System.Windows.Forms.Label();
            this.exit_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.questionsField)).BeginInit();
            this.SuspendLayout();
            // 
            // questionsField
            // 
            this.questionsField.AllowUserToAddRows = false;
            this.questionsField.AllowUserToDeleteRows = false;
            this.questionsField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionsField.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.th200,
            this.th400,
            this.th600,
            this.th800,
            this.th1000});
            this.questionsField.Location = new System.Drawing.Point(23, 43);
            this.questionsField.Name = "questionsField";
            this.questionsField.ReadOnly = true;
            this.questionsField.Size = new System.Drawing.Size(680, 352);
            this.questionsField.TabIndex = 0;
            // 
            // th200
            // 
            this.th200.HeaderText = "Очень легко";
            this.th200.Name = "th200";
            this.th200.ReadOnly = true;
            this.th200.Text = "200";
            this.th200.UseColumnTextForButtonValue = true;
            // 
            // th400
            // 
            this.th400.HeaderText = "Легко";
            this.th400.Name = "th400";
            this.th400.ReadOnly = true;
            this.th400.Text = "400";
            this.th400.UseColumnTextForButtonValue = true;
            // 
            // th600
            // 
            this.th600.HeaderText = "Нормально";
            this.th600.Name = "th600";
            this.th600.ReadOnly = true;
            this.th600.Text = "600";
            this.th600.UseColumnTextForButtonValue = true;
            // 
            // th800
            // 
            this.th800.HeaderText = "По-тяжелее";
            this.th800.Name = "th800";
            this.th800.ReadOnly = true;
            this.th800.Text = "800";
            this.th800.UseColumnTextForButtonValue = true;
            // 
            // th1000
            // 
            this.th1000.HeaderText = "Сложно";
            this.th1000.Name = "th1000";
            this.th1000.ReadOnly = true;
            this.th1000.Text = "1000";
            this.th1000.UseColumnTextForButtonValue = true;
            // 
            // playersView
            // 
            this.playersView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Empy,
            this.name,
            this.points});
            this.playersView.HideSelection = false;
            this.playersView.Location = new System.Drawing.Point(718, 43);
            this.playersView.Name = "playersView";
            this.playersView.Size = new System.Drawing.Size(247, 352);
            this.playersView.TabIndex = 1;
            this.playersView.UseCompatibleStateImageBehavior = false;
            this.playersView.View = System.Windows.Forms.View.Details;
            // 
            // Empy
            // 
            this.Empy.Width = 0;
            // 
            // name
            // 
            this.name.Text = "Имя";
            // 
            // points
            // 
            this.points.Text = "Счёт";
            this.points.Width = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(818, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Счёт";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Вопрос:";
            // 
            // questionlabel
            // 
            this.questionlabel.AutoSize = true;
            this.questionlabel.Location = new System.Drawing.Point(20, 422);
            this.questionlabel.Name = "questionlabel";
            this.questionlabel.Size = new System.Drawing.Size(91, 13);
            this.questionlabel.TabIndex = 4;
            this.questionlabel.Text = "Какой-то вопрос";
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(718, 405);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(247, 30);
            this.exit_button.TabIndex = 5;
            this.exit_button.Text = "Выйти из сессии";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // GameSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 457);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.questionlabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playersView);
            this.Controls.Add(this.questionsField);
            this.Name = "GameSessionForm";
            this.Text = "SIGAME SESSION";
            ((System.ComponentModel.ISupportInitialize)(this.questionsField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView questionsField;
        private System.Windows.Forms.ListView playersView;
        private System.Windows.Forms.ColumnHeader Empy;
        private System.Windows.Forms.ColumnHeader points;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label questionlabel;
        private DataGridViewButtonDisableColumn th200;
        private DataGridViewButtonDisableColumn th400;
        private DataGridViewButtonDisableColumn th600;
        private DataGridViewButtonDisableColumn th800;
        private DataGridViewButtonDisableColumn th1000;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.Button exit_button;
    }
}