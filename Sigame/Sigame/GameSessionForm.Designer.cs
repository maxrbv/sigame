
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
            this.Theme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.th200 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.th400 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.th600 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.th800 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.th1000 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.playersView = new System.Windows.Forms.ListView();
            this.Имя = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Счёт = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.questionlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.questionsField)).BeginInit();
            this.SuspendLayout();
            // 
            // questionsField
            // 
            this.questionsField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionsField.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Theme,
            this.th200,
            this.th400,
            this.th600,
            this.th800,
            this.th1000});
            this.questionsField.Location = new System.Drawing.Point(23, 43);
            this.questionsField.Name = "questionsField";
            this.questionsField.Size = new System.Drawing.Size(680, 352);
            this.questionsField.TabIndex = 0;
            // 
            // Theme
            // 
            this.Theme.HeaderText = "Темы";
            this.Theme.Name = "Theme";
            this.Theme.ReadOnly = true;
            this.Theme.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // th200
            // 
            this.th200.HeaderText = "Очень легко";
            this.th200.Name = "th200";
            this.th200.Text = "200";
            // 
            // th400
            // 
            this.th400.HeaderText = "Легко";
            this.th400.Name = "th400";
            this.th400.Text = "400";
            // 
            // th600
            // 
            this.th600.HeaderText = "Нормально";
            this.th600.Name = "th600";
            this.th600.Text = "600";
            // 
            // th800
            // 
            this.th800.HeaderText = "По-тяжелее";
            this.th800.Name = "th800";
            this.th800.Text = "800";
            // 
            // th1000
            // 
            this.th1000.HeaderText = "Сложно";
            this.th1000.Name = "th1000";
            this.th1000.Text = "1000";
            // 
            // playersView
            // 
            this.playersView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Имя,
            this.Счёт});
            this.playersView.HideSelection = false;
            this.playersView.Location = new System.Drawing.Point(718, 43);
            this.playersView.Name = "playersView";
            this.playersView.Size = new System.Drawing.Size(247, 352);
            this.playersView.TabIndex = 1;
            this.playersView.UseCompatibleStateImageBehavior = false;
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
            // GameSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 457);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Theme;
        private System.Windows.Forms.DataGridViewButtonColumn th200;
        private System.Windows.Forms.DataGridViewButtonColumn th400;
        private System.Windows.Forms.DataGridViewButtonColumn th600;
        private System.Windows.Forms.DataGridViewButtonColumn th800;
        private System.Windows.Forms.DataGridViewButtonColumn th1000;
        private System.Windows.Forms.ListView playersView;
        private System.Windows.Forms.ColumnHeader Имя;
        private System.Windows.Forms.ColumnHeader Счёт;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label questionlabel;
    }
}