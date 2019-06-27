namespace FNL
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbCasparServer = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.btnClearGraphics = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gpStartStopTemplate = new System.Windows.Forms.GroupBox();
            this.btnStartGraphics = new System.Windows.Forms.Button();
            this.btnStopGraphics = new System.Windows.Forms.Button();
            this.gpTeams = new System.Windows.Forms.GroupBox();
            this.btnLockTeams = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb1Teams = new System.Windows.Forms.ComboBox();
            this.cb2Teams = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tbBottomFlarp = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.numHalfNum = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnTeam2AddScore = new System.Windows.Forms.Button();
            this.btnTeam2MinusScore = new System.Windows.Forms.Button();
            this.btnTeam1AddScore = new System.Windows.Forms.Button();
            this.btnTeam1MinusScore = new System.Windows.Forms.Button();
            this.tBScoreTeam2 = new System.Windows.Forms.TextBox();
            this.tBScoreTeam1 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnShowHideTimer = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTimeSec = new System.Windows.Forms.TextBox();
            this.tbTimeMin = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.numOvertime = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShowMain = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gpStartStopTemplate.SuspendLayout();
            this.gpTeams.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHalfNum)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOvertime)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbCasparServer
            // 
            this.tbCasparServer.Location = new System.Drawing.Point(20, 14);
            this.tbCasparServer.Name = "tbCasparServer";
            this.tbCasparServer.Size = new System.Drawing.Size(64, 20);
            this.tbCasparServer.TabIndex = 13;
            this.tbCasparServer.Text = "localhost";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(90, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(71, 23);
            this.buttonConnect.TabIndex = 12;
            this.buttonConnect.Text = "Соединить";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // btnClearGraphics
            // 
            this.btnClearGraphics.BackColor = System.Drawing.Color.LightSalmon;
            this.btnClearGraphics.Location = new System.Drawing.Point(167, 12);
            this.btnClearGraphics.Name = "btnClearGraphics";
            this.btnClearGraphics.Size = new System.Drawing.Size(99, 23);
            this.btnClearGraphics.TabIndex = 16;
            this.btnClearGraphics.Text = "Очистить";
            this.btnClearGraphics.UseVisualStyleBackColor = false;
            this.btnClearGraphics.Click += new System.EventHandler(this.BtnClearGraphics_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 487);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(694, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.TabStop = true;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(690, 460);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gpStartStopTemplate);
            this.tabPage1.Controls.Add(this.gpTeams);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(682, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Верхний титр";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gpStartStopTemplate
            // 
            this.gpStartStopTemplate.Controls.Add(this.btnStartGraphics);
            this.gpStartStopTemplate.Controls.Add(this.btnStopGraphics);
            this.gpStartStopTemplate.Location = new System.Drawing.Point(173, 367);
            this.gpStartStopTemplate.Name = "gpStartStopTemplate";
            this.gpStartStopTemplate.Size = new System.Drawing.Size(326, 56);
            this.gpStartStopTemplate.TabIndex = 21;
            this.gpStartStopTemplate.TabStop = false;
            this.gpStartStopTemplate.Text = "Clock graphics";
            // 
            // btnStartGraphics
            // 
            this.btnStartGraphics.BackColor = System.Drawing.Color.Lime;
            this.btnStartGraphics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGraphics.ForeColor = System.Drawing.Color.Black;
            this.btnStartGraphics.Location = new System.Drawing.Point(210, 19);
            this.btnStartGraphics.Name = "btnStartGraphics";
            this.btnStartGraphics.Size = new System.Drawing.Size(106, 29);
            this.btnStartGraphics.TabIndex = 1;
            this.btnStartGraphics.Text = "Start graphics";
            this.btnStartGraphics.UseVisualStyleBackColor = false;
            this.btnStartGraphics.Click += new System.EventHandler(this.BtnStartGraphics_Click);
            // 
            // btnStopGraphics
            // 
            this.btnStopGraphics.BackColor = System.Drawing.Color.OrangeRed;
            this.btnStopGraphics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopGraphics.ForeColor = System.Drawing.Color.Black;
            this.btnStopGraphics.Location = new System.Drawing.Point(15, 19);
            this.btnStopGraphics.Name = "btnStopGraphics";
            this.btnStopGraphics.Size = new System.Drawing.Size(106, 29);
            this.btnStopGraphics.TabIndex = 0;
            this.btnStopGraphics.Text = "Stop graphics";
            this.btnStopGraphics.UseVisualStyleBackColor = false;
            this.btnStopGraphics.Click += new System.EventHandler(this.BtnStopGraphics_Click);
            // 
            // gpTeams
            // 
            this.gpTeams.Controls.Add(this.btnLockTeams);
            this.gpTeams.Controls.Add(this.label3);
            this.gpTeams.Controls.Add(this.label2);
            this.gpTeams.Controls.Add(this.cb1Teams);
            this.gpTeams.Controls.Add(this.cb2Teams);
            this.gpTeams.Location = new System.Drawing.Point(16, 21);
            this.gpTeams.Name = "gpTeams";
            this.gpTeams.Size = new System.Drawing.Size(644, 63);
            this.gpTeams.TabIndex = 14;
            this.gpTeams.TabStop = false;
            this.gpTeams.Text = "Команды";
            // 
            // btnLockTeams
            // 
            this.btnLockTeams.Location = new System.Drawing.Point(551, 33);
            this.btnLockTeams.Name = "btnLockTeams";
            this.btnLockTeams.Size = new System.Drawing.Size(32, 24);
            this.btnLockTeams.TabIndex = 4;
            this.btnLockTeams.UseVisualStyleBackColor = true;
            this.btnLockTeams.Click += new System.EventHandler(this.BtnLockTeams_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(396, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Гости";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Хозяева";
            // 
            // cb1Teams
            // 
            this.cb1Teams.FormattingEnabled = true;
            this.cb1Teams.Location = new System.Drawing.Point(112, 35);
            this.cb1Teams.Name = "cb1Teams";
            this.cb1Teams.Size = new System.Drawing.Size(197, 21);
            this.cb1Teams.TabIndex = 0;
            this.cb1Teams.TextChanged += new System.EventHandler(this.UpdateTeams);
            // 
            // cb2Teams
            // 
            this.cb2Teams.FormattingEnabled = true;
            this.cb2Teams.Location = new System.Drawing.Point(322, 35);
            this.cb2Teams.Name = "cb2Teams";
            this.cb2Teams.Size = new System.Drawing.Size(197, 21);
            this.cb2Teams.TabIndex = 1;
            this.cb2Teams.TextChanged += new System.EventHandler(this.UpdateTeams);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.tbBottomFlarp);
            this.groupBox2.Location = new System.Drawing.Point(163, 276);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 76);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extra text";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Show/Hide F5";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // tbBottomFlarp
            // 
            this.tbBottomFlarp.Location = new System.Drawing.Point(10, 19);
            this.tbBottomFlarp.Name = "tbBottomFlarp";
            this.tbBottomFlarp.Size = new System.Drawing.Size(115, 20);
            this.tbBottomFlarp.TabIndex = 0;
            this.tbBottomFlarp.Text = "Overtime";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button10);
            this.groupBox6.Controls.Add(this.numHalfNum);
            this.groupBox6.Location = new System.Drawing.Point(163, 168);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(74, 102);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Half";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(7, 41);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(54, 51);
            this.button10.TabIndex = 1;
            this.button10.Text = "Spara";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // numHalfNum
            // 
            this.numHalfNum.Location = new System.Drawing.Point(8, 15);
            this.numHalfNum.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numHalfNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHalfNum.Name = "numHalfNum";
            this.numHalfNum.Size = new System.Drawing.Size(53, 20);
            this.numHalfNum.TabIndex = 0;
            this.numHalfNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnTeam2AddScore);
            this.groupBox5.Controls.Add(this.btnTeam2MinusScore);
            this.groupBox5.Controls.Add(this.btnTeam1AddScore);
            this.groupBox5.Controls.Add(this.btnTeam1MinusScore);
            this.groupBox5.Controls.Add(this.tBScoreTeam2);
            this.groupBox5.Controls.Add(this.tBScoreTeam1);
            this.groupBox5.Location = new System.Drawing.Point(16, 90);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(644, 69);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Счет";
            // 
            // btnTeam2AddScore
            // 
            this.btnTeam2AddScore.BackColor = System.Drawing.Color.Honeydew;
            this.btnTeam2AddScore.Location = new System.Drawing.Point(381, 27);
            this.btnTeam2AddScore.Name = "btnTeam2AddScore";
            this.btnTeam2AddScore.Size = new System.Drawing.Size(26, 23);
            this.btnTeam2AddScore.TabIndex = 3;
            this.btnTeam2AddScore.Text = "+";
            this.btnTeam2AddScore.UseVisualStyleBackColor = false;
            this.btnTeam2AddScore.Click += new System.EventHandler(this.BtnTeam2AddScore_Click);
            // 
            // btnTeam2MinusScore
            // 
            this.btnTeam2MinusScore.BackColor = System.Drawing.Color.Salmon;
            this.btnTeam2MinusScore.Location = new System.Drawing.Point(328, 27);
            this.btnTeam2MinusScore.Name = "btnTeam2MinusScore";
            this.btnTeam2MinusScore.Size = new System.Drawing.Size(26, 23);
            this.btnTeam2MinusScore.TabIndex = 2;
            this.btnTeam2MinusScore.Text = "-";
            this.btnTeam2MinusScore.UseVisualStyleBackColor = false;
            this.btnTeam2MinusScore.Click += new System.EventHandler(this.BtnTeam2MinusScore_Click);
            // 
            // btnTeam1AddScore
            // 
            this.btnTeam1AddScore.BackColor = System.Drawing.Color.Honeydew;
            this.btnTeam1AddScore.Location = new System.Drawing.Point(274, 27);
            this.btnTeam1AddScore.Name = "btnTeam1AddScore";
            this.btnTeam1AddScore.Size = new System.Drawing.Size(26, 23);
            this.btnTeam1AddScore.TabIndex = 1;
            this.btnTeam1AddScore.Text = "+";
            this.btnTeam1AddScore.UseVisualStyleBackColor = false;
            this.btnTeam1AddScore.Click += new System.EventHandler(this.BtnTeam1AddScore_Click);
            // 
            // btnTeam1MinusScore
            // 
            this.btnTeam1MinusScore.BackColor = System.Drawing.Color.Salmon;
            this.btnTeam1MinusScore.Location = new System.Drawing.Point(221, 27);
            this.btnTeam1MinusScore.Name = "btnTeam1MinusScore";
            this.btnTeam1MinusScore.Size = new System.Drawing.Size(26, 23);
            this.btnTeam1MinusScore.TabIndex = 0;
            this.btnTeam1MinusScore.Text = "-";
            this.btnTeam1MinusScore.UseVisualStyleBackColor = false;
            this.btnTeam1MinusScore.Click += new System.EventHandler(this.BtnTeam1MinusScore_Click);
            // 
            // tBScoreTeam2
            // 
            this.tBScoreTeam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBScoreTeam2.Location = new System.Drawing.Point(355, 28);
            this.tBScoreTeam2.Name = "tBScoreTeam2";
            this.tBScoreTeam2.Size = new System.Drawing.Size(26, 22);
            this.tBScoreTeam2.TabIndex = 3;
            this.tBScoreTeam2.TabStop = false;
            this.tBScoreTeam2.Text = "0";
            this.tBScoreTeam2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBScoreTeam2.TextChanged += new System.EventHandler(this.UpdateResults);
            // 
            // tBScoreTeam1
            // 
            this.tBScoreTeam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBScoreTeam1.Location = new System.Drawing.Point(248, 28);
            this.tBScoreTeam1.Name = "tBScoreTeam1";
            this.tBScoreTeam1.Size = new System.Drawing.Size(25, 22);
            this.tBScoreTeam1.TabIndex = 99;
            this.tBScoreTeam1.TabStop = false;
            this.tBScoreTeam1.Text = "0";
            this.tBScoreTeam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBScoreTeam1.TextChanged += new System.EventHandler(this.UpdateResults);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnShowHideTimer);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.tbTimeSec);
            this.groupBox4.Controls.Add(this.tbTimeMin);
            this.groupBox4.Location = new System.Drawing.Point(251, 168);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(136, 102);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Time";
            // 
            // btnShowHideTimer
            // 
            this.btnShowHideTimer.Location = new System.Drawing.Point(9, 74);
            this.btnShowHideTimer.Name = "btnShowHideTimer";
            this.btnShowHideTimer.Size = new System.Drawing.Size(120, 24);
            this.btnShowHideTimer.TabIndex = 14;
            this.btnShowHideTimer.Text = "Show/hide timer";
            this.btnShowHideTimer.UseVisualStyleBackColor = true;
            this.btnShowHideTimer.Click += new System.EventHandler(this.ButtonShowHideTimer_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(9, 45);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Start/Stop F3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.BtnTimeStartStop_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(77, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(53, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "Set";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.BtnSetGameTime_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(40, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = ":";
            // 
            // tbTimeSec
            // 
            this.tbTimeSec.Location = new System.Drawing.Point(53, 18);
            this.tbTimeSec.MaxLength = 2;
            this.tbTimeSec.Name = "tbTimeSec";
            this.tbTimeSec.Size = new System.Drawing.Size(20, 20);
            this.tbTimeSec.TabIndex = 1;
            this.tbTimeSec.Text = "00";
            // 
            // tbTimeMin
            // 
            this.tbTimeMin.Location = new System.Drawing.Point(13, 18);
            this.tbTimeMin.MaxLength = 3;
            this.tbTimeMin.Name = "tbTimeMin";
            this.tbTimeMin.Size = new System.Drawing.Size(24, 20);
            this.tbTimeMin.TabIndex = 0;
            this.tbTimeMin.Text = "00";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.numOvertime);
            this.groupBox3.Location = new System.Drawing.Point(338, 276);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 76);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Additional time";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(7, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 24);
            this.button3.TabIndex = 1;
            this.button3.Text = "Show/hide F6";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ButtonShowAddMinutes);
            // 
            // numOvertime
            // 
            this.numOvertime.Location = new System.Drawing.Point(7, 19);
            this.numOvertime.Name = "numOvertime";
            this.numOvertime.Size = new System.Drawing.Size(43, 20);
            this.numOvertime.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShowMain);
            this.groupBox1.Location = new System.Drawing.Point(399, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 101);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clock";
            // 
            // btnShowMain
            // 
            this.btnShowMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnShowMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowMain.ForeColor = System.Drawing.Color.Black;
            this.btnShowMain.Location = new System.Drawing.Point(16, 18);
            this.btnShowMain.Name = "btnShowMain";
            this.btnShowMain.Size = new System.Drawing.Size(76, 73);
            this.btnShowMain.TabIndex = 0;
            this.btnShowMain.Text = "Show/hide clock F4";
            this.btnShowMain.UseVisualStyleBackColor = false;
            this.btnShowMain.Click += new System.EventHandler(this.BtnShowMain_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(682, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "players";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 509);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnClearGraphics);
            this.Controls.Add(this.tbCasparServer);
            this.Controls.Add(this.buttonConnect);
            this.Name = "Form1";
            this.Text = "ФНЛ. ГТРК \"Волгоград-ТРВ\"";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gpStartStopTemplate.ResumeLayout(false);
            this.gpTeams.ResumeLayout(false);
            this.gpTeams.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numHalfNum)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numOvertime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCasparServer;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button btnClearGraphics;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gpTeams;
        private System.Windows.Forms.Button btnLockTeams;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbBottomFlarp;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.NumericUpDown numHalfNum;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnTeam2AddScore;
        private System.Windows.Forms.Button btnTeam2MinusScore;
        private System.Windows.Forms.Button btnTeam1AddScore;
        private System.Windows.Forms.Button btnTeam1MinusScore;
        private System.Windows.Forms.TextBox tBScoreTeam2;
        private System.Windows.Forms.TextBox tBScoreTeam1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTimeSec;
        private System.Windows.Forms.TextBox tbTimeMin;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numOvertime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShowMain;
        private System.Windows.Forms.GroupBox gpStartStopTemplate;
        private System.Windows.Forms.Button btnStartGraphics;
        private System.Windows.Forms.Button btnStopGraphics;
        private System.Windows.Forms.ComboBox cb1Teams;
        private System.Windows.Forms.ComboBox cb2Teams;
        private System.Windows.Forms.Button btnShowHideTimer;
    }
}

