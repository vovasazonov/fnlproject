namespace FNL.Forms
{
    partial class SettingPersonForm
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
            this.buttonChoseFotoPerson = new System.Windows.Forms.Button();
            this.textPathFotoPerson = new System.Windows.Forms.TextBox();
            this.textCityPerson = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textCountryPerson = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.textMiddleNamePerson = new System.Windows.Forms.TextBox();
            this.textFirstNamePerson = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textLastNamePerson = new System.Windows.Forms.TextBox();
            this.buttonCanclePerson = new System.Windows.Forms.Button();
            this.buttonOkPerson = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.buttonCanclePerson);
            this.panel1.Controls.Add(this.buttonOkPerson);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 250);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonChoseFotoPerson);
            this.groupBox2.Controls.Add(this.textPathFotoPerson);
            this.groupBox2.Controls.Add(this.textCityPerson);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textCountryPerson);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboBoxRole);
            this.groupBox2.Controls.Add(this.textMiddleNamePerson);
            this.groupBox2.Controls.Add(this.textFirstNamePerson);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textLastNamePerson);
            this.groupBox2.Location = new System.Drawing.Point(5, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 214);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // buttonChoseFotoPerson
            // 
            this.buttonChoseFotoPerson.Location = new System.Drawing.Point(11, 183);
            this.buttonChoseFotoPerson.Name = "buttonChoseFotoPerson";
            this.buttonChoseFotoPerson.Size = new System.Drawing.Size(97, 23);
            this.buttonChoseFotoPerson.TabIndex = 21;
            this.buttonChoseFotoPerson.Text = "1 фото большое ...";
            this.buttonChoseFotoPerson.UseVisualStyleBackColor = true;
            this.buttonChoseFotoPerson.Visible = false;
            // 
            // textPathFotoPerson
            // 
            this.textPathFotoPerson.Location = new System.Drawing.Point(114, 185);
            this.textPathFotoPerson.Name = "textPathFotoPerson";
            this.textPathFotoPerson.Size = new System.Drawing.Size(210, 20);
            this.textPathFotoPerson.TabIndex = 20;
            this.textPathFotoPerson.Visible = false;
            // 
            // textCityPerson
            // 
            this.textCityPerson.Location = new System.Drawing.Point(68, 147);
            this.textCityPerson.Name = "textCityPerson";
            this.textCityPerson.Size = new System.Drawing.Size(256, 20);
            this.textCityPerson.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Город";
            // 
            // textCountryPerson
            // 
            this.textCountryPerson.Location = new System.Drawing.Point(68, 122);
            this.textCountryPerson.Name = "textCountryPerson";
            this.textCountryPerson.Size = new System.Drawing.Size(256, 20);
            this.textCountryPerson.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Страна";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Роль";
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(68, 95);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(256, 21);
            this.comboBoxRole.TabIndex = 6;
            this.comboBoxRole.SelectedIndexChanged += new System.EventHandler(this.comboBoxRole_SelectedIndexChanged);
            // 
            // textMiddleNamePerson
            // 
            this.textMiddleNamePerson.Location = new System.Drawing.Point(68, 69);
            this.textMiddleNamePerson.Name = "textMiddleNamePerson";
            this.textMiddleNamePerson.Size = new System.Drawing.Size(256, 20);
            this.textMiddleNamePerson.TabIndex = 5;
            // 
            // textFirstNamePerson
            // 
            this.textFirstNamePerson.Location = new System.Drawing.Point(68, 43);
            this.textFirstNamePerson.Name = "textFirstNamePerson";
            this.textFirstNamePerson.Size = new System.Drawing.Size(256, 20);
            this.textFirstNamePerson.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Отчество";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Имя";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Фамилия";
            // 
            // textLastNamePerson
            // 
            this.textLastNamePerson.Location = new System.Drawing.Point(68, 16);
            this.textLastNamePerson.Name = "textLastNamePerson";
            this.textLastNamePerson.Size = new System.Drawing.Size(256, 20);
            this.textLastNamePerson.TabIndex = 1;
            // 
            // buttonCanclePerson
            // 
            this.buttonCanclePerson.Location = new System.Drawing.Point(261, 3);
            this.buttonCanclePerson.Name = "buttonCanclePerson";
            this.buttonCanclePerson.Size = new System.Drawing.Size(75, 23);
            this.buttonCanclePerson.TabIndex = 3;
            this.buttonCanclePerson.Text = "Отмена";
            this.buttonCanclePerson.UseVisualStyleBackColor = true;
            this.buttonCanclePerson.Click += new System.EventHandler(this.buttonCanclePerson_Click);
            // 
            // buttonOkPerson
            // 
            this.buttonOkPerson.Location = new System.Drawing.Point(180, 3);
            this.buttonOkPerson.Name = "buttonOkPerson";
            this.buttonOkPerson.Size = new System.Drawing.Size(75, 23);
            this.buttonOkPerson.TabIndex = 2;
            this.buttonOkPerson.Text = "Ok";
            this.buttonOkPerson.UseVisualStyleBackColor = true;
            this.buttonOkPerson.Click += new System.EventHandler(this.buttonOkPerson_Click);
            // 
            // SettingPersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 250);
            this.Controls.Add(this.panel1);
            this.Name = "SettingPersonForm";
            this.Text = "SettingPerson";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCanclePerson;
        private System.Windows.Forms.Button buttonOkPerson;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textCityPerson;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textCountryPerson;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.TextBox textMiddleNamePerson;
        private System.Windows.Forms.TextBox textFirstNamePerson;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textLastNamePerson;
        private System.Windows.Forms.Button buttonChoseFotoPerson;
        private System.Windows.Forms.TextBox textPathFotoPerson;
    }
}