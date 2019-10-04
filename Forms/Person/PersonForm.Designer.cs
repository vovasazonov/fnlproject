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
            this.buttonChangeMatch = new System.Windows.Forms.Button();
            this.buttonDeleteMatch = new System.Windows.Forms.Button();
            this.buttonInsertMatch = new System.Windows.Forms.Button();
            this.dataGridViewMatch = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatch)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancle);
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Controls.Add(this.buttonChangeMatch);
            this.panel1.Controls.Add(this.buttonDeleteMatch);
            this.panel1.Controls.Add(this.buttonInsertMatch);
            this.panel1.Controls.Add(this.dataGridViewMatch);
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
            // buttonChangeMatch
            // 
            this.buttonChangeMatch.Location = new System.Drawing.Point(87, 6);
            this.buttonChangeMatch.Name = "buttonChangeMatch";
            this.buttonChangeMatch.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeMatch.TabIndex = 3;
            this.buttonChangeMatch.Text = "Изменить";
            this.buttonChangeMatch.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteMatch
            // 
            this.buttonDeleteMatch.Location = new System.Drawing.Point(168, 6);
            this.buttonDeleteMatch.Name = "buttonDeleteMatch";
            this.buttonDeleteMatch.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteMatch.TabIndex = 2;
            this.buttonDeleteMatch.Text = "Удалить";
            this.buttonDeleteMatch.UseVisualStyleBackColor = true;
            // 
            // buttonInsertMatch
            // 
            this.buttonInsertMatch.Location = new System.Drawing.Point(6, 6);
            this.buttonInsertMatch.Name = "buttonInsertMatch";
            this.buttonInsertMatch.Size = new System.Drawing.Size(75, 23);
            this.buttonInsertMatch.TabIndex = 1;
            this.buttonInsertMatch.Text = "Добавить";
            this.buttonInsertMatch.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMatch
            // 
            this.dataGridViewMatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatch.Location = new System.Drawing.Point(3, 35);
            this.dataGridViewMatch.Name = "dataGridViewMatch";
            this.dataGridViewMatch.Size = new System.Drawing.Size(1011, 387);
            this.dataGridViewMatch.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonChangeMatch;
        private System.Windows.Forms.Button buttonDeleteMatch;
        private System.Windows.Forms.Button buttonInsertMatch;
        private System.Windows.Forms.DataGridView dataGridViewMatch;
    }
}