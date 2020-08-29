namespace FNL.Forms
{
    partial class MatchPlayersForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridGuestPlayers = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textNameGuest = new System.Windows.Forms.TextBox();
            this.buttonAddPlayerGuest = new System.Windows.Forms.Button();
            this.buttonDeletePlayerGuest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridHomePlayers = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textNameHome = new System.Windows.Forms.TextBox();
            this.buttonAddPlayerHome = new System.Windows.Forms.Button();
            this.buttonDeletePlayerHome = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxNameMatch = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGuestPlayers)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHomePlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxNameMatch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 495);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridGuestPlayers);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textNameGuest);
            this.groupBox2.Controls.Add(this.buttonAddPlayerGuest);
            this.groupBox2.Controls.Add(this.buttonDeletePlayerGuest);
            this.groupBox2.Location = new System.Drawing.Point(3, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(718, 201);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Гостевая команда";
            // 
            // dataGridGuestPlayers
            // 
            this.dataGridGuestPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGuestPlayers.Location = new System.Drawing.Point(7, 49);
            this.dataGridGuestPlayers.Name = "dataGridGuestPlayers";
            this.dataGridGuestPlayers.Size = new System.Drawing.Size(705, 150);
            this.dataGridGuestPlayers.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Команда";
            this.label3.Visible = false;
            // 
            // textNameGuest
            // 
            this.textNameGuest.Location = new System.Drawing.Point(561, 19);
            this.textNameGuest.Name = "textNameGuest";
            this.textNameGuest.ReadOnly = true;
            this.textNameGuest.Size = new System.Drawing.Size(151, 20);
            this.textNameGuest.TabIndex = 7;
            this.textNameGuest.Visible = false;
            // 
            // buttonAddPlayerGuest
            // 
            this.buttonAddPlayerGuest.Location = new System.Drawing.Point(6, 19);
            this.buttonAddPlayerGuest.Name = "buttonAddPlayerGuest";
            this.buttonAddPlayerGuest.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPlayerGuest.TabIndex = 4;
            this.buttonAddPlayerGuest.Text = "Добавить";
            this.buttonAddPlayerGuest.UseVisualStyleBackColor = true;
            this.buttonAddPlayerGuest.Click += new System.EventHandler(this.buttonAddPlayerGuest_Click);
            // 
            // buttonDeletePlayerGuest
            // 
            this.buttonDeletePlayerGuest.Location = new System.Drawing.Point(87, 19);
            this.buttonDeletePlayerGuest.Name = "buttonDeletePlayerGuest";
            this.buttonDeletePlayerGuest.Size = new System.Drawing.Size(75, 23);
            this.buttonDeletePlayerGuest.TabIndex = 5;
            this.buttonDeletePlayerGuest.Text = "Удалить";
            this.buttonDeletePlayerGuest.UseVisualStyleBackColor = true;
            this.buttonDeletePlayerGuest.Click += new System.EventHandler(this.buttonDeletePlayerGuest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridHomePlayers);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textNameHome);
            this.groupBox1.Controls.Add(this.buttonAddPlayerHome);
            this.groupBox1.Controls.Add(this.buttonDeletePlayerHome);
            this.groupBox1.Location = new System.Drawing.Point(3, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 201);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Домашняя команда";
            // 
            // dataGridHomePlayers
            // 
            this.dataGridHomePlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHomePlayers.Location = new System.Drawing.Point(7, 49);
            this.dataGridHomePlayers.Name = "dataGridHomePlayers";
            this.dataGridHomePlayers.Size = new System.Drawing.Size(705, 150);
            this.dataGridHomePlayers.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Команда";
            this.label2.Visible = false;
            // 
            // textNameHome
            // 
            this.textNameHome.Location = new System.Drawing.Point(561, 19);
            this.textNameHome.Name = "textNameHome";
            this.textNameHome.ReadOnly = true;
            this.textNameHome.Size = new System.Drawing.Size(151, 20);
            this.textNameHome.TabIndex = 7;
            this.textNameHome.Visible = false;
            // 
            // buttonAddPlayerHome
            // 
            this.buttonAddPlayerHome.Location = new System.Drawing.Point(6, 19);
            this.buttonAddPlayerHome.Name = "buttonAddPlayerHome";
            this.buttonAddPlayerHome.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPlayerHome.TabIndex = 4;
            this.buttonAddPlayerHome.Text = "Добавить";
            this.buttonAddPlayerHome.UseVisualStyleBackColor = true;
            this.buttonAddPlayerHome.Click += new System.EventHandler(this.buttonAddPlayerHome_Click);
            // 
            // buttonDeletePlayerHome
            // 
            this.buttonDeletePlayerHome.Location = new System.Drawing.Point(87, 20);
            this.buttonDeletePlayerHome.Name = "buttonDeletePlayerHome";
            this.buttonDeletePlayerHome.Size = new System.Drawing.Size(75, 23);
            this.buttonDeletePlayerHome.TabIndex = 5;
            this.buttonDeletePlayerHome.Text = "Удалить";
            this.buttonDeletePlayerHome.UseVisualStyleBackColor = true;
            this.buttonDeletePlayerHome.Click += new System.EventHandler(this.buttonDeletePlayerHome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Матч";
            this.label1.Visible = false;
            // 
            // comboBoxNameMatch
            // 
            this.comboBoxNameMatch.FormattingEnabled = true;
            this.comboBoxNameMatch.Location = new System.Drawing.Point(41, 3);
            this.comboBoxNameMatch.Name = "comboBoxNameMatch";
            this.comboBoxNameMatch.Size = new System.Drawing.Size(390, 21);
            this.comboBoxNameMatch.TabIndex = 0;
            this.comboBoxNameMatch.Visible = false;
            // 
            // MatchPlayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 495);
            this.Controls.Add(this.panel1);
            this.Name = "MatchPlayersForm";
            this.Text = "MatchPlayers";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGuestPlayers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHomePlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxNameMatch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridGuestPlayers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNameGuest;
        private System.Windows.Forms.Button buttonAddPlayerGuest;
        private System.Windows.Forms.Button buttonDeletePlayerGuest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridHomePlayers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNameHome;
        private System.Windows.Forms.Button buttonAddPlayerHome;
        private System.Windows.Forms.Button buttonDeletePlayerHome;
    }
}