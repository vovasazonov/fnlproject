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
        public int IdTeam { get => ((List<ITeamView>)(dataGridViewTeams.DataSource))[dataGridViewTeams.CurrentRow.Index].IdTeam; set => throw new NotImplementedException(); }
        public Color ColorTeam { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameTeamFull { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameTeamShort { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PathTeamLogo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TeamsForm()
        {
            InitializeComponent();
            UpdateTable();
        }
        public TeamsForm(SettingMatch settingMatch, bool isGuestSender)
        {
            InitializeComponent();
            UpdateTable();
            this._settingMatchForm = settingMatch;
            this._isGuestSender = isGuestSender;
        }

        private SettingMatch _settingMatchForm;
        private bool _isGuestSender;

        /// <summary>
        /// Update the data in gridView.
        /// </summary>
        public void UpdateTable()
        {
            TeamPresenter presenter = new TeamPresenter(this);
            // Set table with data from database.
            dataGridViewTeams.DataSource = presenter.GetViews();
            // Hide colum with ids.
            dataGridViewTeams.Columns[0].Visible = false;
        }

        private void buttonInsertTeam_Click(object sender, EventArgs e)
        {
            SettingTeam form = new SettingTeam(this);
            form.Show();
        }

        private void buttonDeleteTeam_Click(object sender, EventArgs e)
        {
            TeamPresenter presenter = new TeamPresenter(this);
            presenter.DeleteModelDB();

            UpdateTable();
        }

        private void buttonTeamOk_Click(object sender, EventArgs e)
        {
            TeamPresenter presenter = new TeamPresenter(this);
            string nameTeam = presenter.GetViews().Where(t => t.IdTeam == IdTeam).FirstOrDefault().NameTeamFull;

            if (_isGuestSender)
            {
                if (_settingMatchForm != null)
                {
                    _settingMatchForm.NameGuestTeam = nameTeam;
                    _settingMatchForm.GuestTeamId = IdTeam;
                }
            }
            else
            {
                if (_settingMatchForm != null)
                {
                    _settingMatchForm.NameOwnerTeam = nameTeam;
                    _settingMatchForm.OwnerTeamId = IdTeam;

                }
            }

            this.Close();
        }

        private void buttonTeamCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonChangeTeam_Click(object sender, EventArgs e)
        {
            SettingTeam form = new SettingTeam(this, true);
            form.Show();
        }
    }
}
