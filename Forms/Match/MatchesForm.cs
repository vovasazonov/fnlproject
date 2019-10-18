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
	public partial class MatchesForm : Form, IMatchView
	{
        public int MatchId { get => ((List<IMatchView>)(dataGridViewMatch.DataSource))[dataGridViewMatch.CurrentRow.Index].MatchId; set => throw new NotImplementedException(); }
        public string NameMatch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameStadium { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameSeason { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameTeamGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int GoalsGuest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameTeamOwner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int GoalsOwner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CommentatorsMatch1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CommentatorsMatch2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MatchesForm()
		{
			InitializeComponent();

            UpdateTable();
        }

        public MatchesForm(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;

            UpdateTable();
        }

        private MainForm _mainForm;

        public void UpdateTable()
        {
            MatchPresenter presenter = new MatchPresenter(this);
            // Set table with data from database.
            dataGridViewMatch.DataSource = presenter.GetView();
            // Hide colum with ids.
            dataGridViewMatch.Columns[0].Visible = false;
        }
        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonInsertMatch_Click(object sender, EventArgs e)
        {
            SettingMatch form = new SettingMatch(this);
            form.Show();           
        }

        private void buttonChangeMatch_Click(object sender, EventArgs e)
        {           
            SettingMatch form = new SettingMatch(this,true);
            form.Show();
        }

        private void buttonDeleteMatch_Click(object sender, EventArgs e)
        {
            MatchPresenter presenter = new MatchPresenter(this);
            presenter.DelteModelDB();

            UpdateTable();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _mainForm.MatchId = MatchId;
            _mainForm.UpdateView();
        }

        private void buttonPlayersMatch_Click(object sender, EventArgs e)
        {
            MatchPlayers matchPlayersForm = new MatchPlayers(this);
            matchPlayersForm.Show();
        }
    }
}
