using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FNL.Forms;

using Svt.Caspar;
using Svt.Network;
using FNL.Views;
using FNL.Presenters;
using System.Text.RegularExpressions;

namespace FNL
{
    public partial class MainForm : Form, IMatchView
    {
        private delegate void UpdateGUI(object parameter);

        private CasparDevice _caspar_ = new CasparDevice();
        private CasparCGDataCollection _cgData = new CasparCGDataCollection();

        //private DataSet _teamsDs = new DataSet();
        private DataTable _teamsDt = new DataTable("TEAMS");
        private DataView _team1Dv = new DataView();
        private DataView _team2Dv = new DataView();

        public int MatchId { get; set; }
        public int GuestPlayerId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PairGuestPlayerId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int HomePlayerId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PairHomePlayerId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameMatch { get => textNameMatch.Text; set => textNameMatch.Text = value; }
        public string NameGuest { get => textNameGuest.Text; set => textNameGuest.Text = value; }
        public string NameHome { get => textNameHome.Text; set => textNameHome.Text = value; }
        public Color ColorGuest { get => buttonColorTeamGuest.BackColor; set => buttonColorTeamGuest.BackColor = value; }
        public Color ColorHome { get => buttonColorTeamHome.BackColor; set => buttonColorTeamHome.BackColor = value; }
        public DateTime TimeMatch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int NumberTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SeasonName { get; set; }

        public MainForm()
        {
            InitializeComponent();

            _team1Dv.Table = _teamsDt;
            _team2Dv.Table = _teamsDt;
            //cb1Teams.DataSource = _team1Dv;
            //cb2Teams.DataSource = _team2Dv;

            InitDatatable();
            FillDatatable();

            _caspar_.Connected += new EventHandler<NetworkEventArgs>(Caspar__Connected);
            _caspar_.FailedConnect += new EventHandler<NetworkEventArgs>(Caspar__FailedConnected);
            _caspar_.Disconnected += new EventHandler<NetworkEventArgs>(Caspar__Disconnected);

            //this.btnLockTeams.Image = FNL.Properties.Resources.lock_unlock;

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

        #region Graphic
        /// <summary>
        /// Start graphic and set data to cgData.
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
                _cgData.SetData("team1Name", ""/*cb1Teams.SelectedValue.ToString()*/);
                _cgData.SetData("team2Name", ""/*cb2Teams.SelectedValue.ToString()*/);
                _cgData.SetData("team1Score", tBScoreTeam1.Text);
                _cgData.SetData("team2Score", tBScoreTeam2.Text);
                _cgData.SetData("team1Color", buttonColorTeamGuest.BackColor.ToArgb().ToString());
                _cgData.SetData("team2Color", buttonColorTeamHome.BackColor.ToArgb().ToString());
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
        /// <summary>
        /// Stop graphic.
        /// </summary>
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

            //cb1Teams.ValueMember = "TeamNameAbbrevation";
            //cb1Teams.DisplayMember = "TeamNameFull";

            //cb2Teams.ValueMember = "TeamNameAbbrevation";
            //cb2Teams.DisplayMember = "TeamNameFull";
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
            tabControl1.Enabled = false; //!!!!!!!!!!!!!!!!!!!!!!!!
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
        private void UpdateTeams(object sender = null, EventArgs e = null)
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
                // Choose only what is in brackets. Short team name.
                _cgData.SetData("team1Name", Regex.Replace(NameGuest, @"\([^)]+\)\.", String.Empty));
                _cgData.SetData("team2Name", Regex.Replace(NameHome, @"\([^)]+\)\.", String.Empty));
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
        /// Hide or show timer of game.
        /// </summary>
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
        /// Start or stop the timer.
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
        /// <summary>
        /// Update game time that was setted with user.
        /// </summary>
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
        private void UpdateScoresCG(object sender, EventArgs e)
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

        /// <summary>
        /// Update data of players in Caspar CG. 
        /// Chose between guest or home team indepences 
        /// <param name="isGuest"></param> parametr.
        /// </summary>
        /// <param name="isGuest"></param>
        /// /// <param name="isPairs"></param>
        private void UpdatePlayersCG(bool isGuest, bool isPairs)
        {
            List<ITablePlayersMainView> players = new List<ITablePlayersMainView>();
            List<ITablePlayersMainView> pairsPlayers = new List<ITablePlayersMainView>();
            string logoPath;

            MatchPresenter presenter = new MatchPresenter(this);
            logoPath = presenter.GetLogoPathTeam(isGuest);
            if (isGuest)
            {

                players = !isPairs ? ((List<ITablePlayersMainView>)dataGridPlayersGuest.DataSource) : null;
                pairsPlayers = isPairs ? (List<ITablePlayersMainView>)dataGridPlayersPairsGuest.DataSource : null;
            }
            else
            {
                players = !isPairs ? (List<ITablePlayersMainView>)dataGridPlayersHome.DataSource : null;
                pairsPlayers = isPairs ? (List<ITablePlayersMainView>)dataGridPlayersPairsHome.DataSource : null;
            }

            players = players ?? new List<ITablePlayersMainView>();
            pairsPlayers = pairsPlayers ?? new List<ITablePlayersMainView>();

            // Get trainer of team.
            var mainTrainer = players.Where(t => t.R == DictionaryRoles.RoleDic[DictionaryRoles.Roles.MainTrainer]).FirstOrDefault();

            // Delete all people that not players.
            players = players.Where(t => t.R == DictionaryRoles.RoleDic[DictionaryRoles.Roles.Player]).ToList();
            pairsPlayers = pairsPlayers.Where(t => t.R == DictionaryRoles.RoleDic[DictionaryRoles.Roles.Player]).ToList();

            // Set goalkeper to first position in list.
            var goalKeper = players.Where(t => t.A == DictionaryAmpluas.AmpluaDic[DictionaryAmpluas.Ampluas.Goalkeeper]).FirstOrDefault();
            if (goalKeper != null)
            {
                players.Remove(goalKeper);
                players.Insert(0, goalKeper);
            }

            /*
 Check for valid field values
 */
            // Change goalkeeper with classic player. Goalkeeper need to be in first place in list.
            // Здесь код для перестановки вратаря на первое место.

            try
            {
                // Clear old data
                _cgData.Clear();

                // buid logo
                _cgData.SetData("teamLogoPath", logoPath);

                // Build title.
                _cgData.SetData("titleName", isPairs ? "ЗАПАСНЫЕ" : "СТАРТОВЫЙ СОСТВА");

                // Build season name.
                _cgData.SetData("seasonName", SeasonName);

                // Set main trainer of team.
                _cgData.SetData("trainerName", string.Format("Главный тренер - {0} {1}", mainTrainer != null ? mainTrainer.FirstName : "", mainTrainer != null ? mainTrainer.LastName : ""));

                // Set the amplua of first player goalkeper.
                _cgData.SetData("ampluaPlayer1", "В");

                // build data players.
                if (!isPairs)
                {
                    _cgData.SetData("namePlayer1", players.Count() > 0 ? players[0].FirstName + " " + players[0].LastName : " ");
                    _cgData.SetData("namePlayer2", players.Count() > 1 ? players[1].FirstName + " " + players[1].LastName : " ");
                    _cgData.SetData("namePlayer3", players.Count() > 2 ? players[2].FirstName + " " + players[2].LastName : " ");
                    _cgData.SetData("namePlayer4", players.Count() > 3 ? players[3].FirstName + " " + players[3].LastName : " ");
                    _cgData.SetData("namePlayer5", players.Count() > 4 ? players[4].FirstName + " " + players[4].LastName : " ");
                    _cgData.SetData("namePlayer6", players.Count() > 5 ? players[5].FirstName + " " + players[5].LastName : " ");
                    _cgData.SetData("namePlayer7", players.Count() > 6 ? players[6].FirstName + " " + players[6].LastName : " ");
                    _cgData.SetData("namePlayer8", players.Count() > 7 ? players[7].FirstName + " " + players[7].LastName : " ");
                    _cgData.SetData("namePlayer9", players.Count() > 8 ? players[8].FirstName + " " + players[8].LastName : " ");
                    _cgData.SetData("namePlayer10", players.Count() > 9 ? players[9].FirstName + " " + players[9].LastName : " ");
                    _cgData.SetData("namePlayer11", players.Count() > 10 ? players[10].FirstName + " " + players[10].LastName : " ");

                    _cgData.SetData("numPlayer1", players.Count() > 0 ? players[0].N.ToString() : " ");
                    _cgData.SetData("numPlayer2", players.Count() > 1 ? players[1].N.ToString() : " ");
                    _cgData.SetData("numPlayer3", players.Count() > 2 ? players[2].N.ToString() : " ");
                    _cgData.SetData("numPlayer4", players.Count() > 3 ? players[3].N.ToString() : " ");
                    _cgData.SetData("numPlayer5", players.Count() > 4 ? players[4].N.ToString() : " ");
                    _cgData.SetData("numPlayer6", players.Count() > 5 ? players[5].N.ToString() : " ");
                    _cgData.SetData("numPlayer7", players.Count() > 6 ? players[6].N.ToString() : " ");
                    _cgData.SetData("numPlayer8", players.Count() > 7 ? players[7].N.ToString() : " ");
                    _cgData.SetData("numPlayer9", players.Count() > 8 ? players[8].N.ToString() : " ");
                    _cgData.SetData("numPlayer10", players.Count() > 9 ? players[9].N.ToString() : " ");
                    _cgData.SetData("numPlayer11", players.Count() > 10 ? players[10].N.ToString() : " ");

                }
                else if (isPairs)
                {
                    _cgData.SetData("nameSparePlayer1", pairsPlayers.Count() > 0 ? pairsPlayers[0].FirstName + " " + pairsPlayers[0].LastName : " ");
                    _cgData.SetData("nameSparePlayer2", pairsPlayers.Count() > 1 ? pairsPlayers[1].FirstName + " " + pairsPlayers[1].LastName : " ");
                    _cgData.SetData("nameSparePlayer3", pairsPlayers.Count() > 2 ? pairsPlayers[2].FirstName + " " + pairsPlayers[2].LastName : " ");
                    _cgData.SetData("nameSparePlayer4", pairsPlayers.Count() > 3 ? pairsPlayers[3].FirstName + " " + pairsPlayers[3].LastName : " ");
                    _cgData.SetData("nameSparePlayer5", pairsPlayers.Count() > 4 ? pairsPlayers[4].FirstName + " " + pairsPlayers[4].LastName : " ");
                    _cgData.SetData("nameSparePlayer6", pairsPlayers.Count() > 5 ? pairsPlayers[5].FirstName + " " + pairsPlayers[5].LastName : " ");
                    _cgData.SetData("nameSparePlayer7", pairsPlayers.Count() > 6 ? pairsPlayers[6].FirstName + " " + pairsPlayers[6].LastName : " ");
                    _cgData.SetData("nameSparePlayer8", pairsPlayers.Count() > 7 ? pairsPlayers[7].FirstName + " " + pairsPlayers[7].LastName : " ");
                    _cgData.SetData("nameSparePlayer9", pairsPlayers.Count() > 8 ? pairsPlayers[8].FirstName + " " + pairsPlayers[8].LastName : " ");
                    _cgData.SetData("nameSparePlayer10", pairsPlayers.Count() > 9 ? pairsPlayers[9].FirstName + " " + pairsPlayers[9].LastName : " ");
                    _cgData.SetData("nameSparePlayer11", pairsPlayers.Count() > 10 ? pairsPlayers[10].FirstName + " " + pairsPlayers[10].LastName : " ");

                    _cgData.SetData("numSparePlayer1", pairsPlayers.Count() > 0 ? pairsPlayers[0].N.ToString() : " ");
                    _cgData.SetData("numSparePlayer2", pairsPlayers.Count() > 1 ? pairsPlayers[1].N.ToString() : " ");
                    _cgData.SetData("numSparePlayer3", pairsPlayers.Count() > 2 ? pairsPlayers[2].N.ToString() : " ");
                    _cgData.SetData("numSparePlayer4", pairsPlayers.Count() > 3 ? pairsPlayers[3].N.ToString() : " ");
                    _cgData.SetData("numSparePlayer5", pairsPlayers.Count() > 4 ? pairsPlayers[4].N.ToString() : " ");
                    _cgData.SetData("numSparePlayer6", pairsPlayers.Count() > 5 ? pairsPlayers[5].N.ToString() : " ");
                    _cgData.SetData("numSparePlayer7", pairsPlayers.Count() > 6 ? pairsPlayers[6].N.ToString() : " ");
                    _cgData.SetData("numSparePlayer8", pairsPlayers.Count() > 7 ? pairsPlayers[7].N.ToString() : " ");
                    _cgData.SetData("numSparePlayer9", pairsPlayers.Count() > 8 ? pairsPlayers[8].N.ToString() : " ");
                    _cgData.SetData("numSparePlayer10", pairsPlayers.Count() > 9 ? pairsPlayers[9].N.ToString() : " ");
                    _cgData.SetData("numSparePlayer11", pairsPlayers.Count() > 10 ? pairsPlayers[10].N.ToString() : " ");

                }

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

        private void ShowHidePlayers()
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
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Invoke(Properties.Settings.Default.GraphicsLayerClock, "PlayersShowHide");
                }
            }
        }
        private void ShowHideSparePlayers()
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
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Invoke(Properties.Settings.Default.GraphicsLayerClock, "PlayersSpareShowHide");
                }
            }
        }

        private bool HasValidClockData()
        {
            return true;
        }
        /// <summary>
        /// Get the time that was settes by user in form.
        /// </summary>
        /// <returns></returns>
        private string GetGameTimeCGData()
        {
            return tbTimeMin.Text + ":" + tbTimeSec.Text;
        }
        /// <summary>
        /// Show or hide the clock with timers and main information about teams like score and their names.
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
        /// Show or hide additional minutes on screen.
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
        /// <summary>
        /// Save to cgData and set to template information about the half of game.
        /// </summary>
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
        /// <summary>
        /// Update the color teams in template.
        /// </summary>
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
                _cgData.SetData("team1Color", buttonColorTeamGuest.BackColor.ToArgb().ToString());
                _cgData.SetData("team2Color", buttonColorTeamHome.BackColor.ToArgb().ToString());
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
        /// Save the additional time that was setted by user in form.
        /// </summary>
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

        public void UpdateView()
        {
            TablePlayersMainPresenter presenterTable = new TablePlayersMainPresenter();
            // Update tables.
            dataGridPlayersGuest.DataSource = presenterTable.GetViews(MatchId, CategoryTable.GuestTeam, false);
            dataGridPlayersPairsGuest.DataSource = presenterTable.GetViews(MatchId, CategoryTable.GuestTeam, true);
            dataGridPlayersHome.DataSource = presenterTable.GetViews(MatchId, CategoryTable.HomeTeam, false);
            dataGridPlayersPairsHome.DataSource = presenterTable.GetViews(MatchId, CategoryTable.HomeTeam, true);

            MatchPresenter matchPresenter = new MatchPresenter(this);
            matchPresenter.ShowView();

            // Caspar CG Data Update
            UpdateTeams();
        }

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
            //this.cb1Teams.Enabled = !this.cb1Teams.Enabled;
            //this.cb2Teams.Enabled = !this.cb2Teams.Enabled;

            //if (this.cb1Teams.Enabled)
            //{
            //    this.btnLockTeams.Image = FNL.Properties.Resources.lock_unlock;
            //}
            //else
            //{
            //    this.btnLockTeams.Image = FNL.Properties.Resources.lock_lock;
            //}
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


        private void BtnHalfSet(object sender, EventArgs e)
        {
            this.SaveHalfNum();
        }

        private void BtnAdditionalTime(object sender, EventArgs e)
        {
            this.SaveAdditionalTime();
        }

        #region Done
        private void ClickButtonColorTeamGuest(object sender, EventArgs e)
        {
            buttonColorTeamGuest.BackColor = ChoseNewColor();
            UpdateColorTeams();
        }

        private void ClickButtonColorTeamHome(object sender, EventArgs e)
        {
            buttonColorTeamHome.BackColor = ChoseNewColor();
            UpdateColorTeams();
        }

        public Color ChoseNewColor()
        {
            ColorDialog MyDialog = new ColorDialog
            {
                // Keeps the user from selecting a custom color.
                AllowFullOpen = true,
                // Allows the user to get help. (The default is false.)
                ShowHelp = true,
            };

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                return MyDialog.Color;
            }

            return Color.White;
        }
        #endregion

        private void buttonMatch_Click(object sender, EventArgs e)
        {
            MatchesForm matchesForm = new MatchesForm(this);
            matchesForm.Show();
        }

        private void checkBoxListPlayers_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxListPlayers.Enabled)
            {
                if (radioButtonGuest.Checked)
                {
                    UpdatePlayersCG(true, false);
                }
                else if (radioButtonHome.Checked)
                {
                    UpdatePlayersCG(false, false);
                }
            }

            ShowHidePlayers();
        }

        private void checkBoxListPairsPlayers_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxListPlayers.Enabled)
            {
                if (radioButtonGuest.Checked)
                {
                    UpdatePlayersCG(true, true);
                }
                else if (radioButtonHome.Checked)
                {
                    UpdatePlayersCG(false, true);
                }
            }

            ShowHideSparePlayers();
        }

    }

}
