namespace FNL.Forms
{
    partial class PersonForm
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
            this.buttonCancle = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonChangePerson = new System.Windows.Forms.Button();
            this.buttonDeletePerson = new System.Windows.Forms.Button();
            this.buttonInsertPerson = new System.Windows.Forms.Button();
            this.dataGridViewPerson = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancle);
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Controls.Add(this.buttonChangePerson);
            this.panel1.Controls.Add(this.buttonDeletePerson);
            this.panel1.Controls.Add(this.buttonInsertPerson);
            this.panel1.Controls.Add(this.dataGridViewPerson);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 450);
            this.panel1.TabIndex = 1;
            // 
            // buttonCancle
            // 
            this.buttonCancle.Location = new System.Drawing.Point(939, 6);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonCancle.TabIndex = 5;
            this.buttonCancle.Text = "Отмена";
            this.buttonCancle.UseVisualStyleBackColor = true;
            this.buttonCancle.Click += new System.EventHandler(this.buttonCancle_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(861, 6);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ок";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonChangePerson
            // 
            this.buttonChangePerson.Location = new System.Drawing.Point(87, 6);
            this.buttonChangePerson.Name = "buttonChangePerson";
            this.buttonChangePerson.Size = new System.Drawing.Size(75, 23);
            this.buttonChangePerson.TabIndex = 3;
            this.buttonChangePerson.Text = "Изменить";
            this.buttonChangePerson.UseVisualStyleBackColor = true;
            this.buttonChangePerson.Click += new System.EventHandler(this.buttonChangePerson_Click);
            // 
            // buttonDeletePerson
            // 
            this.buttonDeletePerson.Location = new System.Drawing.Point(168, 6);
            this.buttonDeletePerson.Name = "buttonDeletePerson";
            this.buttonDeletePerson.Size = new System.Drawing.Size(75, 23);
            this.buttonDeletePerson.TabIndex = 2;
            this.buttonDeletePerson.Text = "Удалить";
            this.buttonDeletePerson.UseVisualStyleBackColor = true;
            this.buttonDeletePerson.Click += new System.EventHandler(this.buttonDeletePerson_Click);
            // 
            // buttonInsertPerson
            // 
            this.buttonInsertPerson.Location = new System.Drawing.Point(6, 6);
            this.buttonInsertPerson.Name = "buttonInsertPerson";
            this.buttonInsertPerson.Size = new System.Drawing.Size(75, 23);
            this.buttonInsertPerson.TabIndex = 1;
            this.buttonInsertPerson.Text = "Добавить";
            this.buttonInsertPerson.UseVisualStyleBackColor = true;
            this.buttonInsertPerson.Click += new System.EventHandler(this.buttonInsertPerson_Click);
            // 
            // dataGridViewPerson
            // 
            this.dataGridViewPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPerson.Location = new System.Drawing.Point(3, 35);
            this.dataGridViewPerson.Name = "dataGridViewPerson";
            this.dataGridViewPerson.Size = new System.Drawing.Size(1011, 387);
            this.dataGridViewPerson.TabIndex = 0;
            // 
            // PersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 450);
            this.Controls.Add(this.panel1);
            this.Name = "PersonForm";
            this.Text = "PersonForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonChangePerson;
        private System.Windows.Forms.Button buttonDeletePerson;
        private System.Windows.Forms.Button buttonInsertPerson;
        private System.Windows.Forms.DataGridView dataGridViewPerson;
    }
}