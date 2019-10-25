namespace FNL.Forms
{
    partial class SeasonForm
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
            this.buttonSeasonCancle = new System.Windows.Forms.Button();
            this.buttonSeasonOk = new System.Windows.Forms.Button();
            this.dataGridViewSeasons = new System.Windows.Forms.DataGridView();
            this.buttonCancle = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonChangeSeason = new System.Windows.Forms.Button();
            this.buttonDeleteSeason = new System.Windows.Forms.Button();
            this.buttonInsertSeason = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeasons)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSeasonCancle);
            this.panel1.Controls.Add(this.buttonSeasonOk);
            this.panel1.Controls.Add(this.dataGridViewSeasons);
            this.panel1.Controls.Add(this.buttonCancle);
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Controls.Add(this.buttonChangeSeason);
            this.panel1.Controls.Add(this.buttonDeleteSeason);
            this.panel1.Controls.Add(this.buttonInsertSeason);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 330);
            this.panel1.TabIndex = 2;
            // 
            // buttonSeasonCancle
            // 
            this.buttonSeasonCancle.Location = new System.Drawing.Point(674, 6);
            this.buttonSeasonCancle.Name = "buttonSeasonCancle";
            this.buttonSeasonCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonSeasonCancle.TabIndex = 8;
            this.buttonSeasonCancle.Text = "Отмена";
            this.buttonSeasonCancle.UseVisualStyleBackColor = true;
            this.buttonSeasonCancle.Click += new System.EventHandler(this.buttonSeasonCancle_Click);
            // 
            // buttonSeasonOk
            // 
            this.buttonSeasonOk.Location = new System.Drawing.Point(596, 6);
            this.buttonSeasonOk.Name = "buttonSeasonOk";
            this.buttonSeasonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonSeasonOk.TabIndex = 7;
            this.buttonSeasonOk.Text = "Ок";
            this.buttonSeasonOk.UseVisualStyleBackColor = true;
            this.buttonSeasonOk.Click += new System.EventHandler(this.buttonSeasonOk_Click);
            // 
            // dataGridViewSeasons
            // 
            this.dataGridViewSeasons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeasons.Location = new System.Drawing.Point(6, 35);
            this.dataGridViewSeasons.Name = "dataGridViewSeasons";
            this.dataGridViewSeasons.Size = new System.Drawing.Size(743, 286);
            this.dataGridViewSeasons.TabIndex = 6;
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
            // buttonChangeSeason
            // 
            this.buttonChangeSeason.Location = new System.Drawing.Point(87, 6);
            this.buttonChangeSeason.Name = "buttonChangeSeason";
            this.buttonChangeSeason.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeSeason.TabIndex = 3;
            this.buttonChangeSeason.Text = "Изменить";
            this.buttonChangeSeason.UseVisualStyleBackColor = true;
            this.buttonChangeSeason.Click += new System.EventHandler(this.buttonChangeSeason_Click);
            // 
            // buttonDeleteSeason
            // 
            this.buttonDeleteSeason.Location = new System.Drawing.Point(168, 6);
            this.buttonDeleteSeason.Name = "buttonDeleteSeason";
            this.buttonDeleteSeason.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteSeason.TabIndex = 2;
            this.buttonDeleteSeason.Text = "Удалить";
            this.buttonDeleteSeason.UseVisualStyleBackColor = true;
            this.buttonDeleteSeason.Click += new System.EventHandler(this.buttonDeleteSeason_Click);
            // 
            // buttonInsertSeason
            // 
            this.buttonInsertSeason.Location = new System.Drawing.Point(6, 6);
            this.buttonInsertSeason.Name = "buttonInsertSeason";
            this.buttonInsertSeason.Size = new System.Drawing.Size(75, 23);
            this.buttonInsertSeason.TabIndex = 1;
            this.buttonInsertSeason.Text = "Добавить";
            this.buttonInsertSeason.UseVisualStyleBackColor = true;
            this.buttonInsertSeason.Click += new System.EventHandler(this.buttonInsertSeason_Click);
            // 
            // SeasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 330);
            this.Controls.Add(this.panel1);
            this.Name = "SeasonForm";
            this.Text = "SeasonForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeasons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSeasonCancle;
        private System.Windows.Forms.Button buttonSeasonOk;
        private System.Windows.Forms.DataGridView dataGridViewSeasons;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonChangeSeason;
        private System.Windows.Forms.Button buttonDeleteSeason;
        private System.Windows.Forms.Button buttonInsertSeason;
    }
}