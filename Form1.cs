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

        CasparDevice caspar_ = new CasparDevice();
        CasparCGDataCollection cgData = new CasparCGDataCollection();

        DataSet teamsDs = new DataSet();
        DataTable teamsDt = new DataTable("TEAMS");
        DataView team1Dv = new DataView();
        DataView team2Dv = new DataView();

        public Form1()
        {
            InitializeComponent();

            team1Dv.Table = teamsDt;
            team2Dv.Table = teamsDt;
            cb1Teams.DataSource = team1Dv;
            cb2Teams.DataSource = team2Dv;

            InitDatatable();
            FillDatatable();

            caspar_.Connected += new EventHandler<NetworkEventArgs>(caspar__Connected);
            caspar_.FailedConnect += new EventHandler<NetworkEventArgs>(caspar__FailedConnected);
            caspar_.Disconnected += new EventHandler<NetworkEventArgs>(caspar__Disconnected);

            this.btnLockTeams.Image = FNL.Properties.Resources.lock_unlock;
        }

        //caspar event - connected
        void caspar__Connected(object sender, NetworkEventArgs e)
        {
            if (InvokeRequired)
                BeginInvoke(new UpdateGUI(OnCasparConnected), e);
            else
                OnCasparConnected(e);
        }
        void OnCasparConnected(object param)
        {
            buttonConnect.Enabled = true;
            updateConnectButtonText();

            caspar_.RefreshMediafiles();
            caspar_.RefreshDatalist();

            NetworkEventArgs e = (NetworkEventArgs)param;
            statusStrip1.BackColor = Color.LightGreen;
            toolStripStatusLabel1.Text = "Connected to " + caspar_.Settings.Hostname; // Properties.Settings.Default.Hostname;

            enableControls();
        }

        private void disableControls()
        {
            tabControl1.Enabled = false;
        }

        private void enableControls()
        {
            tabControl1.Enabled = true;
        }

        //caspar event - failed connect
        void caspar__FailedConnected(object sender, NetworkEventArgs e)
        {
            if (InvokeRequired)
                BeginInvoke(new UpdateGUI(OnCasparFailedConnect), e);
            else
                OnCasparFailedConnect(e);
        }
        void OnCasparFailedConnect(object param)
        {
            buttonConnect.Enabled = true;
            updateConnectButtonText();

            NetworkEventArgs e = (NetworkEventArgs)param;
            statusStrip1.BackColor = Color.LightCoral;
            toolStripStatusLabel1.Text = "Failed to connect to " + caspar_.Settings.Hostname; // Properties.Settings.Default.Hostname;

            disableControls();
        }

        //caspar event - disconnected
        void caspar__Disconnected(object sender, NetworkEventArgs e)
        {
            if (InvokeRequired)
                BeginInvoke(new UpdateGUI(OnCasparDisconnected), e);
            else
                OnCasparDisconnected(e);
        }
        void OnCasparDisconnected(object param)
        {
            buttonConnect.Enabled = true;
            updateConnectButtonText();

            NetworkEventArgs e = (NetworkEventArgs)param;
            statusStrip1.BackColor = Color.LightCoral;
            toolStripStatusLabel1.Text = "Disconnected from " + caspar_.Settings.Hostname; // Properties.Settings.Default.Hostname;

            disableControls();
        }

        // update text on button
        private void updateConnectButtonText()
        {
            if (!caspar_.IsConnected)
            {
                buttonConnect.Text = "Connect";// to " + Properties.Settings.Default.Hostname;
            }
            else
            {
                buttonConnect.Text = "Disconnect"; // from " + Properties.Settings.Default.Hostname;
            }
        }

        private void BtnClearGraphics_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Clear on: " + Properties.Settings.Default.CasparChannel);
            try
            {
                this.caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Clear();
                this.caspar_.Channels[Properties.Settings.Default.CasparChannel].Clear();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            buttonConnect.Enabled = false;

            if (!caspar_.IsConnected)
            {
                caspar_.Settings.Hostname = this.tbCasparServer.Text; // Properties.Settings.Default.Hostname;
                caspar_.Settings.Port = 5250;
                caspar_.Connect();
            }
            else
            {
                caspar_.Disconnect();
            }
        }

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

        private void InitDatatable()
        {
            if (teamsDt.Columns.Count == 0)
            {
                teamsDt.Columns.Add("TeamNameAbbrevation");
                teamsDt.Columns[0].DataType = System.Type.GetType("System.String");
                teamsDt.Columns.Add("TeamNameFull");
                teamsDt.Columns[0].DataType = System.Type.GetType("System.String");
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
                    relation = teamsDt.NewRow();
                    relation.ItemArray = rowArray;
                    teamsDt.Rows.Add(relation);
                }
            }

        }

        private void BtnStartGraphics_Click(object sender, EventArgs e)
        {
            this.startClock();
        }

        private void BtnStopGraphics_Click(object sender, EventArgs e)
        {
            this.stopClock();
        }

        private void stopClock()
        {
            try
            {

            }
            catch
            {

            }
            finally
            {
                if (caspar_.IsConnected && caspar_.Channels.Count > 0)
                {
                    caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Stop(Properties.Settings.Default.GraphicsLayerClock);
                    System.Diagnostics.Debug.WriteLine("Stop");
                    System.Diagnostics.Debug.WriteLine(Properties.Settings.Default.GraphicsLayerClock);
                }
            }
        }

        private bool hasValidClockData()
        {
            return true;
        }

        private void startClock()
        {
            /*
             Check for valid field values
             */
            if (!this.hasValidClockData())
            {
                return;
            }


            try
            {
                // Clear old data
                cgData.Clear();

                // build data
                cgData.SetData("team1Name", cb1Teams.SelectedValue.ToString());
                cgData.SetData("team2Name", cb2Teams.SelectedValue.ToString());
                cgData.SetData("team1Score", tBScoreTeam1.Text);
                cgData.SetData("team2Score", tBScoreTeam2.Text);
                cgData.SetData("halfNum", Convert.ToString(numHalfNum.Value));
                cgData.SetData("gameTime", this.getGameTimeCGData());
            }
            catch
            {

            }
            finally
            {
                if (caspar_.IsConnected && caspar_.Channels.Count > 0)
                 {
                    caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Add(Properties.Settings.Default.GraphicsLayerClock, Properties.Settings.Default.TemplateNameClock, true, cgData);
                    System.Diagnostics.Debug.WriteLine("Add");
                    System.Diagnostics.Debug.WriteLine(Properties.Settings.Default.GraphicsLayerClock);
                    System.Diagnostics.Debug.WriteLine(Properties.Settings.Default.TemplateNameClock);
                    System.Diagnostics.Debug.WriteLine(cgData.ToXml());
                }
            }
        }

        private string getGameTimeCGData()
        {
            return tbTimeMin.Text + ":" + tbTimeSec.Text;
        }

        private void btnTeam1MinusScore_Click(object sender, EventArgs e)
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

        private void btnTeam1AddScore_Click(object sender, EventArgs e)
        {
            /// get score
            int currentScore = Convert.ToInt16(tBScoreTeam1.Text);

            /// update score
            currentScore++;
            tBScoreTeam1.Text = Convert.ToString(currentScore);

        }

        private void btnTeam2MinusScore_Click(object sender, EventArgs e)
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

        private void btnTeam2AddScore_Click(object sender, EventArgs e)
        {
            /// get score
            int currentScore = Convert.ToInt16(tBScoreTeam2.Text);

            /// update score
            currentScore++;
            tBScoreTeam2.Text = Convert.ToString(currentScore);
        }

        private void BtnShowMain_Click(object sender, EventArgs e)
        {
            this.showHideClock();
        }

        private void showHideClock()
        {
            try
            {

            }
            catch
            {

            }
            finally
            {
                if (caspar_.IsConnected && caspar_.Channels.Count > 0)
                {
                    caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Invoke(Properties.Settings.Default.GraphicsLayerClock, "clockShowHide");
                    System.Diagnostics.Debug.WriteLine("Invoke");
                    System.Diagnostics.Debug.WriteLine("clockShowHide");
                }
            }
        }
    }

}
