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
        public int MatchId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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

        public void UpdateTable()
        {
            MatchPresenter newMatch = new MatchPresenter(this);
            dataGridViewMatch.DataSource = newMatch.GetMatches();
        }
        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonInsertMatch_Click(object sender, EventArgs e)
        {
            SettingMatch settingMatchForm = new SettingMatch(this);
            settingMatchForm.Show();
            
        }

        private void buttonChangeMatch_Click(object sender, EventArgs e)
        {
            List<IMatchView> md = (List<IMatchView>)dataGridViewMatch.DataSource;
            var query = from m in md
                        where m.MatchId == Convert.ToInt32(dataGridViewMatch.CurrentRow.Cells[0].Value)
                        select m;
            int idMatch = query.FirstOrDefault().MatchId;
            
            SettingMatch settingMatchForm = new SettingMatch(this,true,idMatch);
            settingMatchForm.Show();
        }

        private void buttonDeleteMatch_Click(object sender, EventArgs e)
        {
            int idMatch = 0;
            try
            {
                idMatch = Convert.ToInt32(dataGridViewMatch.CurrentRow.Cells[0].Value);             

                MatchPresenter match = new MatchPresenter(this);
                match.DeleteMatchFromDatabase(idMatch);
                dataGridViewMatch.DataSource = match.GetMatches();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

        }
    }
}
