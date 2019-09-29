namespace FNL.Forms
{
	partial class MatchesForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateMatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stadium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Season = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamGuest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoalGuest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamHome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoalHome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Commentator1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Commentator2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancle);
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Controls.Add(this.buttonChangeMatch);
            this.panel1.Controls.Add(this.buttonDeleteMatch);
            this.panel1.Controls.Add(this.buttonInsertMatch);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 425);
            this.panel1.TabIndex = 0;
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.MatchName,
            this.DateMatch,
            this.Stadium,
            this.Season,
            this.TeamGuest,
            this.GoalGuest,
            this.TeamHome,
            this.GoalHome,
            this.Commentator1,
            this.Commentator2});
            this.dataGridView1.Location = new System.Drawing.Point(3, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1011, 387);
            this.dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Идентификатор";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // MatchName
            // 
            this.MatchName.HeaderText = "Матч";
            this.MatchName.Name = "MatchName";
            // 
            // DateMatch
            // 
            this.DateMatch.HeaderText = "Дата";
            this.DateMatch.Name = "DateMatch";
            // 
            // Stadium
            // 
            this.Stadium.HeaderText = "Стадион";
            this.Stadium.Name = "Stadium";
            // 
            // Season
            // 
            this.Season.HeaderText = "Сезон";
            this.Season.Name = "Season";
            // 
            // TeamGuest
            // 
            this.TeamGuest.HeaderText = "Комадна гостей";
            this.TeamGuest.Name = "TeamGuest";
            // 
            // GoalGuest
            // 
            this.GoalGuest.HeaderText = "Голы гостей";
            this.GoalGuest.Name = "GoalGuest";
            // 
            // TeamHome
            // 
            this.TeamHome.HeaderText = "Команда дома";
            this.TeamHome.Name = "TeamHome";
            // 
            // GoalHome
            // 
            this.GoalHome.HeaderText = "Голы дом";
            this.GoalHome.Name = "GoalHome";
            // 
            // Commentator1
            // 
            this.Commentator1.HeaderText = "Комментатор1";
            this.Commentator1.Name = "Commentator1";
            // 
            // Commentator2
            // 
            this.Commentator2.HeaderText = "Комментатор2";
            this.Commentator2.Name = "Commentator2";
            // 
            // MatchesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 450);
            this.Controls.Add(this.panel1);
            this.Name = "MatchesForm";
            this.Text = "MatchesForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button buttonChangeMatch;
		private System.Windows.Forms.Button buttonDeleteMatch;
		private System.Windows.Forms.Button buttonInsertMatch;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.DataGridViewTextBoxColumn MatchName;
		private System.Windows.Forms.DataGridViewTextBoxColumn DateMatch;
		private System.Windows.Forms.DataGridViewTextBoxColumn Stadium;
		private System.Windows.Forms.DataGridViewTextBoxColumn Season;
		private System.Windows.Forms.DataGridViewTextBoxColumn TeamGuest;
		private System.Windows.Forms.DataGridViewTextBoxColumn GoalGuest;
		private System.Windows.Forms.DataGridViewTextBoxColumn TeamHome;
		private System.Windows.Forms.DataGridViewTextBoxColumn GoalHome;
		private System.Windows.Forms.DataGridViewTextBoxColumn Commentator1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Commentator2;
		private System.Windows.Forms.Button buttonCancle;
		private System.Windows.Forms.Button buttonOk;
	}
}