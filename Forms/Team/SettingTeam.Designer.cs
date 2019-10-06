namespace FNL.Forms
{
    partial class SettingTeam
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSetTeamCancle = new System.Windows.Forms.Button();
            this.buttonSetTeamOk = new System.Windows.Forms.Button();
            this.textNameFullTeam = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxPathLogo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textNameShortTeam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewPlayersTeam = new System.Windows.Forms.DataGridView();
            this.buttonAddPlayer = new System.Windows.Forms.Button();
            this.buttonDeletePlayer = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayersTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSetTeamCancle);
            this.panel2.Controls.Add(this.buttonSetTeamOk);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 32);
            this.panel2.TabIndex = 5;
            // 
            // buttonSetTeamCancle
            // 
            this.buttonSetTeamCancle.Location = new System.Drawing.Point(446, 3);
            this.buttonSetTeamCancle.Name = "buttonSetTeamCancle";
            this.buttonSetTeamCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonSetTeamCancle.TabIndex = 1;
            this.buttonSetTeamCancle.Text = "Отмена";
            this.buttonSetTeamCancle.UseVisualStyleBackColor = true;
            // 
            // buttonSetTeamOk
            // 
            this.buttonSetTeamOk.Location = new System.Drawing.Point(365, 3);
            this.buttonSetTeamOk.Name = "buttonSetTeamOk";
            this.buttonSetTeamOk.Size = new System.Drawing.Size(75, 23);
            this.buttonSetTeamOk.TabIndex = 0;
            this.buttonSetTeamOk.Text = "Ок";
            this.buttonSetTeamOk.UseVisualStyleBackColor = true;
            this.buttonSetTeamOk.Click += new System.EventHandler(this.buttonSetTeamOk_Click);
            // 
            // textNameFullTeam
            // 
            this.textNameFullTeam.Location = new System.Drawing.Point(116, 11);
            this.textNameFullTeam.Name = "textNameFullTeam";
            this.textNameFullTeam.Size = new System.Drawing.Size(145, 20);
            this.textNameFullTeam.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Полное название";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxPathLogo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textNameShortTeam);
            this.panel1.Controls.Add(this.textNameFullTeam);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 101);
            this.panel1.TabIndex = 4;
            // 
            // comboBoxPathLogo
            // 
            this.comboBoxPathLogo.FormattingEnabled = true;
            this.comboBoxPathLogo.Location = new System.Drawing.Point(116, 69);
            this.comboBoxPathLogo.Name = "comboBoxPathLogo";
            this.comboBoxPathLogo.Size = new System.Drawing.Size(389, 21);
            this.comboBoxPathLogo.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Путь к логотипу";
            // 
            // textNameShortTeam
            // 
            this.textNameShortTeam.Location = new System.Drawing.Point(116, 41);
            this.textNameShortTeam.Name = "textNameShortTeam";
            this.textNameShortTeam.Size = new System.Drawing.Size(145, 20);
            this.textNameShortTeam.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Короткое название";
            // 
            // dataGridViewPlayersTeam
            // 
            this.dataGridViewPlayersTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlayersTeam.Location = new System.Drawing.Point(12, 186);
            this.dataGridViewPlayersTeam.Name = "dataGridViewPlayersTeam";
            this.dataGridViewPlayersTeam.Size = new System.Drawing.Size(524, 204);
            this.dataGridViewPlayersTeam.TabIndex = 7;
            // 
            // buttonAddPlayer
            // 
            this.buttonAddPlayer.Location = new System.Drawing.Point(12, 157);
            this.buttonAddPlayer.Name = "buttonAddPlayer";
            this.buttonAddPlayer.Size = new System.Drawing.Size(110, 23);
            this.buttonAddPlayer.TabIndex = 8;
            this.buttonAddPlayer.Text = "Добавить игрока";
            this.buttonAddPlayer.UseVisualStyleBackColor = true;
            // 
            // buttonDeletePlayer
            // 
            this.buttonDeletePlayer.Location = new System.Drawing.Point(128, 157);
            this.buttonDeletePlayer.Name = "buttonDeletePlayer";
            this.buttonDeletePlayer.Size = new System.Drawing.Size(110, 23);
            this.buttonDeletePlayer.TabIndex = 9;
            this.buttonDeletePlayer.Text = "Удалить игрока";
            this.buttonDeletePlayer.UseVisualStyleBackColor = true;
            // 
            // SettingTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 402);
            this.Controls.Add(this.buttonDeletePlayer);
            this.Controls.Add(this.buttonAddPlayer);
            this.Controls.Add(this.dataGridViewPlayersTeam);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SettingTeam";
            this.Text = "SettingTeam";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayersTeam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonSetTeamCancle;
        private System.Windows.Forms.Button buttonSetTeamOk;
        private System.Windows.Forms.TextBox textNameFullTeam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textNameShortTeam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPathLogo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewPlayersTeam;
        private System.Windows.Forms.Button buttonAddPlayer;
        private System.Windows.Forms.Button buttonDeletePlayer;
    }
}