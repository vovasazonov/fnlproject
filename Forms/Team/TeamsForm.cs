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
using FNL.Presenters;
using FNL.Views;

namespace FNL.Forms
{
    public partial class TeamsForm : Form, ITeamView
    {
        
        public TeamsForm()
        {
            InitializeComponent();
            UpdateTable();
        }
        public TeamsForm(SettingMatch settingMatch, bool isGuestSender)
        {
            InitializeComponent();
            UpdateTable();
            this._settingMatch = settingMatch;
            this._isGuestSender = isGuestSender;
        }

        private SettingMatch _settingMatch;
        private bool _isGuestSender;

        public Color ColorTeam { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameTeamFull { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameTeamShort { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PathTeamLogo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IdTeam { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void UpdateTable()
        {
            TeamPresenter newTeam = new TeamPresenter(this);
            dataGridViewTeams.DataSource = newTeam.GetTeams();
        }

        private void buttonInsertTeam_Click(object sender, EventArgs e)
        {
            SettingTeam settingTeamForm = new SettingTeam(this);
            settingTeamForm.Show();
        }

        private void buttonDeleteTeam_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(dataGridViewTeams.CurrentRow.Cells[0].Value);

                TeamPresenter team = new TeamPresenter(this);
                team.DeleteTeamFromDatabase(id);
                dataGridViewTeams.DataSource = team.GetTeams();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void buttonTeamOk_Click(object sender, EventArgs e)
        {
            int id = 0;

            id = Convert.ToInt32(dataGridViewTeams.CurrentRow.Cells[0].Value);

            TeamPresenter team = new TeamPresenter(this);
            string nameTeam = (from t in team.GetTeams()
                                where t.IdTeam == id
                                select t).
                                FirstOrDefault().NameTeamFull;
            if (_isGuestSender)
            {
                _settingMatch.NameGuestTeam = nameTeam;
            }
            else
            {
                _settingMatch.NameOwnerTeam = nameTeam;
            }

            this.Close();
        }

        private void buttonTeamCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
