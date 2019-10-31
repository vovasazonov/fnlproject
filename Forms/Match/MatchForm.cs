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
        public string NameMatch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameStadium { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameSeason { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameTeamGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int GoalsGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameTeamHome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int GoalsOwner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Commentators1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Commentators2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string MainJudje { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string HelperJudje1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string HelperJudje2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PairJudje { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Inspector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Delegat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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


        internal void UpdateTable()
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
        }

        private void buttonChangeMatch_Click(object sender, EventArgs e)
        {
            SettingMatchForm form = new SettingMatchForm(this, true);
            form.Show();
        }

        private void buttonDeleteMatch_Click(object sender, EventArgs e)
        {
            MatchPresenter presenter = new MatchPresenter(this);
            presenter.DeleteModelDB();

            UpdateTable();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (_mainForm != null)
            {
                _mainForm.MatchId = MatchId;
                _mainForm.UpdateView();
            }

            this.Close();
        }

        private void buttonPlayersMatch_Click(object sender, EventArgs e)
        {
            MatchPlayersForm matchPlayersForm = new MatchPlayersForm(this);
            matchPlayersForm.Show();
        }
    }
}
