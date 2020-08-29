namespace FNL.Forms
{
    partial class InsertMatchPlayersForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridPlayers = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPairs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNotPairs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTrainers = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonIsPair = new System.Windows.Forms.RadioButton();
            this.radioButtonNotPair = new System.Windows.Forms.RadioButton();
            this.buttonAddPlayerTeam = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayers)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.buttonAddPlayerTeam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 422);
            this.panel1.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridPlayers);
            this.groupBox4.Location = new System.Drawing.Point(3, 82);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(656, 336);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // dataGridPlayers
            // 
            this.dataGridPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPlayers.Location = new System.Drawing.Point(3, 16);
            this.dataGridPlayers.Name = "dataGridPlayers";
            this.dataGridPlayers.Size = new System.Drawing.Size(650, 317);
            this.dataGridPlayers.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxPairs);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxNotPairs);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxTrainers);
            this.groupBox2.Location = new System.Drawing.Point(213, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 64);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выбрано";
            this.groupBox2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Игроков запасного состава";
            // 
            // textBoxPairs
            // 
            this.textBoxPairs.Location = new System.Drawing.Point(162, 40);
            this.textBoxPairs.Name = "textBoxPairs";
            this.textBoxPairs.ReadOnly = true;
            this.textBoxPairs.Size = new System.Drawing.Size(37, 20);
            this.textBoxPairs.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Игроков основного состава";
            // 
            // textBoxNotPairs
            // 
            this.textBoxNotPairs.Location = new System.Drawing.Point(162, 16);
            this.textBoxNotPairs.Name = "textBoxNotPairs";
            this.textBoxNotPairs.ReadOnly = true;
            this.textBoxNotPairs.Size = new System.Drawing.Size(37, 20);
            this.textBoxNotPairs.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Тренеров";
            // 
            // textBoxTrainers
            // 
            this.textBoxTrainers.Location = new System.Drawing.Point(265, 17);
            this.textBoxTrainers.Name = "textBoxTrainers";
            this.textBoxTrainers.ReadOnly = true;
            this.textBoxTrainers.Size = new System.Drawing.Size(37, 20);
            this.textBoxTrainers.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonIsPair);
            this.groupBox1.Controls.Add(this.radioButtonNotPair);
            this.groupBox1.Location = new System.Drawing.Point(3, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 44);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Статус";
            // 
            // radioButtonIsPair
            // 
            this.radioButtonIsPair.AutoSize = true;
            this.radioButtonIsPair.Location = new System.Drawing.Point(125, 19);
            this.radioButtonIsPair.Name = "radioButtonIsPair";
            this.radioButtonIsPair.Size = new System.Drawing.Size(74, 17);
            this.radioButtonIsPair.TabIndex = 1;
            this.radioButtonIsPair.Text = "Запасной";
            this.radioButtonIsPair.UseVisualStyleBackColor = true;
            // 
            // radioButtonNotPair
            // 
            this.radioButtonNotPair.AutoSize = true;
            this.radioButtonNotPair.Checked = true;
            this.radioButtonNotPair.Location = new System.Drawing.Point(6, 19);
            this.radioButtonNotPair.Name = "radioButtonNotPair";
            this.radioButtonNotPair.Size = new System.Drawing.Size(113, 17);
            this.radioButtonNotPair.TabIndex = 0;
            this.radioButtonNotPair.TabStop = true;
            this.radioButtonNotPair.Text = "Основной состав";
            this.radioButtonNotPair.UseVisualStyleBackColor = true;
            // 
            // buttonAddPlayerTeam
            // 
            this.buttonAddPlayerTeam.Location = new System.Drawing.Point(3, 3);
            this.buttonAddPlayerTeam.Name = "buttonAddPlayerTeam";
            this.buttonAddPlayerTeam.Size = new System.Drawing.Size(162, 23);
            this.buttonAddPlayerTeam.TabIndex = 0;
            this.buttonAddPlayerTeam.Text = "Добавить игрока в команду";
            this.buttonAddPlayerTeam.UseVisualStyleBackColor = true;
            this.buttonAddPlayerTeam.Click += new System.EventHandler(this.buttonAddPlayerTeam_Click);
            // 
            // InsertMatchPlayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 422);
            this.Controls.Add(this.panel1);
            this.Name = "InsertMatchPlayersForm";
            this.Text = "InsertMatchPlayers";
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPlayers)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridPlayers;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPairs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNotPairs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTrainers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonIsPair;
        private System.Windows.Forms.RadioButton radioButtonNotPair;
        private System.Windows.Forms.Button buttonAddPlayerTeam;
    }
}