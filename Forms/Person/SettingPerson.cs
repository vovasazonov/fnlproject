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
using FNL.Views;
using FNL.Presenters;

namespace FNL.Forms
{
    public partial class SettingPerson : Form, ISettingPersonView
    {

        private PersonForm _perosnForm = new PersonForm();
        private bool _isEdit = false;


        public int IdPerson { get; set; }
        public string FirstName { get => textFirstNamePerson.Text; set => textFirstNamePerson.Text = value; }
        public string LastName { get => textLastNamePerson.Text; set => textLastNamePerson.Text = value; }
        public string MiddleName { get => textMiddleNamePerson.Text; set => textMiddleNamePerson.Text = value; }
        public string PhotoPath { get => textPathFotoPerson.Text; set => textPathFotoPerson.Text = value; }
        public string Country { get => textCountryPerson.Text; set => textCountryPerson.Text = value; }
        public string City { get => textCityPerson.Text; set => textCityPerson.Text = value; }
        public string Role { get => comboBoxRole.Text; set => comboBoxRole.Text = value; }
        
        public SettingPerson()
        {
            InitializeComponent();
        }
       
        public SettingPerson(PersonForm personForm, bool isEdit = false)
        {
            InitializeComponent();

            this._isEdit = isEdit;
            this._perosnForm = personForm;

            if (isEdit)
            {
                SettingPersonPresenter settingPersonPresenter = new SettingPersonPresenter(this);
                settingPersonPresenter.ShowModelInView(IdPerson);
            }
        }

        private void buttonCanclePerson_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOkPerson_Click(object sender, EventArgs e)
        {
            SettingPersonPresenter presenter = new SettingPersonPresenter(this);

            if (_isEdit)
            {
                //settingMatchPresenter.UpdateMatch(idMatch);
            }
            else
            {
                presenter.InsertModelDB();
            }

            _perosnForm.UpdateTable();

            this.Close();
        }
    }
}
