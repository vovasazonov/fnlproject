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
using FNL.Dictionarys;
using FNL.Enums;

namespace FNL
{
    public partial class MainForm : Form, IMatchView
    {
        private delegate void UpdateGUI(object parameter);

        #region CasparCG values.
        private CasparDevice _caspar_ = new CasparDevice();
        private CasparCGDataCollection _cgData = new CasparCGDataCollection();
        #endregion

        #region View value.
        public int MatchId { get; set; }
        public int GuestPlayerId
        {
            get
            {
                ITablePlayersMainView player = null;
                if (dataGridPlayersGuest.CurrentRow != null)
                {

                    player = ((List<ITablePlayersMainView>)(dataGridPlayersGuest.DataSource))[dataGridPlayersGuest.CurrentRow.Index];
                }
                return player != null ? player.PersonId : -1;
            }
            set => throw new NotImplementedException();
        }
        public int PairGuestPlayerId
        {
            get
            {
                ITablePlayersMainView player = null;
                if (dataGridPlayersPairsGuest.CurrentRow != null)
                {

                    player = ((List<ITablePlayersMainView>)(dataGridPlayersPairsGuest.DataSource))[dataGridPlayersPairsGuest.CurrentRow.Index];
                }
                return player != null ? player.PersonId : -1;
            }
            set => throw new NotImplementedException();
        }
        public int HomePlayerId
        {
            get
            {
                ITablePlayersMainView player = null;
                if (dataGridPlayersHome.CurrentRow != null)
                {
                    player = ((List<ITablePlayersMainView>)(dataGridPlayersHome.DataSource))[dataGridPlayersHome.CurrentRow.Index];

                }
                return player != null ? player.PersonId : -1;
            }
            set => throw new NotImplementedException();
        }
        public int PairHomePlayerId
        {
            get
            {
                ITablePlayersMainView player = null;
                if (dataGridPlayersPairsHome.CurrentRow != null)
                {
                    player = ((List<ITablePlayersMainView>)(dataGridPlayersPairsHome.DataSource))[dataGridPlayersPairsHome.CurrentRow.Index];

                }
                return player != null ? player.PersonId : -1;
            }
            set => throw new NotImplementedException();
        }
        public string NameMatch { get => textNameMatch.Text; set => textNameMatch.Text = value; }
        public string NameGuest { get => textNameGuest.Text; set => textNameGuest.Text = value; }
        public string NameHome { get => textNameHome.Text; set => textNameHome.Text = value; }
        public Color ColorGuest { get => buttonColorTeamGuest.BackColor; set => buttonColorTeamGuest.BackColor = value; }
        public Color ColorHome { get => buttonColorTeamHome.BackColor; set => buttonColorTeamHome.BackColor = value; }
        public DateTime TimeMatch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int NumberHalfTime { get => (int)numHalfNum.Value; set => numHalfNum.Value = value; }
        public string SeasonName { get; set; }
        public string GoalsGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TotalShotGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ShotTargetGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CornerGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string OffsideGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PassGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string AccuratePassGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FoulGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string YellowTicketGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string RedTicketGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ChangeGuest { get => textChangeGuest.Text; set => textChangeGuest.Text = value; }
        public string GoalsHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TotalShotHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ShotTargetHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CornerHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string OffsideHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PassHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string AccuratePassHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FoulHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string YellowTicketHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string RedTicketHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ChangeHome { get => textChangeHome.Text; set => textChangeHome.Text = value; }
        #endregion

        public MainForm()
        {
            InitializeComponent();

            _caspar_.Connected += new EventHandler<NetworkEventArgs>(Caspar__Connected);
            _caspar_.FailedConnect += new EventHandler<NetworkEventArgs>(Caspar__FailedConnected);
            _caspar_.Disconnected += new EventHandler<NetworkEventArgs>(Caspar__Disconnected);

            // Disable controls to click on button. There are not connection yet on start program.
            DisableControls();

            dataGridPlayersGuest.CurrentCellChanged += DataGridPlayers_CurrentCellChanged;
            dataGridPlayersPairsGuest.CurrentCellChanged += DataGridPlayers_CurrentCellChanged;
            dataGridPlayersHome.CurrentCellChanged += DataGridPlayers_CurrentCellChanged;
            dataGridPlayersPairsHome.CurrentCellChanged += DataGridPlayers_CurrentCellChanged;

            Logger.InitLogger();//инициализация - требуется один раз в начале
            Logger.Log.Info("Ура заработало!");
            Logger.Log.Error("Ошибочка вышла!");
            try
            {
                int i = 5;
                int d = 0;
                var t = i/d;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Ошибка деление на нуль", ex);
            }
        }



        #region Connection CasparCG methods.
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

        #region Graphic CasparCG.
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
                _cgData.SetData("team1Name", NameGuest);
                _cgData.SetData("team2Name", NameHome);
                _cgData.SetData("team1Score", tBScoreTeam1.Text);
                _cgData.SetData("team2Score", tBScoreTeam2.Text);
                _cgData.SetData("team1Color", buttonColorTeamGuest.BackColor.ToArgb().ToString());
                _cgData.SetData("team2Color", buttonColorTeamHome.BackColor.ToArgb().ToString());
                _cgData.SetData("halfNum", Convert.ToString(NumberHalfTime));
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

        /// <summary>
        /// Update the values view of events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridPlayers_CurrentCellChanged(object sender, EventArgs e)
        {
            MatchPresenter presenter = new MatchPresenter(this);
            presenter.UpdateViewEvents();
        }




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
                _cgData.SetData("team1Name", NameGuest);// Regex.Replace(NameGuest, @"\(([^)]+)\)", String.Empty));
                _cgData.SetData("team2Name", NameHome);// Regex.Replace(NameHome, @"\(([^)]+)\)", String.Empty));
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

        private void UpdateReplacementCG(bool isGuest)
        {
            MatchPresenter presenter = new MatchPresenter(this);

            ITablePlayersMainView player = null;
            ITablePlayersMainView pairPlayer = null;

            if (isGuest)
            {
                player = ((List<ITablePlayersMainView>)dataGridPlayersGuest.DataSource)[dataGridPlayersGuest.CurrentRow.Index];
                pairPlayer = ((List<ITablePlayersMainView>)dataGridPlayersPairsGuest.DataSource)[dataGridPlayersPairsGuest.CurrentRow.Index];
            }
            else
            {
                player = ((List<ITablePlayersMainView>)dataGridPlayersHome.DataSource)[dataGridPlayersHome.CurrentRow.Index];
                pairPlayer = ((List<ITablePlayersMainView>)dataGridPlayersPairsHome.DataSource)[dataGridPlayersPairsHome.CurrentRow.Index];
            }

            try
            {
                // Clear old data
                _cgData.Clear();

                // buid logo
                _cgData.SetData("replacementTeamLogoPath", presenter.GetLogoPathTeam(isGuest));

                // Build names and numbers players that are replacementing.
                _cgData.SetData("nameRedLine", string.Format("{0} {1}", player.FirstName, player.LastName));
                _cgData.SetData("numberRedLine", player.N.ToString());
                _cgData.SetData("nameGreenLine", string.Format("{0} {1}", pairPlayer.FirstName, pairPlayer.LastName));
                _cgData.SetData("numberGreenLine", pairPlayer.N.ToString());

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

        private void ShowHideReplacementCG()
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
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Invoke(Properties.Settings.Default.GraphicsLayerClock, "ReplacementShowHide");
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
        private void UpdatePlayersCG(PersonAccessory accessory/*bool isGuest*/, bool isPairs = false)
        {
            List<ITablePlayersMainView> players = new List<ITablePlayersMainView>();
            List<ITablePlayersMainView> pairsPlayers = new List<ITablePlayersMainView>();
            string logoPath;

            MatchPresenter presenter = new MatchPresenter(this);
            if (accessory == PersonAccessory.FaceMatch)
            {
                logoPath = "";
            }
            else
            {
                logoPath = presenter.GetLogoPathTeam(accessory == PersonAccessory.GuestTeam ? true : false);
            }
            if (accessory == PersonAccessory.GuestTeam)
            {

                players = !isPairs ? ((List<ITablePlayersMainView>)dataGridPlayersGuest.DataSource) : null;
                pairsPlayers = isPairs ? (List<ITablePlayersMainView>)dataGridPlayersPairsGuest.DataSource : null;
            }
            else if (accessory == PersonAccessory.HomeTeam)
            {
                players = !isPairs ? (List<ITablePlayersMainView>)dataGridPlayersHome.DataSource : null;
                pairsPlayers = isPairs ? (List<ITablePlayersMainView>)dataGridPlayersPairsHome.DataSource : null;
            }

            players = players ?? new List<ITablePlayersMainView>();
            pairsPlayers = pairsPlayers ?? new List<ITablePlayersMainView>();

            // Get trainer of team.
            var mainTrainer = players.Where(t => t.R == DictionaryRoles.Dic[RoleType.MainTrainer]).FirstOrDefault();

            // Delete all people that not players.
            players = players.Where(t => t.R == DictionaryRoles.Dic[RoleType.Player]).ToList();
            pairsPlayers = pairsPlayers.Where(t => t.R == DictionaryRoles.Dic[RoleType.Player]).ToList();

            // Set goalkeper to first position in list.
            var goalKeper = players.Where(t => t.A == DictionaryAmpluas.Dic[AmpluaType.Goalkeeper]).FirstOrDefault();
            if (goalKeper != null)
            {
                players.Remove(goalKeper);
                players.Insert(0, goalKeper);
            }

            try
            {
                // Clear old data
                _cgData.Clear();

                // buid logo
                _cgData.SetData("teamLogoPath", logoPath);

                // Build title.
                _cgData.SetData("titleName", accessory == PersonAccessory.FaceMatch ? "ОФИЦИАЛЬНЫЕ ЛИЦА МАТЧА" : (isPairs ? "ЗАПАСНЫЕ" : "СТАРТОВЫЙ СОСТВА"));

                // Build season name.
                _cgData.SetData("seasonName", SeasonName);

                // Set main trainer of team.
                _cgData.SetData("trainerName", string.Format("Главный тренер - {0} {1}", mainTrainer != null ? mainTrainer.FirstName : "", mainTrainer != null ? mainTrainer.LastName : ""));

                // Set the amplua of first player goalkeper.
                _cgData.SetData("ampluaPlayer1", "В");

                // build data players.
                if (!isPairs || accessory != PersonAccessory.FaceMatch)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        _cgData.SetData(string.Format("namePlayer{0}", i + 1), players.Count() > 0 ? players[0].FirstName + " " + players[0].LastName : " ");
                        _cgData.SetData(string.Format("numPlayer{0}", i + 1), players.Count() > 0 ? players[0].N.ToString() : " ");
                    }

                }
                else if (isPairs || accessory == PersonAccessory.FaceMatch)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        _cgData.SetData(string.Format("nameSparePlayer{0}", i + 1), pairsPlayers.Count() > i && accessory != PersonAccessory.FaceMatch ? pairsPlayers[i].FirstName + " " + pairsPlayers[i].LastName : " ");
                        _cgData.SetData(string.Format("numSparePlayer{0}", i + 1), pairsPlayers.Count() > i && accessory != PersonAccessory.FaceMatch ? pairsPlayers[i].N.ToString() : " ");
                    }
                }

                if (accessory == PersonAccessory.FaceMatch)
                {
                    _cgData.SetData("titleMainJudje", "Главный судья");
                    _cgData.SetData("titleHelperJudje", "Помощники");
                    _cgData.SetData("titlePairJudje", "Резервный судья");
                    _cgData.SetData("titleInsepcotor", "Инспектор");
                    _cgData.SetData("titleDelegat", "Делегат");

                    _cgData.SetData("nameMainJudje", "");
                    _cgData.SetData("nameHelperJudje1", "");
                    _cgData.SetData("nameHelperJudje2", "");
                    _cgData.SetData("namePairJudje", "");
                    _cgData.SetData("nameInsepcotor", "");
                    _cgData.SetData("nameDelegat", "");

                    _cgData.SetData("cityMainJudje", "");
                    _cgData.SetData("cityHelperJudje1", "");
                    _cgData.SetData("cityHelperJudje2", "");
                    _cgData.SetData("cityPairJudje", "");
                    _cgData.SetData("cityInsepcotor", "");
                    _cgData.SetData("cityDelegat", "");



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

        private void ShowHidePlayersCG()
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
        private void ShowHidePairsPlayers()
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
                _cgData.SetData("halfNum", Convert.ToString(NumberHalfTime));
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


        public void UpdateView()
        {
            TablePlayersMainPresenter presenterTable = new TablePlayersMainPresenter();
            // Update tables.
            dataGridPlayersGuest.DataSource = presenterTable.GetViews(MatchId, PersonAccessory.GuestTeam, false);
            dataGridPlayersPairsGuest.DataSource = presenterTable.GetViews(MatchId, PersonAccessory.GuestTeam, true);
            dataGridPlayersHome.DataSource = presenterTable.GetViews(MatchId, PersonAccessory.HomeTeam, false);
            dataGridPlayersPairsHome.DataSource = presenterTable.GetViews(MatchId, PersonAccessory.HomeTeam, true);

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
            MatchTableForm matchesForm = new MatchTableForm(this);
            matchesForm.Show();
        }

        private void checkBoxListPlayers_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxListPlayers.Enabled)
            {
                if (radioButtonGuest.Checked)
                {
                    UpdatePlayersCG(PersonAccessory.GuestTeam, false);
                }
                else if (radioButtonHome.Checked)
                {
                    UpdatePlayersCG(PersonAccessory.HomeTeam, false);
                }
            }

            ShowHidePlayersCG();
        }

        private void checkBoxListPairsPlayers_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxListPlayers.Enabled)
            {
                if (radioButtonGuest.Checked)
                {
                    UpdatePlayersCG(PersonAccessory.GuestTeam, true);
                }
                else if (radioButtonHome.Checked)
                {
                    UpdatePlayersCG(PersonAccessory.HomeTeam, true);
                }
            }

            ShowHidePairsPlayers();
        }

        private void btnMinChangeGuest_Click(object sender, EventArgs e)
        {
        }

        private void btnAddChangeGuest_Click(object sender, EventArgs e)
        {
            MatchPresenter presenter = new MatchPresenter(this);
            presenter.Replacement(true);

            UpdateReplacementCG(true);
            ShowHideReplacementCG();

            UpdateView();
        }

        private void btnAddChangeHome_Click(object sender, EventArgs e)
        {
            MatchPresenter presenter = new MatchPresenter(this);
            presenter.Replacement(false);

            UpdateReplacementCG(false);
            ShowHideReplacementCG();

            UpdateView();
        }

        private void btnMinChangeHome_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxOfficialFaces_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePlayersCG(PersonAccessory.FaceMatch);
            ShowHideOfficialFacesMatch();
        }

        private void ShowHideOfficialFacesMatch()
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
                    _caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Invoke(Properties.Settings.Default.GraphicsLayerClock, "OfficialFacesShowHide");
                }
            }
        }
    }

}
