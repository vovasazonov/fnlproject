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
        MatchesForm matchesForm = new MatchesForm();
        bool isEdit = false;
        int idMatch = -1;
        //IMatchView matchView;

        public string NameMatch { get => textNameMatch.Text; set => textNameMatch.Text = value; }
        public string NameStadium { get => comboStadium.Text; set => comboStadium.Text = value; }
        public string NameGuestTeam { get => comboGuest.Text; set => comboGuest.Text = value; }
        public string NameOwnerTeam{ get => comboOwner.Text; set => comboOwner.Text = value; }
        public string NameSeason { get => comboSeason.Text; set => comboSeason.Text = value; }
        public DateTime DateTime { get => dateTimeMatch.Value; set => dateTimeMatch.Value = value; }
        public string NameCommentator1 { get => comboCommentator1.Text; set => comboCommentator1.Text = value; }
        public string NameCommentator2 { get => comboCommentator2.Text; set => comboCommentator2.Text = value; }

        //public SettingMatch()
        //{
        //    InitializeComponent();
        //    isEdit = false;
        //}

        public SettingMatch(MatchesForm matchesForm, bool isEdit = false, int idMatch = -1)
        {
            InitializeComponent();

            this.isEdit = isEdit;
            this.matchesForm = matchesForm;
            this.idMatch = idMatch;
            
            if (isEdit)
            {
                SettingMatchPresenter settingMatchPresenter = new SettingMatchPresenter(this);
                settingMatchPresenter.ShowMatchInView(this.idMatch);
            }
        }

        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SettingMatchPresenter settingMatchPresenter = new SettingMatchPresenter(this);

            if (isEdit)
            {
                //settingMatchPresenter.UpdateMatch(idMatch);
            }
            else
            {
                settingMatchPresenter.InsertMatch();
            }

            matchesForm.UpdateTable();

            this.Close();
        }

        private void comboGuest_Click(object sender, EventArgs e)
        {
            TeamsForm teamsForm = new TeamsForm(this, true);
            teamsForm.Show();
        }

        private void comboOwner_Click(object sender, EventArgs e)
        {
            TeamsForm teamsForm = new TeamsForm(this, false);
            teamsForm.Show();
        }
    }
}
