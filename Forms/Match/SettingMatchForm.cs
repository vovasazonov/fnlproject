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
using FNL.Views;
using FNL.Presenters;

namespace FNL.Forms
{
    public partial class SettingMatchForm : Form, ISettingMatchView
    {
        #region View variables.
        public string NameMatch { get => textNameMatch.Text; set => textNameMatch.Text = value; }
        public string NameStadium { get => comboStadium.Text; set => comboStadium.Text = value; }
        public string NameTeamGuest { get => comboGuest.Text; set => comboGuest.Text = value; }
        public string NameTeamHome { get => comboOwner.Text; set => comboOwner.Text = value; }
        public string NameSeason { get => comboSeason.Text; set => comboSeason.Text = value; }
        public DateTime Date { get => dateTimeMatch.Value; set => dateTimeMatch.Value = value; }
        public string Commentators1 { get => comboCommentator1.Text; set => comboCommentator1.Text = value; }
        public string Commentators2 { get => comboCommentator2.Text; set => comboCommentator2.Text = value; }
        public int GoalsGuest { get; set; }
        public int GoalsOwner { get; set; }
        public string MainJudje { get => comboMainJudje.Text; set => comboMainJudje.Text = value; }
        public string HelperJudje1 { get => comboHelperJudje1.Text; set => comboHelperJudje1.Text = value; }
        public string HelperJudje2 { get => comboHelperJudje2.Text; set => comboHelperJudje2.Text = value; }
        public string PairJudje { get => comboPairJudje.Text; set => comboPairJudje.Text = value; }
        public string Inspector { get => comboInspector.Text; set => comboInspector.Text = value; }
        public string Delegat { get => comboDelegat.Text; set => comboDelegat.Text = value; }
        public int MatchId { get; set; }
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
        public int StadiumId { get; set; }
        #endregion

        #region Class variables.
        private MatchForm _matchesForm = new MatchForm();
        private bool _isEdit = false;
        #endregion

        public SettingMatchForm(MatchForm matchesForm, bool isEdit = false)
        {
            InitializeComponent();

            this._isEdit = isEdit;
            this._matchesForm = matchesForm;

            if (_isEdit)
            {
                MatchId = _matchesForm.MatchId;

                SettingMatchPresenter presenter = new SettingMatchPresenter(this);
                presenter.SetModelToView();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SettingMatchPresenter presenter = new SettingMatchPresenter(this);

            if (_isEdit)
            {
                presenter.UpdateModelDB();
            }
            else
            {
                presenter.InserModelDB();
            }

            if (_matchesForm != null)
            {
                _matchesForm.UpdateTable();
            }

            this.Close();
        }

        private void comboGuest_Click(object sender, EventArgs e)
        {
            TeamForm form = new TeamForm(this, true);
            form.Show();
        }

        private void comboOwner_Click(object sender, EventArgs e)
        {
            TeamForm form = new TeamForm(this, false);
            form.Show();
        }

        private void comboStadium_Click(object sender, EventArgs e)
        {

        }

        private void comboSeason_Click(object sender, EventArgs e)
        {
            SeasonForm form = new SeasonForm(this);
            form.Show();
        }
    }
}
