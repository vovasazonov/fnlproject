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
    public partial class SettingStadium : Form, ISettingStadiumView
    {
        #region View variables.
        public int StadiumId { get; set; }
        public string StadiumName { get => textNameStadium.Text; set => textNameStadium.Text = value; }
        public string CountryName { get => textCountryName.Text; set => textCountryName.Text = value; }
        public string CityName { get => textCityName.Text; set => textCityName.Text = value; }
        #endregion

        #region Class variables.
        private StadiumForm _stadiumForm = null;
        private bool _isEdit = false;
        internal bool IsBtnOkClicked { get => _isBtnOkClicked; private set => _isBtnOkClicked = value; }

        private bool _isBtnOkClicked = false;
        #endregion

        public SettingStadium()
        {
            InitializeComponent();
        }

        public SettingStadium(StadiumForm stadiumForm, bool isEdit = false)
        {
            InitializeComponent();

            this._isEdit = isEdit;
            this._stadiumForm = stadiumForm;

            if (_isEdit)
            {
                StadiumId = _stadiumForm.StadiumId;

                SettingStadiumPresenter presenter = new SettingStadiumPresenter(this);
                presenter.ShowModelInView();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SettingStadiumPresenter presenter = new SettingStadiumPresenter(this);

            if (_isEdit)
            {
                if (!presenter.UpdateModelDB()) MessageBoxFNL.MessageErrorDb();
            }
            else
            {
                if (!presenter.InsertModelDB()) MessageBoxFNL.MessageErrorDb();
            }

            _isBtnOkClicked = true;

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
