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
    public partial class SettingTeam : Form,ISettingTeamView, ITablePlayerTeamView
    {
        public int IdTeam { get; set; }
        public Color ColorTeam { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameTeamFull { get => textNameFullTeam.Text; set => textNameFullTeam.Text = value; }
        public string NameTeamShort { get => textNameShortTeam.Text; set => textNameShortTeam.Text = value; }
        public string PathTeamLogo { get => comboBoxPathLogo.Text; set => comboBoxPathLogo.Text = value; }
        public List<int> IdsPlayers { get; set; }

        public int IdPerson { get => ((List<ITablePlayerTeamView>)(dataGridViewPlayersTeam.DataSource))[dataGridViewPlayersTeam.CurrentRow.Index].IdPerson; set => throw new NotImplementedException(); }
        public int Number { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string MiddleName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Role { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Amplua { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SettingTeam()
        {
            InitializeComponent();
        }

        public SettingTeam(TeamsForm teamForm, bool isEdit = false)
        {
            InitializeComponent();

            this._isEdit = isEdit;
            this._teamForm = teamForm;

            if (_isEdit)
            {
                SettingTeamPresenter settingTeamPresenter = new SettingTeamPresenter(this);
                settingTeamPresenter.ShowTeamInView(IdTeam);
                UpdateTable();
            }
        }


        private TeamsForm _teamForm = new TeamsForm();
        private bool _isEdit = false;

        public void UpdateTable()
        {
            SettingTeamPresenter settingTeamPresenter = new SettingTeamPresenter(this);
            // Set table with data from database.
            dataGridViewPlayersTeam.DataSource = settingTeamPresenter.GetPlayersTeam();
            // Hide colum with ids.
            dataGridViewPlayersTeam.Columns[0].Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void buttonSetTeamOk_Click(object sender, EventArgs e)
        {
            SettingTeamPresenter settingTeamPresenter = new SettingTeamPresenter(this);

            if (_isEdit)
            {
                settingTeamPresenter.UpdateTeam();
            }
            else
            {
                settingTeamPresenter.InsertTeam();
            }

            _teamForm.UpdateTable();

            this.Close();
        }

        private void buttonAddPlayer_Click(object sender, EventArgs e)
        {
            SettingPlayerTeam form = new SettingPlayerTeam(this);
            form.Show();
        }

        private void buttonDeletePlayer_Click(object sender, EventArgs e)
        {
            SettingTeamPresenter presenter = new SettingTeamPresenter(this);
            presenter.DeletePlayerTeamFromDatabase(IdPerson);

            UpdateTable();
        }

        private void buttonChangePlayer_Click(object sender, EventArgs e)
        {
            SettingPlayerTeam form = new SettingPlayerTeam(this, true);
            form.Show();
        }
    }
}
