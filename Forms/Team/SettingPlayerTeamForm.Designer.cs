namespace FNL.Forms
{
    partial class SettingPlayerTeamForm
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
            this.buttonChangePerson = new System.Windows.Forms.Button();
            this.buttonDeletePerson = new System.Windows.Forms.Button();
            this.buttonAddPerson = new System.Windows.Forms.Button();
            this.dataGridViewAllPlayers = new System.Windows.Forms.DataGridView();
            this.buttonCancle = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.number = new System.Windows.Forms.NumericUpDown();
            this.comboBoxAmplua = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTeam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.number)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.buttonCancle);
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Controls.Add(this.number);
            this.panel1.Controls.Add(this.comboBoxAmplua);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxTeam);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 433);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonChangePerson);
            this.groupBox2.Controls.Add(this.buttonDeletePerson);
            this.groupBox2.Controls.Add(this.buttonAddPerson);
            this.groupBox2.Controls.Add(this.dataGridViewAllPlayers);
            this.groupBox2.Location = new System.Drawing.Point(8, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(898, 380);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // buttonChangePerson
            // 
            this.buttonChangePerson.Location = new System.Drawing.Point(136, 19);
            this.buttonChangePerson.Name = "buttonChangePerson";
            this.buttonChangePerson.Size = new System.Drawing.Size(120, 23);
            this.buttonChangePerson.TabIndex = 28;
            this.buttonChangePerson.Text = "Изменить человека";
            this.buttonChangePerson.UseVisualStyleBackColor = true;
            this.buttonChangePerson.Click += new System.EventHandler(this.buttonChangePerson_Click);
            // 
            // buttonDeletePerson
            // 
            this.buttonDeletePerson.Location = new System.Drawing.Point(262, 19);
            this.buttonDeletePerson.Name = "buttonDeletePerson";
            this.buttonDeletePerson.Size = new System.Drawing.Size(110, 23);
            this.buttonDeletePerson.TabIndex = 27;
            this.buttonDeletePerson.Text = "Удалить человека";
            this.buttonDeletePerson.UseVisualStyleBackColor = true;
            this.buttonDeletePerson.Click += new System.EventHandler(this.buttonDeletePerson_Click);
            // 
            // buttonAddPerson
            // 
            this.buttonAddPerson.Location = new System.Drawing.Point(6, 19);
            this.buttonAddPerson.Name = "buttonAddPerson";
            this.buttonAddPerson.Size = new System.Drawing.Size(124, 23);
            this.buttonAddPerson.TabIndex = 26;
            this.buttonAddPerson.Text = "Добавить человека";
            this.buttonAddPerson.UseVisualStyleBackColor = true;
            this.buttonAddPerson.Click += new System.EventHandler(this.buttonAddPerson_Click);
            // 
            // dataGridViewAllPlayers
            // 
            this.dataGridViewAllPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllPlayers.Location = new System.Drawing.Point(6, 50);
            this.dataGridViewAllPlayers.Name = "dataGridViewAllPlayers";
            this.dataGridViewAllPlayers.Size = new System.Drawing.Size(886, 324);
            this.dataGridViewAllPlayers.TabIndex = 24;
            // 
            // buttonCancle
            // 
            this.buttonCancle.Location = new System.Drawing.Point(825, 12);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonCancle.TabIndex = 25;
            this.buttonCancle.Text = "Отмена";
            this.buttonCancle.UseVisualStyleBackColor = true;
            this.buttonCancle.Click += new System.EventHandler(this.buttonCancle_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(744, 12);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 24;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // number
            // 
            this.number.Location = new System.Drawing.Point(62, 13);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(40, 20);
            this.number.TabIndex = 25;
            // 
            // comboBoxAmplua
            // 
            this.comboBoxAmplua.FormattingEnabled = true;
            this.comboBoxAmplua.Location = new System.Drawing.Point(306, 12);
            this.comboBoxAmplua.Name = "comboBoxAmplua";
            this.comboBoxAmplua.Size = new System.Drawing.Size(120, 21);
            this.comboBoxAmplua.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Амплуа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Номер";
            // 
            // comboBoxTeam
            // 
            this.comboBoxTeam.FormattingEnabled = true;
            this.comboBoxTeam.Location = new System.Drawing.Point(166, 12);
            this.comboBoxTeam.Name = "comboBoxTeam";
            this.comboBoxTeam.Size = new System.Drawing.Size(83, 21);
            this.comboBoxTeam.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Команда";
            // 
            // SettingPlayerTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 433);
            this.Controls.Add(this.panel1);
            this.Name = "SettingPlayerTeam";
            this.Text = "SettingPlayerTeam";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.number)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxAmplua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTeam;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.DataGridView dataGridViewAllPlayers;
        private System.Windows.Forms.NumericUpDown number;
        private System.Windows.Forms.Button buttonChangePerson;
        private System.Windows.Forms.Button buttonDeletePerson;
        private System.Windows.Forms.Button buttonAddPerson;
    }
}