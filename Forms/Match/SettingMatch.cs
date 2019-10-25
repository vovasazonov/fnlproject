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
    public partial class SettingMatch : Form, ISettingMatchView
    {
        #region View
        public string NameMatch { get => textNameMatch.Text; set => textNameMatch.Text = value; }
        public string NameStadium { get => comboStadium.Text; set => comboStadium.Text = value; }
        public string NameGuestTeam { get => comboGuest.Text; set => comboGuest.Text = value; }
        public string NameOwnerTeam { get => comboOwner.Text; set => comboOwner.Text = value; }
        public string NameSeason { get => comboSeason.Text; set => comboSeason.Text = value; }
        public DateTime DateTime { get => dateTimeMatch.Value; set => dateTimeMatch.Value = value; }
        public string NameCommentator1 { get => comboCommentator1.Text; set => comboCommentator1.Text = value; }
        public string NameCommentator2 { get => comboCommentator2.Text; set => comboCommentator2.Text = value; }

        public int ?MatchId { get; set; }
        public int ?StadiumId{get;set;}
        public int ?GuestTeamId{get;set;}
        public int ?OwnerTeamId{get;set;}
        public int ?SeasonId{get;set;}
        public int ?CommentatorPerson1Id{get;set;}
        public int ?CommentatorPerson2Id{get;set;}
        #endregion

        private MatchesForm _matchesForm = new MatchesForm();
        private bool _isEdit = false;

        public SettingMatch(MatchesForm matchesForm, bool isEdit = false)
        {
            InitializeComponent();

            this._isEdit = isEdit;
            this._matchesForm = matchesForm;

            if (_isEdit)
            {
                SettingMatchPresenter presenter = new SettingMatchPresenter(this);
                presenter.ShowModelInView(_matchesForm.MatchId);
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

            _matchesForm.UpdateTable();

            this.Close();
        }

        private void comboGuest_Click(object sender, EventArgs e)
        {
            TeamsForm form = new TeamsForm(this, true);
            form.Show();
        }

        private void comboOwner_Click(object sender, EventArgs e)
        {
            TeamsForm form = new TeamsForm(this, false);
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
