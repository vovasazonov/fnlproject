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
    public partial class SeasonForm : Form, ISeasonView
    {
        public int SeasonId { get => ((List<ISeasonView>)(dataGridViewSeasons.DataSource))[dataGridViewSeasons.CurrentRow.Index].SeasonId; set => throw new NotImplementedException(); }
        public string SeasonName { get => ((List<ISeasonView>)(dataGridViewSeasons.DataSource))[dataGridViewSeasons.CurrentRow.Index].SeasonName; set => throw new NotImplementedException(); }
        public SeasonForm()
        {
            InitializeComponent();
        }
        public SeasonForm(SettingMatch settingMatchForm)
        {
            InitializeComponent();

            _settingMatchForm = settingMatchForm;

            UpdateTable();
        }

        private SettingMatch _settingMatchForm;

        /// <summary>
        /// Update the data in gridView.
        /// </summary>
        public void UpdateTable()
        {
            SeasonPresenter presenter = new SeasonPresenter(this);
            // Set table with data from database.
            dataGridViewSeasons.DataSource = presenter.GetViews();
            // Hide colum with ids.
            dataGridViewSeasons.Columns[0].Visible = false;
        }

        private void buttonInsertSeason_Click(object sender, EventArgs e)
        {
            SettingSeason form = new SettingSeason(this);
            form.Show();
        }

        private void buttonChangeSeason_Click(object sender, EventArgs e)
        {
            SettingSeason form = new SettingSeason(this, true);
            form.Show();
        }

        private void buttonDeleteSeason_Click(object sender, EventArgs e)
        {
            SeasonPresenter presenter = new SeasonPresenter(this);
            presenter.DeleteModelDB();

            UpdateTable();
        }

        private void buttonSeasonOk_Click(object sender, EventArgs e)
        {
            _settingMatchForm.SeasonId = SeasonId;
            _settingMatchForm.NameSeason = SeasonName;

            this.Close();
        }

        private void buttonSeasonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
