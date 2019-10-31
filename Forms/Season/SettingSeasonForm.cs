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
    public partial class SettingSeasonForm : Form, ISettingSeasonView
    {
        #region View variables.
        public int SeasonId { get; set; }
        public string SeasonName { get => textNameSeason.Text; set => textNameSeason.Text = value; }
        #endregion

        #region Class variables.
        private SeasonForm _seasonForm = null;
        private bool _isEdit = false;
        #endregion

        public SettingSeasonForm()
        {
            InitializeComponent();
        }

        public SettingSeasonForm(SeasonForm seasonForm, bool isEdit = false)
        {
            InitializeComponent();

            this._isEdit = isEdit;
            this._seasonForm = seasonForm;

            if (_isEdit)
            {
                SeasonId = _seasonForm.SeasonId;

                SettingSeasonPresenter presenter = new SettingSeasonPresenter(this);
                presenter.ShowModelInView();
            }
        }


        private void buttonSetSeasonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSetSeasonOk_Click(object sender, EventArgs e)
        {
            SettingSeasonPresenter presenter = new SettingSeasonPresenter(this);

            if (_isEdit)
            {
                presenter.UpdateModelDB();
            }
            else
            {
                presenter.InsertModelDB();
            }

            if (_seasonForm != null)
            {
                _seasonForm.UpdateTable();
            }

            this.Close();
        }
    }
}
