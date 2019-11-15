namespace FNL.Forms
{
    partial class StadiumForm
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
            this.buttonChangeStadium = new System.Windows.Forms.Button();
            this.buttonDeleteStadium = new System.Windows.Forms.Button();
            this.buttonInsertStadium = new System.Windows.Forms.Button();
            this.dataGridViewStadium = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStadium)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancle);
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Controls.Add(this.buttonChangeStadium);
            this.panel1.Controls.Add(this.buttonDeleteStadium);
            this.panel1.Controls.Add(this.buttonInsertStadium);
            this.panel1.Controls.Add(this.dataGridViewStadium);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 434);
            this.panel1.TabIndex = 1;
            // 
            // buttonCancle
            // 
            this.buttonCancle.Location = new System.Drawing.Point(540, 6);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonCancle.TabIndex = 5;
            this.buttonCancle.Text = "Отмена";
            this.buttonCancle.UseVisualStyleBackColor = true;
            this.buttonCancle.Click += new System.EventHandler(this.buttonCancle_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(459, 6);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ок";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonChangeStadium
            // 
            this.buttonChangeStadium.Location = new System.Drawing.Point(87, 6);
            this.buttonChangeStadium.Name = "buttonChangeStadium";
            this.buttonChangeStadium.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeStadium.TabIndex = 3;
            this.buttonChangeStadium.Text = "Изменить";
            this.buttonChangeStadium.UseVisualStyleBackColor = true;
            this.buttonChangeStadium.Click += new System.EventHandler(this.buttonChangeStadium_Click);
            // 
            // buttonDeleteStadium
            // 
            this.buttonDeleteStadium.Location = new System.Drawing.Point(168, 6);
            this.buttonDeleteStadium.Name = "buttonDeleteStadium";
            this.buttonDeleteStadium.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteStadium.TabIndex = 2;
            this.buttonDeleteStadium.Text = "Удалить";
            this.buttonDeleteStadium.UseVisualStyleBackColor = true;
            this.buttonDeleteStadium.Click += new System.EventHandler(this.buttonDeleteStadium_Click);
            // 
            // buttonInsertStadium
            // 
            this.buttonInsertStadium.Location = new System.Drawing.Point(6, 6);
            this.buttonInsertStadium.Name = "buttonInsertStadium";
            this.buttonInsertStadium.Size = new System.Drawing.Size(75, 23);
            this.buttonInsertStadium.TabIndex = 1;
            this.buttonInsertStadium.Text = "Добавить";
            this.buttonInsertStadium.UseVisualStyleBackColor = true;
            this.buttonInsertStadium.Click += new System.EventHandler(this.buttonInsertStadium_Click);
            // 
            // dataGridViewStadium
            // 
            this.dataGridViewStadium.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStadium.Location = new System.Drawing.Point(6, 35);
            this.dataGridViewStadium.Name = "dataGridViewStadium";
            this.dataGridViewStadium.Size = new System.Drawing.Size(609, 387);
            this.dataGridViewStadium.TabIndex = 0;
            // 
            // StadiumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 434);
            this.Controls.Add(this.panel1);
            this.Name = "StadiumForm";
            this.Text = "StadiumForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStadium)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonChangeStadium;
        private System.Windows.Forms.Button buttonDeleteStadium;
        private System.Windows.Forms.Button buttonInsertStadium;
        private System.Windows.Forms.DataGridView dataGridViewStadium;
    }
}