namespace FNL.Forms
{
    partial class TeamForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonTeamCancle = new System.Windows.Forms.Button();
            this.buttonTeamOk = new System.Windows.Forms.Button();
            this.dataGridViewTeams = new System.Windows.Forms.DataGridView();
            this.buttonChangeTeam = new System.Windows.Forms.Button();
            this.buttonDeleteTeam = new System.Windows.Forms.Button();
            this.btnInsertTeam = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.buttonTeamCancle);
            this.panel1.Controls.Add(this.buttonTeamOk);
            this.panel1.Controls.Add(this.dataGridViewTeams);
            this.panel1.Controls.Add(this.buttonChangeTeam);
            this.panel1.Controls.Add(this.buttonDeleteTeam);
            this.panel1.Controls.Add(this.btnInsertTeam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 315);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxLogo);
            this.groupBox1.Location = new System.Drawing.Point(642, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 191);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Логотип";
            // 
            // buttonTeamCancle
            // 
            this.buttonTeamCancle.Location = new System.Drawing.Point(561, 6);
            this.buttonTeamCancle.Name = "buttonTeamCancle";
            this.buttonTeamCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonTeamCancle.TabIndex = 8;
            this.buttonTeamCancle.Text = "Отмена";
            this.buttonTeamCancle.UseVisualStyleBackColor = true;
            this.buttonTeamCancle.Click += new System.EventHandler(this.buttonTeamCancle_Click);
            // 
            // buttonTeamOk
            // 
            this.buttonTeamOk.Location = new System.Drawing.Point(480, 6);
            this.buttonTeamOk.Name = "buttonTeamOk";
            this.buttonTeamOk.Size = new System.Drawing.Size(75, 23);
            this.buttonTeamOk.TabIndex = 7;
            this.buttonTeamOk.Text = "Ок";
            this.buttonTeamOk.UseVisualStyleBackColor = true;
            this.buttonTeamOk.Click += new System.EventHandler(this.buttonTeamOk_Click);
            // 
            // dataGridViewTeams
            // 
            this.dataGridViewTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTeams.Location = new System.Drawing.Point(6, 35);
            this.dataGridViewTeams.Name = "dataGridViewTeams";
            this.dataGridViewTeams.Size = new System.Drawing.Size(630, 268);
            this.dataGridViewTeams.TabIndex = 6;
            this.dataGridViewTeams.CurrentCellChanged += new System.EventHandler(this.dataGridViewTeams_CurrentCellChanged);
            // 
            // buttonChangeTeam
            // 
            this.buttonChangeTeam.Location = new System.Drawing.Point(87, 6);
            this.buttonChangeTeam.Name = "buttonChangeTeam";
            this.buttonChangeTeam.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeTeam.TabIndex = 3;
            this.buttonChangeTeam.Text = "Изменить";
            this.buttonChangeTeam.UseVisualStyleBackColor = true;
            this.buttonChangeTeam.Click += new System.EventHandler(this.buttonChangeTeam_Click);
            // 
            // buttonDeleteTeam
            // 
            this.buttonDeleteTeam.Location = new System.Drawing.Point(168, 6);
            this.buttonDeleteTeam.Name = "buttonDeleteTeam";
            this.buttonDeleteTeam.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteTeam.TabIndex = 2;
            this.buttonDeleteTeam.Text = "Удалить";
            this.buttonDeleteTeam.UseVisualStyleBackColor = true;
            this.buttonDeleteTeam.Click += new System.EventHandler(this.buttonDeleteTeam_Click);
            // 
            // btnInsertTeam
            // 
            this.btnInsertTeam.Location = new System.Drawing.Point(6, 6);
            this.btnInsertTeam.Name = "btnInsertTeam";
            this.btnInsertTeam.Size = new System.Drawing.Size(75, 23);
            this.btnInsertTeam.TabIndex = 1;
            this.btnInsertTeam.Text = "Добавить";
            this.btnInsertTeam.UseVisualStyleBackColor = true;
            this.btnInsertTeam.Click += new System.EventHandler(this.btnInsertTeam_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(149, 166);
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // TeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 315);
            this.Controls.Add(this.panel1);
            this.Name = "TeamForm";
            this.Text = "TeamsForm";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewTeams;
        private System.Windows.Forms.Button buttonChangeTeam;
        private System.Windows.Forms.Button buttonDeleteTeam;
        private System.Windows.Forms.Button btnInsertTeam;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonTeamCancle;
        private System.Windows.Forms.Button buttonTeamOk;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}