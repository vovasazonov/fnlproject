/*  Файл окна интерфейса.
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */
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
        public string StadiumName { get; set; }
        public string GoalsGuest { get => textGoalsGuest.Text; set => textGoalsGuest.Text = value; }
        public string TotalShotGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ShotTargetGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CornerGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string OffsideGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PassGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string AccuratePassGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FoulGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string YellowTicketGuest { get => textYellowTicketGuest.Text; set => textYellowTicketGuest.Text = value; }
        public string RedTicketGuest { get => textRedTicketGuest.Text; set => textRedTicketGuest.Text = value; }
        public string ChangeGuest { get => textChangeGuest.Text; set => textChangeGuest.Text = value; }
        public string GoalsHome { get => textGoalsHome.Text; set => textGoalsHome.Text = value; }
        public string TotalShotHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ShotTargetHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CornerHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string OffsideHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PassHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string AccuratePassHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FoulHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string YellowTicketHome { get => textYellowTicketHome.Text; set => textYellowTicketHome.Text = value; }
        public string RedTicketHome { get => textRedTicketHome.Text; set => textRedTicketHome.Text = value; }
        public string ChangeHome { get => textChangeHome.Text; set => textChangeHome.Text = value; }
        public string NameMainJudje { get; set; }
        public string NameHelperJudje1 { get; set; }
        public string NameHelperJudje2 { get; set; }
        public string NamePairJudje { get; set; }
        public string NameInsepcotor { get; set; }
        public string NameDelegat { get; set; }
        public string CityMainJudje { get; set; }
        public string CityHelperJudje1 { get; set; }
        public string CityHelperJudje2 { get; set; }
        public string CityPairJudje { get; set; }
        public string CityInsepcotor { get; set; }
        public string CityDelegat { get; set; }
        public string NameCommentator1 { get; set; }
        public string NameCommentator2 { get; set; }
        public string CityCommentator1 { get; set; }
        public string CityCommentator2 { get; set; }
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
            toolStripStatusLabel1.Text = "Соединен к серверу: " + CasparFNL.Device.Settings.Hostname;

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
            toolStripStatusLabel1.Text = "Не удалось соединиться с сервером: " + CasparFNL.Device.Settings.Hostname;

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
            toolStripStatusLabel1.Text = "Отсоединен от сервера: " + CasparFNL.Device.Settings.Hostname;

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
            presenter.ShowViewEvents();
        }

        private void DisableControls()
        {
            //tabControl1.Enabled = false;
        }

        private void EnableControls()
        {
            tabControl1.Enabled = true;
        }

        private void UpdateConnectButtonText()
        {
            if (!CasparFNL.Device.IsConnected)
            {
                buttonConnect.Text = "Соединить";
            }
            else
            {
                buttonConnect.Text = "Отсоединить";
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
                logoPath = System.IO.Path.GetFullPath(@"Resources\LogoFNL.png");
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
                (isPairs ? "ЗАПАСНЫЕ" : "СТАРТОВЫЙ СОСТАВ"));

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
                for (int i = 0; i < 12; i++)
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

            dicCasparData.Add("nameMainJudje", isFace ? NameMainJudje : "");
            dicCasparData.Add("nameHelperJudje1", isFace ? NameHelperJudje1 : "");
            dicCasparData.Add("nameHelperJudje2", isFace ? NameHelperJudje2 : "");
            dicCasparData.Add("namePairJudje", isFace ? NamePairJudje : "");
            dicCasparData.Add("nameInsepcotor", isFace ? NameInsepcotor : "");
            dicCasparData.Add("nameDelegat", isFace ? NameDelegat : "");

            dicCasparData.Add("cityMainJudje", isFace ? CityMainJudje : "");
            dicCasparData.Add("cityHelperJudje1", isFace ? CityHelperJudje1 : "");
            dicCasparData.Add("cityHelperJudje2", isFace ? CityHelperJudje2 : "");
            dicCasparData.Add("cityPairJudje", isFace ? CityPairJudje : "");
            dicCasparData.Add("cityInsepcotor", isFace ? CityInsepcotor : "");
            dicCasparData.Add("cityDelegat", isFace ? CityDelegat : "");

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
            // Get current score team home.
            int currentScore = Convert.ToInt16(tBScoreTeam2.Text);

            // Update score team home.
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
            ShowHideEventCG(EventMatchType.Replacement);

            UpdateView();
        }

        private void btnAddChangeHome_Click(object sender, EventArgs e)
        {
            MainPresenter presenter = new MainPresenter(this);
            presenter.Replacement(false);

            UpdateReplacementCG(false);
            ShowHideEventCG(EventMatchType.Replacement);

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

        /// <summary>
        /// Update the player name on clock.
        /// </summary>
        /// <param name="isGuest"></param>
        /// <param name="isRedCard"></param>
        private void UpdatePlayerBackRoundCG(bool isGuest)
        {
            MainPresenter presenter = new MainPresenter(this);

            ITablePlayersMainView player = null;

            if (isGuest)
            {
                player = ((List<ITablePlayersMainView>)dataGridPlayersGuest.DataSource)[dataGridPlayersGuest.CurrentRow.Index];
            }
            else
            {
                player = ((List<ITablePlayersMainView>)dataGridPlayersHome.DataSource)[dataGridPlayersHome.CurrentRow.Index];
            }

            CasparFNL.SendData(new Dictionary<string, string>()
            {
                {"isRightTeam", isGuest?"0":"1"},   // Guest in left place.
                {"namePlayerBackround", string.Format("{0} {1}", player.FirstName, player.LastName)},
            });
        }

        private void ShowHideEventCG(EventMatchType emType)
        {
            DialogResult result = MessageBox.Show(
                "Показать событие в эфир?",
                "Показ события",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                switch (emType)
                {
                    case EventMatchType.Replacement:
                        CasparFNL.InvokeMethod("ReplacementShowHide");
                        break;
                    case EventMatchType.YellowCard:
                        CasparFNL.InvokeMethod("RepYellowCardShowHide");
                        break;
                    case EventMatchType.RedCard:
                        CasparFNL.InvokeMethod("RepRedCardShowHide");
                        break;
                    case EventMatchType.Goal:
                        CasparFNL.InvokeMethod("RepGoalShowHide");
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnAddRedTicketGuest_Click(object sender, EventArgs e)
        {
            bool isGuest = true;

            MainPresenter presenter = new MainPresenter(this);
            presenter.AddEventToDb(isGuest,EventMatchType.RedCard);

            UpdatePlayerBackRoundCG(isGuest);

            CasparFNL.SendData(new Dictionary<string, string>()
            {
                {"eventNameLine", "Удаление"},
                {"eventValueLine", ""},
            });

            ShowHideEventCG(EventMatchType.RedCard);

            presenter.ShowViewEvents();
        }

        private void btnAddRedTicketHome_Click(object sender, EventArgs e)
        {
            bool isGuest = false;

            MainPresenter presenter = new MainPresenter(this);
            presenter.AddEventToDb(isGuest,EventMatchType.RedCard);

            UpdatePlayerBackRoundCG(isGuest);

            CasparFNL.SendData(new Dictionary<string, string>()
            {
                {"eventNameLine", "Удаление"},
                {"eventValueLine", ""},
            });

            ShowHideEventCG(EventMatchType.RedCard);

            presenter.ShowViewEvents();
        }

        private void btnAddYellowTicketGuest_Click(object sender, EventArgs e)
        {
            bool isGuest = true;

            MainPresenter presenter = new MainPresenter(this);
            presenter.AddEventToDb(isGuest,EventMatchType.YellowCard);

            UpdatePlayerBackRoundCG(isGuest);

            CasparFNL.SendData(new Dictionary<string, string>()
            {
                {"eventNameLine", "Предупреждение"},
                {"eventValueLine", ""},
                {"secondEventNameLine", "в сезоне"},
                {"secondsEventValueLine", string.Format("{0}",presenter.GetEventInSeason(GuestPlayerId,EventMatchType.YellowCard))},
            });

            ShowHideEventCG(EventMatchType.YellowCard);

            presenter.ShowViewEvents();
        }

        private void btnAddYellowTicketHome_Click(object sender, EventArgs e)
        {
            bool isGuest = false;

            MainPresenter presenter = new MainPresenter(this);
            presenter.AddEventToDb(isGuest,EventMatchType.YellowCard);

            UpdatePlayerBackRoundCG(isGuest);

            CasparFNL.SendData(new Dictionary<string, string>()
            {
                {"eventNameLine", "Предупреждение"},
                {"eventValueLine", ""},
                {"secondEventNameLine", "в сезоне"},
                {"secondsEventValueLine", string.Format("{0}",presenter.GetEventInSeason(HomePlayerId,EventMatchType.YellowCard))},
            });

            ShowHideEventCG(EventMatchType.YellowCard);

            presenter.ShowViewEvents();
        }

        private void btnAddGoalGuest_Click(object sender, EventArgs e)
        {
            bool isGuest = true;

            MainPresenter presenter = new MainPresenter(this);
            presenter.AddEventToDb(isGuest,EventMatchType.Goal);

            UpdatePlayerBackRoundCG(isGuest);

            CasparFNL.SendData(new Dictionary<string, string>()
            {
                {"eventNameLine", "Гол"},
                {"eventValueLine", "1"},
                {"secondEventNameLine", "в сезоне"},
                {"secondsEventValueLine", string.Format("{0}",presenter.GetEventInSeason(GuestPlayerId,EventMatchType.Goal))},
            });

            ShowHideEventCG(EventMatchType.Goal);

            presenter.ShowViewEvents();
        }

        private void btnAddGoalHome_Click(object sender, EventArgs e)
        {
            bool isGuest = false;

            MainPresenter presenter = new MainPresenter(this);
            presenter.AddEventToDb(isGuest, EventMatchType.Goal);

            UpdatePlayerBackRoundCG(isGuest);

            CasparFNL.SendData(new Dictionary<string, string>()
            {
                {"eventNameLine", "Гол"},
                {"eventValueLine", "1"},
                {"secondEventNameLine", "в сезоне"},
                {"secondsEventValueLine", string.Format("{0}",presenter.GetEventInSeason(HomePlayerId,EventMatchType.Goal))},
            });

            ShowHideEventCG(EventMatchType.Goal);

            presenter.ShowViewEvents();
        }

        private void checkBoxGuestClockRedCard1_CheckedChanged(object sender, EventArgs e)
        {
            CasparFNL.InvokeMethod("RedCard1LeftOnClockShowHide");
        }

        private void checkBoxHomeClockRedCard1_CheckedChanged(object sender, EventArgs e)
        {
            CasparFNL.InvokeMethod("RedCard1RightOnClockShowHide");
        }

        private void checkBoxWelWin_CheckedChanged(object sender, EventArgs e)
        {
            MainPresenter presenter = new MainPresenter(this);

            DateTime date = dtpDateWelWin.Value;
            DateTime time = dtpTimeWelWin.Value;

            //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("ru-RU");
            string valueTime = string.Format("{0}:{1}", time.Hour.ToString("00"), time.Minute.ToString("00"));
            string valueData = string.Format("{0} {1} {2}    {3}", date.Day, DictionaryMonths.GetNameMonth(date.Month), date.Year, valueTime);

            CasparFNL.SendData(new Dictionary<string, string>()
            {
                {"seasonName", SeasonName },
                {"dateTimeTitle", valueData},
                {"nameStadium", StadiumName },
                {"leftNameTeamWelWin", presenter.GetFullNameTeam(true)},
                {"rightNameTeamWelWin", presenter.GetFullNameTeam(false)},
                {"logoTeamLeftWelWinPath", presenter.GetLogoPathTeam(true)},
                {"logoTeamRightWelWinPath", presenter.GetLogoPathTeam(false)},
            });

            CasparFNL.InvokeMethod("WelWinShowHide");
        }

        private void btnMinRedTicketGuest_Click(object sender, EventArgs e)
        {
            bool isGuest = true;

            MainPresenter presenter = new MainPresenter(this);
            presenter.MinEventSeasonDb(isGuest, EventMatchType.RedCard);

            presenter.ShowViewEvents();
        }

        private void btnMinRedTicketHome_Click(object sender, EventArgs e)
        {
            bool isGuest = true;

            MainPresenter presenter = new MainPresenter(this);
            presenter.MinEventSeasonDb(isGuest, EventMatchType.RedCard);

            presenter.ShowViewEvents();
        }

        private void btnMinYellowTicketGuest_Click(object sender, EventArgs e)
        {
            bool isGuest = true;

            MainPresenter presenter = new MainPresenter(this);
            presenter.MinEventSeasonDb(isGuest, EventMatchType.YellowCard);

            presenter.ShowViewEvents();
        }

        private void btnMinYellowTicketHome_Click(object sender, EventArgs e)
        {
            bool isGuest = false;

            MainPresenter presenter = new MainPresenter(this);
            presenter.MinEventSeasonDb(isGuest, EventMatchType.YellowCard);

            presenter.ShowViewEvents();
        }

        private void btnMinGoalGuest_Click(object sender, EventArgs e)
        {
            bool isGuest = true;

            MainPresenter presenter = new MainPresenter(this);
            presenter.MinEventSeasonDb(isGuest, EventMatchType.Goal);

            presenter.ShowViewEvents();
        }

        private void btnMinGoalHome_Click(object sender, EventArgs e)
        {
            bool isGuest = false;

            MainPresenter presenter = new MainPresenter(this);
            presenter.MinEventSeasonDb(isGuest,EventMatchType.Goal);

            presenter.ShowViewEvents();
        }

        private void btnPeopleDBSetting_Click(object sender, EventArgs e)
        {
            PersonForm form = new PersonForm();
            form.Show();
        }

        private void btnStadiumsDBSetting_Click(object sender, EventArgs e)
        {
            StadiumForm form = new StadiumForm();
            form.Show();
        }

        private void btnSeasonsDBSetting_Click(object sender, EventArgs e)
        {
            SeasonForm form = new SeasonForm();
            form.Show();
        }

        private void btnTeamsDBSetting_Click(object sender, EventArgs e)
        {
            TeamForm form = new TeamForm();
            form.Show();
        }
    }

}
