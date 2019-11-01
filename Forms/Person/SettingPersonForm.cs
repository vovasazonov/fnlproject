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
using FNL.Dictionarys;
using FNL.Enums;

namespace FNL.Forms
{
    public partial class SettingPersonForm : Form, ISettingPersonView
    {
        #region View variables.
        public int PersonId { get; set; }
        public string FirstName { get => textFirstNamePerson.Text; set => textFirstNamePerson.Text = value; }
        public string LastName { get => textLastNamePerson.Text; set => textLastNamePerson.Text = value; }
        public string MiddleName { get => textMiddleNamePerson.Text; set => textMiddleNamePerson.Text = value; }
        public string PhotoPath { get => textPathFotoPerson.Text; set => textPathFotoPerson.Text = value; }
        public string Country { get => textCountryPerson.Text; set => textCountryPerson.Text = value; }
        public string City { get => textCityPerson.Text; set => textCityPerson.Text = value; }
        public string Role { get => comboBoxRole.Text; set => comboBoxRole.Text = value; }
        public int RoleId
        {
            get
            {
                RoleType type = DictionaryRoles.Dic.FirstOrDefault(x => x.Value == Role).Key;
                _ = !DictionaryRoles.Dic.TryGetValue(type, out string f) ? type = RoleType.WithoutRole : _ = type;
                return DictionaryRoles.GetId(type);
            }
            set
            {

            }
        }
        #endregion

        #region Class variables.
        private PersonForm _perosnForm = null;
        private bool _isEdit = false;
        internal bool IsBtnOkClicked { get => _isBtnOkClicked; private set => _isBtnOkClicked = value; }
        private bool _isBtnOkClicked = false;
        #endregion


        public SettingPersonForm()
        {
            InitializeComponent();
        }
       
        public SettingPersonForm(PersonForm personForm, bool isEdit = false)
        {
            InitializeComponent();

            this._isEdit = isEdit;
            this._perosnForm = personForm;

            // Prepare combobox on view.
            comboBoxRole.Items.AddRange(DictionaryRoles.Dic.Values.ToArray());
            comboBoxRole.SelectedIndex = 0;

            if (isEdit)
            {
                SettingPersonPresenter settingPersonPresenter = new SettingPersonPresenter(this);
                settingPersonPresenter.ShowModelInView();
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
                presenter.UpdateModelDB();
            }
            else
            {
                presenter.InsertModelDB();
            }

            _isBtnOkClicked = true;

            this.Close();
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
