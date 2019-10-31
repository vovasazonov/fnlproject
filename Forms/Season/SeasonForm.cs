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
        #region View variables.
        public int SeasonId
        {
            get
            {
                var dataSource = (List<ISeasonView>)(dataGridViewSeasons.DataSource);
                var currentRow = dataGridViewSeasons.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].SeasonId : -1;
            }
            set
            {

            }
        }
        public string SeasonName
        {
            get
            {
                var dataSource = (List<ISeasonView>)(dataGridViewSeasons.DataSource);
                var currentRow = dataGridViewSeasons.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].SeasonName : "";
            }
            set
            {

            }
        }
        #endregion

        #region Class variables.
        private SettingMatchForm _settingMatchForm = null;
        #endregion

        public SeasonForm()
        {
            InitializeComponent();
        }

        public SeasonForm(SettingMatchForm settingMatchForm)
        {
            InitializeComponent();

            _settingMatchForm = settingMatchForm;

            UpdateTable();
        }

        /// <summary>
        /// Update the data in gridView.
        /// </summary>
        internal void UpdateTable()
        {
            SeasonPresenter presenter = new SeasonPresenter(this);
            // Set table with data from database.
            dataGridViewSeasons.DataSource = presenter.GetViews();
        }

        private void buttonInsertSeason_Click(object sender, EventArgs e)
        {
            SettingSeasonForm form = new SettingSeasonForm(this);
            form.Show();
        }

        private void buttonChangeSeason_Click(object sender, EventArgs e)
        {
            SettingSeasonForm form = new SettingSeasonForm(this, true);
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
            if (_settingMatchForm != null)
            {
                _settingMatchForm.NameSeason = SeasonName;
                _settingMatchForm.SeasonId = SeasonId;
            }

            this.Close();
        }

        private void buttonSeasonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
