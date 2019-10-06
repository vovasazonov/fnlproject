namespace FNL.Forms
{
    partial class TeamsForm
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
            this.buttonCancle = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonChangeTeam = new System.Windows.Forms.Button();
            this.buttonDeleteTeam = new System.Windows.Forms.Button();
            this.buttonInsertTeam = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeams)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.buttonTeamCancle);
            this.panel1.Controls.Add(this.buttonTeamOk);
            this.panel1.Controls.Add(this.dataGridViewTeams);
            this.panel1.Controls.Add(this.buttonCancle);
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Controls.Add(this.buttonChangeTeam);
            this.panel1.Controls.Add(this.buttonDeleteTeam);
            this.panel1.Controls.Add(this.buttonInsertTeam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 293);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 55);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Логотип";
            // 
            // buttonTeamCancle
            // 
            this.buttonTeamCancle.Location = new System.Drawing.Point(674, 6);
            this.buttonTeamCancle.Name = "buttonTeamCancle";
            this.buttonTeamCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonTeamCancle.TabIndex = 8;
            this.buttonTeamCancle.Text = "Отмена";
            this.buttonTeamCancle.UseVisualStyleBackColor = true;
            this.buttonTeamCancle.Click += new System.EventHandler(this.buttonTeamCancle_Click);
            // 
            // buttonTeamOk
            // 
            this.buttonTeamOk.Location = new System.Drawing.Point(596, 6);
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
            this.dataGridViewTeams.Size = new System.Drawing.Size(743, 191);
            this.dataGridViewTeams.TabIndex = 6;
            // 
            // buttonCancle
            // 
            this.buttonCancle.Location = new System.Drawing.Point(939, 6);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonCancle.TabIndex = 5;
            this.buttonCancle.Text = "Отмена";
            this.buttonCancle.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(861, 6);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ок";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonChangeTeam
            // 
            this.buttonChangeTeam.Enabled = false;
            this.buttonChangeTeam.Location = new System.Drawing.Point(87, 6);
            this.buttonChangeTeam.Name = "buttonChangeTeam";
            this.buttonChangeTeam.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeTeam.TabIndex = 3;
            this.buttonChangeTeam.Text = "Изменить";
            this.buttonChangeTeam.UseVisualStyleBackColor = true;
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
            // buttonInsertTeam
            // 
            this.buttonInsertTeam.Location = new System.Drawing.Point(6, 6);
            this.buttonInsertTeam.Name = "buttonInsertTeam";
            this.buttonInsertTeam.Size = new System.Drawing.Size(75, 23);
            this.buttonInsertTeam.TabIndex = 1;
            this.buttonInsertTeam.Text = "Добавить";
            this.buttonInsertTeam.UseVisualStyleBackColor = true;
            this.buttonInsertTeam.Click += new System.EventHandler(this.buttonInsertTeam_Click);
            // 
            // TeamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 293);
            this.Controls.Add(this.panel1);
            this.Name = "TeamsForm";
            this.Text = "TeamsForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewTeams;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonChangeTeam;
        private System.Windows.Forms.Button buttonDeleteTeam;
        private System.Windows.Forms.Button buttonInsertTeam;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonTeamCancle;
        private System.Windows.Forms.Button buttonTeamOk;
    }
}