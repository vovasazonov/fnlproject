using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Svt.Caspar;
using Svt.Network;

namespace FNL
{
    public partial class Form1 : Form
    {
        private delegate void UpdateGUI(object parameter);

        private CasparDevice _caspar_ = new CasparDevice();
        private CasparCGDataCollection _cgData = new CasparCGDataCollection();

        private DataSet _teamsDs = new DataSet();
        private DataTable _teamsDt = new DataTable("TEAMS");
        private DataView _team1Dv = new DataView();
        private DataView _team2Dv = new DataView();

        public Form1()
        {
            InitializeComponent();

            _team1Dv.Table = _teamsDt;
            _team2Dv.Table = _teamsDt;
            cb1Teams.DataSource = _team1Dv;
            cb2Teams.DataSource = _team2Dv;

            InitDatatable();
            FillDatatable();

            _caspar_.Connected += new EventHandler<NetworkEventArgs>(Caspar__Connected);
            _caspar_.FailedConnect += new EventHandler<NetworkEventArgs>(Caspar__FailedConnected);
            _caspar_.Disconnected += new EventHandler<NetworkEventArgs>(Caspar__Disconnected);

            this.btnLockTeams.Image = FNL.Properties.Resources.lock_unlock;

            // Disable controls to click on button. There are not connection yet on start program.
            DisableControls();
        }

        #region Connection CasparCG methods
        /// <summary>
        /// Method that call for caspar cg when it connected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Caspar__Connected(object sender, NetworkEventArgs e)
        {
            if (InvokeRequired)
                BeginInvoke(new UpdateGUI(OnCasparConnected), e);
            else
                OnCasparConnected(e);
        }
        void OnCasparConnected(object param)
        {
            buttonConnect.Enabled = true;
            UpdateConnectButtonText();

            _caspar_.RefreshMediafiles();
            _caspar_.RefreshDatalist();

            NetworkEventArgs e = (NetworkEventArgs)param;
            statusStrip1.BackColor = Color.LightGreen;
            toolStripStatusLabel1.Text = "Connected to " + _caspar_.Settings.Hostname; // Properties.Settings.Default.Hostname;

            EnableControls();
        }
        /// <summary>
        /// Caspar event - failed connect.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Caspar__FailedConnected(object sender, NetworkEventArgs e)
        {
            if (InvokeRequired)
                BeginInvoke(new UpdateGUI(OnCasparFailedConnect), e);
            else
                OnCasparFailedConnect(e);
        }
        void OnCasparFailedConnect(object param)
        {
            buttonConnect.Enabled = true;
            UpdateConnectButtonText();

            NetworkEventArgs e = (NetworkEventArgs)param;
            statusStrip1.BackColor = Color.LightCoral;
            toolStripStatusLabel1.Text = "Failed to connect to " + _caspar_.Settings.Hostname; // Properties.Settings.Default.Hostname;

            DisableControls();
        }

        /// <summary>
        /// Caspar event - disconnected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Caspar__Disconnected(object sender, NetworkEventArgs e)
        {
            if (InvokeRequired)
                BeginInvoke(new UpdateGUI(OnCasparDisconnected), e);
            else
                OnCasparDisconnected(e);
        }
        void OnCasparDisconnected(object param)
        {
            buttonConnect.Enabled = true;
            UpdateConnectButtonText();

            NetworkEventArgs e = (NetworkEventArgs)param;
            statusStrip1.BackColor = Color.LightCoral;
            toolStripStatusLabel1.Text = "Disconnected from " + _caspar_.Settings.Hostname; // Properties.Settings.Default.Hostname;

            DisableControls();
        }
        #endregion
        #region Datatable mathods
        private void InitDatatable()
        {
            if (_teamsDt.Columns.Count == 0)
            {
                _teamsDt.Columns.Add("TeamNameAbbrevation");
                _teamsDt.Columns[0].DataType = System.Type.GetType("System.String");
                _teamsDt.Columns.Add("TeamNameFull");
                _teamsDt.Columns[0].DataType = System.Type.GetType("System.String");
            }

            cb1Teams.ValueMember = "TeamNameAbbrevation";
            cb1Teams.DisplayMember = "TeamNameFull";

            cb2Teams.ValueMember = "TeamNameAbbrevation";
            cb2Teams.DisplayMember = "TeamNameFull";
        }

        private void FillDatatable()
        {
            DataRow relation;
            // Declare the array variable.
            object[] rowArray = new object[2];
            // Create 10 new rows and add to DataRowCollection.
            for (int i = 0; i < Properties.Settings.Default.Teams.Count; i++)
            {
                String[] teamDescription = Properties.Settings.Default.Teams[i].Split((new Char[] { '#', ',' }));
                if (teamDescription.Length == 2)
                {
                    rowArray[0] = teamDescription[0];
                    rowArray[1] = teamDescription[1];
                    relation = _teamsDt.NewRow();
                    relation.ItemArray = rowArray;
                    _teamsDt.Rows.Add(relation);
                }
            }
        }

        #endregion
        #region Other methods.
        /// <summary>
        /// Disable controls in tub of form.
        /// </summary>
        private void DisableControls()
        {
            tabControl1.Enabled = false;
        }
        /// <summary>
        /// Enable controls in tub of form.
        /// </summary>
        private void EnableControls()
        {
            tabControl1.Enabled = true;
        }
        /// <summary>
        /// Update the text status connection of button that control connection.
        /// </summary>
        private void UpdateConnectButtonText()
        {
            if (!_caspar_.IsConnected)
            {
                buttonConnect.Text = "Connect";// to " + Properties.Settings.Default.Hostname;
            }
            else
            {
                buttonConnect.Text = "Disconnect"; // from " + Properties.Settings.Default.Hostname;
            }
        }

        /// <summary>
        /// Update names of teams when it changing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTeams(object sender, EventArgs e)
        {
            /*
             Check for valid field values
             */
            if (!this.HasValidClockData())
            {
                return;
            }

            try
            {
                // Clear old data
                _cgData.Clear();

                // build data
                _cgData.SetData("team1Name", cb1Teams.SelectedValue.ToString());
                _cgData.SetData("team2Name", cb2Teams.SelectedValue.ToString());
            }
            catch
            {

            }
            finally
            {
                if (_caspar_.IsConnected && _caspar_.Channels.Count > 0)
                {
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Update(Properties.Settings.Default.GraphicsLayerClock, _cgData);
                }
            }
        }
        private void ShowHideTimer()
        {
            try
            {

            }
            catch
            {

            }
            finally
            {
                if (_caspar_.IsConnected && _caspar_.Channels.Count > 0)
                {
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Invoke(Properties.Settings.Default.GraphicsLayerClock, "clockShowHideTimer");
                }
            }
        }

        /// <summary>
        /// Start the timer.
        /// </summary>
        private void GameTimeStartStop()
        {
            try
            {

            }
            catch
            {

            }
            finally
            {
                if (_caspar_.IsConnected && _caspar_.Channels.Count > 0)
                {
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Invoke(Properties.Settings.Default.GraphicsLayerClock, "gameTimeStartStop");
                }
            }
        }

        private void UpdateGameTime()
        {
            /*
             TODO: Check for valid field values
             */


            try
            {
                // Clear old data
                _cgData.Clear();

                // build data
                _cgData.SetData("gameTime", this.GetGameTimeCGData());
            }
            catch
            {

            }
            finally
            {
                if (_caspar_.IsConnected && _caspar_.Channels.Count > 0)
                {
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Update(Properties.Settings.Default.GraphicsLayerClock, _cgData);
                }
            }
        }

        /// <summary>
        /// Update results of score in template animation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateResults(object sender, EventArgs e)
        {
            /*
             Check for valid field values
             */
            if (!this.HasValidClockData())
            {
                return;
            }

            try
            {
                // Clear old data
                _cgData.Clear();

                // build data
                _cgData.SetData("team1Score", tBScoreTeam1.Text);
                _cgData.SetData("team2Score", tBScoreTeam2.Text);
            }
            catch
            {

            }
            finally
            {
                if (_caspar_.IsConnected && _caspar_.Channels.Count > 0)
                {
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Update(Properties.Settings.Default.GraphicsLayerClock, _cgData);
                }
            }
        }

        private void StopGraphic()
        {
            try
            {

            }
            catch
            {

            }
            finally
            {
                if (_caspar_.IsConnected && _caspar_.Channels.Count > 0)
                {
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Stop(Properties.Settings.Default.GraphicsLayerClock);
                }
            }
        }

        private bool HasValidClockData()
        {
            return true;
        }

        /// <summary>
        /// Start graphic
        /// </summary>
        private void StartGraphic()
        {
            /*
             Check for valid field values
             */
            if (!this.HasValidClockData())
            {
                return;
            }

            try
            {
                // Clear old data
                _cgData.Clear();

                // build data
                _cgData.SetData("team1Name", cb1Teams.SelectedValue.ToString());
                _cgData.SetData("team2Name", cb2Teams.SelectedValue.ToString());
                _cgData.SetData("team1Score", tBScoreTeam1.Text);
                _cgData.SetData("team2Score", tBScoreTeam2.Text);
                _cgData.SetData("team1Color", buttonColorTeam1.BackColor.ToArgb().ToString());
                _cgData.SetData("team2Color", buttonColorTeam2.BackColor.ToArgb().ToString());
                _cgData.SetData("halfNum", Convert.ToString(numHalfNum.Value));
                _cgData.SetData("gameTime", this.GetGameTimeCGData());
                _cgData.SetData("overtime", Convert.ToString(numOvertime.Value));

            }
            catch
            {

            }
            finally
            {
                if (_caspar_.IsConnected && _caspar_.Channels.Count > 0)
                {
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Add(Properties.Settings.Default.GraphicsLayerClock, Properties.Settings.Default.TemplateNameClock, true, _cgData);
                }
            }
        }

        private string GetGameTimeCGData()
        {
            return tbTimeMin.Text + ":" + tbTimeSec.Text;
        }

        /// <summary>
        /// Show or hide the table with information of game.
        /// </summary>
        private void ShowHideClock()
        {
            try
            {

            }
            catch
            {

            }
            finally
            {
                if (_caspar_.IsConnected && _caspar_.Channels.Count > 0)
                {
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Invoke(Properties.Settings.Default.GraphicsLayerClock, "clockShowHide");
                }
            }
        }
        /// <summary>
        /// Show additional minutes on screen.
        /// </summary>
        private void ShowHideAddMin()
        {
            try
            {

            }
            catch
            {

            }
            finally
            {
                if (_caspar_.IsConnected && _caspar_.Channels.Count > 0)
                {
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Invoke(Properties.Settings.Default.GraphicsLayerClock, "ltimerShowHide");
                }
            }
        }

        private void ShowHideChange()
        {
            try
            {

            }
            catch
            {

            }
            finally
            {
                if (_caspar_.IsConnected && _caspar_.Channels.Count > 0)
                {
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Invoke(Properties.Settings.Default.GraphicsLayerClock, "changeShowHide");
                }
            }
        }

        private void SaveHalfNum()
        {
            // spara halvtid
            /*
             TODO: Check for valid field values
             */

            try
            {
                // Clear old data
                _cgData.Clear();

                // build data
                _cgData.SetData("halfNum", Convert.ToString(numHalfNum.Value));
            }
            catch
            {

            }
            finally
            {
                if (_caspar_.IsConnected && _caspar_.Channels.Count > 0)
                {
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Update(Properties.Settings.Default.GraphicsLayerClock, _cgData);
                }
            }
        }

        private void UpdateColorTeams()
        {
            // spara halvtid
            /*
             TODO: Check for valid field values
             */

            try
            {
                // Clear old data
                _cgData.Clear();

                // build data
                _cgData.SetData("team1Color", buttonColorTeam1.BackColor.ToArgb().ToString());
                _cgData.SetData("team2Color", buttonColorTeam2.BackColor.ToArgb().ToString());
            }
            catch
            {

            }
            finally
            {
                if (_caspar_.IsConnected && _caspar_.Channels.Count > 0)
                {
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Update(Properties.Settings.Default.GraphicsLayerClock, _cgData);
                }
            }
        }

        private void SaveAdditionalTime()
        {
            // spara halvtid
            /*
             TODO: Check for valid field values
             */

            try
            {
                // Clear old data
                _cgData.Clear();

                // build data
                _cgData.SetData("overtime", Convert.ToString(numOvertime.Value));
            }
            catch
            {

            }
            finally
            {
                if (_caspar_.IsConnected && _caspar_.Channels.Count > 0)
                {
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Update(Properties.Settings.Default.GraphicsLayerClock, _cgData);
                }
            }
        }
        #endregion
        #region Methods invoke by events from form.
        private void BtnSetGameTime_Click(object sender, EventArgs e)
        {
            this.UpdateGameTime();
        }
        private void BtnTeam1MinusScore_Click(object sender, EventArgs e)
        {
            /// get score
            int currentScore = Convert.ToInt16(tBScoreTeam1.Text);

            /// update score
            if (currentScore > 0)
            {
                currentScore--;
                tBScoreTeam1.Text = Convert.ToString(currentScore);
            }

        }

        private void BtnTeam1AddScore_Click(object sender, EventArgs e)
        {
            /// get score
            int currentScore = Convert.ToInt16(tBScoreTeam1.Text);

            /// update score
            currentScore++;
            tBScoreTeam1.Text = Convert.ToString(currentScore);

        }

        private void BtnTeam2MinusScore_Click(object sender, EventArgs e)
        {
            /// get score
            int currentScore = Convert.ToInt16(tBScoreTeam2.Text);

            /// update score
            if (currentScore > 0)
            {
                currentScore--;
                tBScoreTeam2.Text = Convert.ToString(currentScore);
            }
        }

        private void BtnTeam2AddScore_Click(object sender, EventArgs e)
        {
            /// get score
            int currentScore = Convert.ToInt16(tBScoreTeam2.Text);

            /// update score
            currentScore++;
            tBScoreTeam2.Text = Convert.ToString(currentScore);
        }

        private void BtnShowMain_Click(object sender, EventArgs e)
        {
            this.ShowHideClock();
        }


        /// <summary>
        /// Button to show additional minutes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonShowAddMinutes(object sender, EventArgs e)
        {
            this.ShowHideAddMin();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.ShowHideChange();
        }

        private void ButtonShowHideTimer_Click(object sender, EventArgs e)
        {
            this.ShowHideTimer();
        }
        /// <summary>
        /// Connect/disconnect to caspar device.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            buttonConnect.Enabled = false;

            if (!_caspar_.IsConnected)
            {
                _caspar_.Settings.Hostname = this.tbCasparServer.Text; // Properties.Settings.Default.Hostname;
                _caspar_.Settings.Port = 5250;
                _caspar_.Connect();
            }
            else
            {
                _caspar_.Disconnect();
            }
        }
        /// <summary>
        /// Clear graphic in caspar device.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClearGraphics_Click(object sender, EventArgs e)
        {
            try
            {
                this._caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Clear();
                this._caspar_.Channels[Properties.Settings.Default.CasparChannel].Clear();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Lock teams that was chosed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLockTeams_Click(object sender, EventArgs e)
        {
            this.cb1Teams.Enabled = !this.cb1Teams.Enabled;
            this.cb2Teams.Enabled = !this.cb2Teams.Enabled;

            if (this.cb1Teams.Enabled)
            {
                this.btnLockTeams.Image = FNL.Properties.Resources.lock_unlock;
            }
            else
            {
                this.btnLockTeams.Image = FNL.Properties.Resources.lock_lock;
            }
        }

        private void BtnStartGraphics_Click(object sender, EventArgs e)
        {
            this.StartGraphic();
        }

        private void BtnStopGraphics_Click(object sender, EventArgs e)
        {
            this.StopGraphic();
        }


        private void BtnTimeStartStop_Click(object sender, EventArgs e)
        {
            this.GameTimeStartStop(); 
        }
        #endregion

        private void BtnHalfSet(object sender, EventArgs e)
        {
            this.SaveHalfNum();
        }

        private void btnAdditionalTime(object sender, EventArgs e)
        {
            this.SaveAdditionalTime();
        }

        private void ButtonColorTeam1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = buttonColorTeam1.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                buttonColorTeam1.BackColor = MyDialog.Color;
                UpdateColorTeams();
            }
        }

        private void ButtonColorTeam2_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = buttonColorTeam2.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                buttonColorTeam2.BackColor = MyDialog.Color;
                this.UpdateColorTeams();
            }
        }
    }

}
