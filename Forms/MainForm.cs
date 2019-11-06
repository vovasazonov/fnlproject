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
using FNL.Extensions;

namespace FNL
{
    public partial class MainForm : Form, IMainView
    {
        #region View variables.
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

        #region Class variables.
        private delegate void UpdateGUI(object parameter);
        #endregion

        public MainForm()
        {
            InitializeComponent();

            // Disable controls to click on button. There are not connection yet on start program.
            DisableControls();

            CasparFNL.Device.Connected += new EventHandler<NetworkEventArgs>(Caspar__Connected);
            CasparFNL.Device.FailedConnect += new EventHandler<NetworkEventArgs>(Caspar__FailedConnected);
            CasparFNL.Device.Disconnected += new EventHandler<NetworkEventArgs>(Caspar__Disconnected);

            dataGridPlayersGuest.CurrentCellChanged += DataGridPlayers_CurrentCellChanged;
            dataGridPlayersPairsGuest.CurrentCellChanged += DataGridPlayers_CurrentCellChanged;
            dataGridPlayersHome.CurrentCellChanged += DataGridPlayers_CurrentCellChanged;
            dataGridPlayersPairsHome.CurrentCellChanged += DataGridPlayers_CurrentCellChanged;
        }

        private void Caspar__Connected(object sender, NetworkEventArgs e)
        {
            if (InvokeRequired)
                BeginInvoke(new UpdateGUI(OnCasparConnected), e);
            else
                OnCasparConnected(e);
        }

        private void OnCasparConnected(object param)
        {
            buttonConnect.Enabled = true;
            UpdateConnectButtonText();

            CasparFNL.Device.RefreshMediafiles();
            CasparFNL.Device.RefreshDatalist();

            NetworkEventArgs e = (NetworkEventArgs)param;
            statusStrip1.BackColor = Color.LightGreen;
            toolStripStatusLabel1.Text = "Connected to " + CasparFNL.Device.Settings.Hostname; 

            EnableControls();
        }

        private void Caspar__FailedConnected(object sender, NetworkEventArgs e)
        {
            if (InvokeRequired)
                BeginInvoke(new UpdateGUI(OnCasparFailedConnect), e);
            else
                OnCasparFailedConnect(e);
        }

        private void OnCasparFailedConnect(object param)
        {
            buttonConnect.Enabled = true;
            UpdateConnectButtonText();

            NetworkEventArgs e = (NetworkEventArgs)param;
            statusStrip1.BackColor = Color.LightCoral;
            toolStripStatusLabel1.Text = "Failed to connect to " + CasparFNL.Device.Settings.Hostname;

            DisableControls();
        }

        private void Caspar__Disconnected(object sender, NetworkEventArgs e)
        {
            if (InvokeRequired)
                BeginInvoke(new UpdateGUI(OnCasparDisconnected), e);
            else
                OnCasparDisconnected(e);
        }

        private void OnCasparDisconnected(object param)
        {
            buttonConnect.Enabled = true;
            UpdateConnectButtonText();

            NetworkEventArgs e = (NetworkEventArgs)param;
            statusStrip1.BackColor = Color.LightCoral;
            toolStripStatusLabel1.Text = "Disconnected from " + CasparFNL.Device.Settings.Hostname;

            DisableControls();
        }

        private void StartGraphic()
        {
            // Check for valid field values.
            if (!this.HasValidClockData())
            {
                return;
            }

            CasparFNL.StartGraphic();

            CasparFNL.SendData(new Dictionary<string, string>()
            {
                {"team1Name", NameGuest},
                {"team2Name", NameHome},
                {"team1Score", tBScoreTeam1.Text},
                {"team2Score", tBScoreTeam2.Text},
                {"team1Color", buttonColorTeamGuest.BackColor.ToArgb().ToString()},
                {"team2Color", buttonColorTeamHome.BackColor.ToArgb().ToString()},
                {"halfNum", Convert.ToString(NumberHalfTime)},
                {"gameTime", this.GetGameTimeCGData()},
                {"overtime", Convert.ToString(numOvertime.Value)}
            });
        }

        private void StopGraphic()
        {
            CasparFNL.StopGrpahic();
        }

        private void DataGridPlayers_CurrentCellChanged(object sender, EventArgs e)
        {
            MainPresenter presenter = new MainPresenter(this);
            presenter.UpdateViewEvents();
        }

        private void DisableControls()
        {
            tabControl1.Enabled = false;
        }

        private void EnableControls()
        {
            tabControl1.Enabled = true;
        }

        private void UpdateConnectButtonText()
        {
            if (!CasparFNL.Device.IsConnected)
            {
                buttonConnect.Text = "Connect";
            }
            else
            {
                buttonConnect.Text = "Disconnect"; 
            }
        }

        private void UpdateNameTeams(object sender = null, EventArgs e = null)
        {
            if (!this.HasValidClockData())
            {
                return;
            }

            CasparFNL.SendData(new Dictionary<string, string>()
            {
                {"team1Name", NameGuest},
                {"team2Name", NameHome}
            });
        }

        private void ShowHideTimer()
        {
            CasparFNL.InvokeMethod("clockShowHideTimer");
        }

        private void GameTimeStartStop()
        {
            CasparFNL.InvokeMethod("gameTimeStartStop");
        }

        private void UpdateGameTime()
        {
            CasparFNL.SendData("gameTime", this.GetGameTimeCGData());
        }

        private void UpdateScoresCG(object sender, EventArgs e)
        {
            if (!this.HasValidClockData())
            {
                return;
            }

            CasparFNL.SendData(new Dictionary<string, string>()
            {
                {"team1Score", tBScoreTeam1.Text},
                {"team2Score", tBScoreTeam2.Text}
            });
        }

        private void UpdateReplacementCG(bool isGuest)
        {
            MainPresenter presenter = new MainPresenter(this);

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

            CasparFNL.SendData(new Dictionary<string, string>()
            {
                {"replacementTeamLogoPath", presenter.GetLogoPathTeam(isGuest)},
                {"nameRedLine", string.Format("{0} {1}", player.FirstName, player.LastName)},
                {"numberRedLine", player.N.ToString()},
                {"nameGreenLine", string.Format("{0} {1}", pairPlayer.FirstName, pairPlayer.LastName)},
                {"numberGreenLine", pairPlayer.N.ToString()},
            });
        }

        private void ShowHideReplacementCG()
        {
            CasparFNL.InvokeMethod("ReplacementShowHide");
        }

        /// <summary>
        /// Update data of players in Caspar CG. 
        /// Chose between guest or home team indepences 
        /// <param name="isGuest"></param> parametr.
        /// </summary>
        /// <param name="isGuest"></param>
        /// /// <param name="isPairs"></param>
        private void UpdatePlayersCG(PersonCategoryType accessory, bool isPairs = false)
        {
            List<ITablePlayersMainView> players = new List<ITablePlayersMainView>();
            List<ITablePlayersMainView> pairsPlayers = new List<ITablePlayersMainView>();
            string logoPath;

            MainPresenter presenter = new MainPresenter(this);
            if (accessory == PersonCategoryType.FaceMatch)
            {
                logoPath = "";
            }
            else
            {
                logoPath = presenter.GetLogoPathTeam(accessory == PersonCategoryType.GuestTeam ? true : false);
            }
            if (accessory == PersonCategoryType.GuestTeam)
            {

                players = !isPairs ? ((List<ITablePlayersMainView>)dataGridPlayersGuest.DataSource) : null;
                pairsPlayers = isPairs ? (List<ITablePlayersMainView>)dataGridPlayersPairsGuest.DataSource : null;
            }
            else if (accessory == PersonCategoryType.HomeTeam)
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

            Dictionary<string, string> dicCasparData = new Dictionary<string, string>();

            // buid logo
            dicCasparData.Add("teamLogoPath", logoPath);

            // Build title.
            dicCasparData.Add("titleName",
                accessory == PersonCategoryType.FaceMatch ? 
                "ОФИЦИАЛЬНЫЕ ЛИЦА МАТЧА" : 
                (isPairs ? "ЗАПАСНЫЕ" : "СТАРТОВЫЙ СОСТВА"));

            // Build season name.
            dicCasparData.Add("seasonName", SeasonName);

            // Set main trainer of team.
            dicCasparData.Add("trainerName",
                string.Format("Главный тренер - {0} {1}", 
                mainTrainer != null ? mainTrainer.FirstName : "", mainTrainer != null ? mainTrainer.LastName : ""));

            // Set the amplua of first player goalkeper.
            dicCasparData.Add("ampluaPlayer1", "В");

            // build data players.
            if (!isPairs || accessory != PersonCategoryType.FaceMatch)
            {
                for (int i = 0; i < 11; i++)
                {
                    dicCasparData.Add(string.Format("namePlayer{0}", i + 1),
                        players.Count() > i ? players[i].FirstName + " " + players[i].LastName : " ");
                    dicCasparData.Add(string.Format("numPlayer{0}", i + 1),
                        players.Count() > i ? players[i].N.ToString() : " ");
                }

            }

            if (isPairs || accessory == PersonCategoryType.FaceMatch)
            {
                for (int i = 0; i < 11; i++)
                {
                    dicCasparData.Add(string.Format("nameSparePlayer{0}", i + 1),
                        pairsPlayers.Count() > i && accessory != PersonCategoryType.FaceMatch ? 
                        pairsPlayers[i].FirstName + " " + pairsPlayers[i].LastName : 
                        " ");
                    dicCasparData.Add(string.Format("numSparePlayer{0}", i + 1),
                        pairsPlayers.Count() > i && accessory != PersonCategoryType.FaceMatch ? 
                        pairsPlayers[i].N.ToString() : 
                        " ");
                }
            }


            bool isFace = accessory == PersonCategoryType.FaceMatch;

            dicCasparData.Add("titleMainJudje", isFace ? "Главный судья" : "");
            dicCasparData.Add("titleHelperJudje", isFace ? "Помощники" : "");
            dicCasparData.Add("titlePairJudje", isFace ? "Резервный судья" : "");
            dicCasparData.Add("titleInsepcotor", isFace ? "Инспектор" : "");
            dicCasparData.Add("titleDelegat", isFace ? "Делегат" : "");

            dicCasparData.Add("nameMainJudje", isFace ? "" : "");
            dicCasparData.Add("nameHelperJudje1", isFace ? "" : "");
            dicCasparData.Add("nameHelperJudje2", isFace ? "" : "");
            dicCasparData.Add("namePairJudje", isFace ? "" : "");
            dicCasparData.Add("nameInsepcotor", isFace ? "" : "");
            dicCasparData.Add("nameDelegat", isFace ? "" : "");

            dicCasparData.Add("cityMainJudje", isFace ? "" : "");
            dicCasparData.Add("cityHelperJudje1", isFace ? "" : "");
            dicCasparData.Add("cityHelperJudje2", isFace ? "" : "");
            dicCasparData.Add("cityPairJudje", isFace ? "" : "");
            dicCasparData.Add("cityInsepcotor", isFace ? "" : "");
            dicCasparData.Add("cityDelegat", isFace ? "" : "");

            CasparFNL.SendData(dicCasparData);
        }

        private void ShowHidePlayersCG()
        {
            CasparFNL.InvokeMethod("PlayersShowHide");
        }

        private void ShowHidePairsPlayers()
        {
            CasparFNL.InvokeMethod("PlayersSpareShowHide");
        }

        private bool HasValidClockData()
        {
            return true;
        }

        private string GetGameTimeCGData()
        {
            return tbTimeMin.Text + ":" + tbTimeSec.Text;
        }

        private void ShowHideClock()
        {
            CasparFNL.InvokeMethod("clockShowHide");
        }

        private void ShowHideAddMin()
        {
            CasparFNL.InvokeMethod("ltimerShowHide");
        }

        private void ShowHideChange()
        {
            CasparFNL.InvokeMethod("changeShowHide");
        }

        private void SaveHalfNum()
        {
            CasparFNL.SendData("halfNum", Convert.ToString(NumberHalfTime));
        }

        private void UpdateColorTeams()
        {
            CasparFNL.SendData(new Dictionary<string, string>
            {
                {"team1Color", buttonColorTeamGuest.BackColor.ToArgb().ToString()},
                {"team2Color", buttonColorTeamHome.BackColor.ToArgb().ToString()}
            });
        }

        private void SaveAdditionalTime()
        {
            CasparFNL.SendData("overtime", Convert.ToString(numOvertime.Value));
        }

        public void UpdateView()
        {
            TablePlayersMainPresenter presenterTable = new TablePlayersMainPresenter();

            // Update tables.
            dataGridPlayersGuest.DataSource = presenterTable.GetViews(MatchId, PersonCategoryType.GuestTeam, false);
            dataGridPlayersPairsGuest.DataSource = presenterTable.GetViews(MatchId, PersonCategoryType.GuestTeam, true);
            dataGridPlayersHome.DataSource = presenterTable.GetViews(MatchId, PersonCategoryType.HomeTeam, false);
            dataGridPlayersPairsHome.DataSource = presenterTable.GetViews(MatchId, PersonCategoryType.HomeTeam, true);

            MainPresenter matchPresenter = new MainPresenter(this);
            matchPresenter.ShowView();

            // Caspar CG Data Update
            UpdateNameTeams();
        }

        private void BtnSetGameTime_Click(object sender, EventArgs e)
        {
            this.UpdateGameTime();
        }

        private void BtnTeam1MinusScore_Click(object sender, EventArgs e)
        {
            // Get score team.
            int currentScore = Convert.ToInt16(tBScoreTeam1.Text);

            // Update score.
            if (currentScore >= 0)
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
            // Get score team.
            int currentScore = Convert.ToInt16(tBScoreTeam2.Text);

            // Update score.
            if (currentScore >= 0)
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

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            buttonConnect.Enabled = false;

            CasparFNL.Connect(this.tbCasparServer.Text);
        }

        private void BtnClearGraphics_Click(object sender, EventArgs e)
        {
            CasparFNL.ClearGraphic();
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

        private void ClickButtonColorTeamGuest(object sender, EventArgs e)
        {
            buttonColorTeamGuest.BackColor = (new Color()).ChoseColorDialog();
            UpdateColorTeams();
        }

        private void ClickButtonColorTeamHome(object sender, EventArgs e)
        {
            buttonColorTeamHome.BackColor = (new Color()).ChoseColorDialog();
            UpdateColorTeams();
        }

        private void buttonMatch_Click(object sender, EventArgs e)
        {
            MatchForm matchesForm = new MatchForm(this);
            matchesForm.Show();
            matchesForm.FormClosing += (s, ev) =>
            {
                if (matchesForm.IsBtnOkClicked && this != null)
                {
                    MatchId = matchesForm.MatchId;
                    UpdateView();
                }
            };
        }

        private void checkBoxListPlayers_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxListPlayers.Enabled)
            {
                if (radioButtonGuest.Checked)
                {
                    UpdatePlayersCG(PersonCategoryType.GuestTeam, false);
                }
                else if (radioButtonHome.Checked)
                {
                    UpdatePlayersCG(PersonCategoryType.HomeTeam, false);
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
                    UpdatePlayersCG(PersonCategoryType.GuestTeam, true);
                }
                else if (radioButtonHome.Checked)
                {
                    UpdatePlayersCG(PersonCategoryType.HomeTeam, true);
                }
            }

            ShowHidePairsPlayers();
        }

        private void btnMinChangeGuest_Click(object sender, EventArgs e)
        {
        }

        private void btnAddChangeGuest_Click(object sender, EventArgs e)
        {
            MainPresenter presenter = new MainPresenter(this);
            presenter.Replacement(true);

            UpdateReplacementCG(true);
            ShowHideReplacementCG();

            UpdateView();
        }

        private void btnAddChangeHome_Click(object sender, EventArgs e)
        {
            MainPresenter presenter = new MainPresenter(this);
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
            UpdatePlayersCG(PersonCategoryType.FaceMatch);
            ShowHideOfficialFacesMatch();
        }

        private void ShowHideOfficialFacesMatch()
        {
            CasparFNL.InvokeMethod("OfficialFacesShowHide");
        }
    }

}
