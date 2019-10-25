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
    public partial class SettingSeason : Form, ISettingSeasonView
    {
        public int SeasonId { get; set; }
        public string SeasonName { get => textNameSeason.Text; set => textNameSeason.Text = value; }

        public SettingSeason()
        {
            InitializeComponent();
        }

        public SettingSeason(SeasonForm seasonForm, bool isEdit = false)
        {
            InitializeComponent();

            this._isEdit = isEdit;
            this._seasonForm = seasonForm;

            if (_isEdit)
            {
                SettingSeasonPresenter presenter = new SettingSeasonPresenter(this);
                SeasonId = _seasonForm.SeasonId;
                presenter.ShowModelInView();
            }
        }

        private SeasonForm _seasonForm;
        private bool _isEdit;


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
