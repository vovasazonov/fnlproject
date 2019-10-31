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
    public partial class PersonForm : Form, IPersonView
    {
        #region View variables.
        public int PersonId
        {
            get
            {
                var dataSource = (List<IPersonView>)(dataGridViewPerson.DataSource);
                var currentRow = dataGridViewPerson.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].PersonId : -1;
            }
            set
            {

            }
        }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string MiddleName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PhotoPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Country { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Role { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RoleId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region Class variables.
        private SettingPlayerTeamForm _settingPlayerTeamForm = null;
        private bool _isEdit = false;
        #endregion

        public PersonForm()
        {
            InitializeComponent();

            UpdateTable();
        }

        public PersonForm(SettingPlayerTeamForm settingPlayerTeamForm, bool isEdit = false)
        {
            InitializeComponent();

            _isEdit = isEdit;
            _settingPlayerTeamForm = settingPlayerTeamForm;

            UpdateTable();
        }

        internal void UpdateTable()
        {
            PersonPresenter presenter = new PersonPresenter(this);
            dataGridViewPerson.DataSource = presenter.GetView();
        }

        private void buttonInsertPerson_Click(object sender, EventArgs e)
        {
            SettingPersonForm form = new SettingPersonForm(this);
            form.Show();
        }

        private void buttonChangePerson_Click(object sender, EventArgs e)
        {
            SettingPersonForm form = new SettingPersonForm(this, true);
            form.Show();
        }

        private void buttonDeletePerson_Click(object sender, EventArgs e)
        {
            PersonPresenter person = new PersonPresenter(this);
            person.DeleteModelDB();

            dataGridViewPerson.DataSource = person.GetView();
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // Insert to team the player.
            if (_settingPlayerTeamForm != null)
            {
                _settingPlayerTeamForm.UpdateTable();
            }

            this.Close();
        }
    }
}
