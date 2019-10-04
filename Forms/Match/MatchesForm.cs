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
		public MatchesForm()
		{
			InitializeComponent();

            UpdateTable();

        }
        public int MatchId { get; set; }
        public string NameMatch { get; set; }
        public DateTime Date { get; set; }
        public string NameStadium { get; set; }
        public string NameSeason { get; set; }
        public string NameTeamGuest { get; set; }
        public int GoalsGuest { get; set; }
        public string NameTeamOwner { get; set; }
        public int GoalsOwner { get; set; }
        public string CommentatorsMatch1 { get; set; }
        public string CommentatorsMatch2 { get; set; }

        public void UpdateTable()
        {
            MatchPresenter newMatch = new MatchPresenter(this);
            dataGridViewMatch.DataSource = newMatch.GetMatchesFromDatabase();
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonInsertMatch_Click(object sender, EventArgs e)
        {
            SettingMatch settingMatchForm = new SettingMatch();
            settingMatchForm.Show();
            
        }

        private void buttonChangeMatch_Click(object sender, EventArgs e)
        {
            //SettingMatch settingMatchForm = new SettingMatch(true);
        }

        private void buttonDeleteMatch_Click(object sender, EventArgs e)
        {

        }
    }
}
