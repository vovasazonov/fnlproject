namespace FNL.Forms
{
    partial class SettingSeasonForm
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
            this.buttonSetSeasonCancle = new System.Windows.Forms.Button();
            this.buttonSetSeasonOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textNameSeason = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSetSeasonCancle);
            this.panel2.Controls.Add(this.buttonSetSeasonOk);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 32);
            this.panel2.TabIndex = 7;
            // 
            // buttonSetSeasonCancle
            // 
            this.buttonSetSeasonCancle.Location = new System.Drawing.Point(446, 3);
            this.buttonSetSeasonCancle.Name = "buttonSetSeasonCancle";
            this.buttonSetSeasonCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonSetSeasonCancle.TabIndex = 1;
            this.buttonSetSeasonCancle.Text = "Отмена";
            this.buttonSetSeasonCancle.UseVisualStyleBackColor = true;
            this.buttonSetSeasonCancle.Click += new System.EventHandler(this.buttonSetSeasonCancle_Click);
            // 
            // buttonSetSeasonOk
            // 
            this.buttonSetSeasonOk.Location = new System.Drawing.Point(365, 3);
            this.buttonSetSeasonOk.Name = "buttonSetSeasonOk";
            this.buttonSetSeasonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonSetSeasonOk.TabIndex = 0;
            this.buttonSetSeasonOk.Text = "Ок";
            this.buttonSetSeasonOk.UseVisualStyleBackColor = true;
            this.buttonSetSeasonOk.Click += new System.EventHandler(this.buttonSetSeasonOk_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textNameSeason);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(12, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 42);
            this.panel1.TabIndex = 6;
            // 
            // textNameSeason
            // 
            this.textNameSeason.Location = new System.Drawing.Point(116, 11);
            this.textNameSeason.Name = "textNameSeason";
            this.textNameSeason.Size = new System.Drawing.Size(405, 20);
            this.textNameSeason.TabIndex = 16;
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
            // SettingSeason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 104);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SettingSeason";
            this.Text = "SettingSeason";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonSetSeasonCancle;
        private System.Windows.Forms.Button buttonSetSeasonOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textNameSeason;
        private System.Windows.Forms.Label label8;
    }
}