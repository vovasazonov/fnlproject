using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FNL.Views;
using FNL.Presenters;

namespace FNL.Forms
{
    public partial class MatchForm : Form, IMatchView
    {
        #region View variables.
        public int MatchId
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].MatchId : -1;
            }
            set
            {

            }
        }
        public string NameMatch
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].NameMatch : "";
            }
            set
            {

            }
        }
        public DateTime Date
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].Date : new DateTime();
            }
            set
            {

            }
        }
        public string NameStadium
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].NameStadium : "";
            }
            set
            {

            }
        }
        public string NameSeason
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].NameSeason : "";
            }
            set
            {

            }
        }
        public string NameTeamGuest
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].NameTeamGuest : "";
            }
            set
            {

            }
        }
        public int GoalsGuest
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].GoalsGuest : -1;
            }
            set
            {

            }
        }
        public string NameTeamHome
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].NameTeamHome : "";
            }
            set
            {

            }
        }
        public int GoalsOwner
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].GoalsOwner : -1;
            }
            set
            {

            }
        }
        public string Commentators1
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].Commentators1 : "";
            }
            set
            {

            }
        }
        public string Commentators2
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].Commentators2 : "";
            }
            set
            {

            }
        }
        public string MainJudje
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].MainJudje : "";
            }
            set
            {

            }
        }
        public string HelperJudje1
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].HelperJudje1 : "";
            }
            set
            {

            }
        }
        public string HelperJudje2
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].HelperJudje2 : "";
            }
            set
            {

            }
        }
        public string PairJudje
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].PairJudje : "";
            }
            set
            {

            }
        }
        public string Inspector
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].Inspector :"";
            }
            set
            {

            }
        }
        public string Delegat
        {
            get
            {
                var dataSource = (List<IMatchView>)(dataGridViewMatch.DataSource);
                var currentRow = dataGridViewMatch.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].Delegat : "";
            }
            set
            {

            }
        }
        public int StadiumId { get; set; }
        public int GuestTeamId { get; set; }
        public int OwnerTeamId { get; set; }
        public int SeasonId { get; set; }
        public int Commentator1Id { get; set; }
        public int Commentator2Id { get; set; }
        public int MainJudjeId { get; set; }
        public int HelperJudje1Id { get; set; }
        public int HelperJudje2Id { get; set; }
        public int PairJudjeId { get; set; }
        public int InspectorId { get; set; }
        public int DelegatId { get; set; }
        #endregion

        #region Class variables.
        private MainForm _mainForm = null;
        internal bool IsBtnOkClicked { get => _isBtnOkClicked; set => _isBtnOkClicked = value; }
        private bool _isBtnOkClicked = false;
        #endregion

        public MatchForm()
        {
            InitializeComponent();

            UpdateTable();
        }

        public MatchForm(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;

            UpdateTable();
        }


        private void UpdateTable()
        {
            MatchPresenter presenter = new MatchPresenter(this);
            // Set table with data from database.
            dataGridViewMatch.DataSource = presenter.GetViews();
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonInsertMatch_Click(object sender, EventArgs e)
        {
            SettingMatchForm form = new SettingMatchForm(this);
            form.Show();
            form.FormClosing += (s, ev) =>
            {
                if (form.IsBtnOkClicked && this != null)
                {
                    UpdateTable();
                }
            };
        }

        private void buttonChangeMatch_Click(object sender, EventArgs e)
        {
            SettingMatchForm form = new SettingMatchForm(this, true);
            form.Show();
            form.FormClosing += (s, ev) =>
            {
                if (form.IsBtnOkClicked && this != null)
                {
                    UpdateTable();
                }
            };
        }

        private void buttonDeleteMatch_Click(object sender, EventArgs e)
        {
            MatchPresenter presenter = new MatchPresenter(this);
            presenter.DeleteModelDB();

            UpdateTable();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _isBtnOkClicked = true;

            this.Close();
        }

        private void buttonPlayersMatch_Click(object sender, EventArgs e)
        {
            MatchPlayersForm matchPlayersForm = new MatchPlayersForm(this);
            matchPlayersForm.Show();
        }
    }
}
