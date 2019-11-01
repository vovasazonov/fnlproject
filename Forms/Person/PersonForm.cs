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
using FNL.Enums;
using FNL.Dictionarys;

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
        public string FirstName
        {
            get
            {
                var dataSource = (List<IPersonView>)(dataGridViewPerson.DataSource);
                var currentRow = dataGridViewPerson.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].FirstName : "";
            }
            set
            {

            }
        }
        public string LastName
        {
            get
            {
                var dataSource = (List<IPersonView>)(dataGridViewPerson.DataSource);
                var currentRow = dataGridViewPerson.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].LastName : "";
            }
            set
            {

            }
        }
        public string MiddleName
        {
            get
            {
                var dataSource = (List<IPersonView>)(dataGridViewPerson.DataSource);
                var currentRow = dataGridViewPerson.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].MiddleName : "";
            }
            set
            {

            }
        }
        public string PhotoPath
        {
            get
            {
                var dataSource = (List<IPersonView>)(dataGridViewPerson.DataSource);
                var currentRow = dataGridViewPerson.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].PhotoPath : "";
            }
            set
            {

            }
        }
        public string Country
        {
            get
            {
                var dataSource = (List<IPersonView>)(dataGridViewPerson.DataSource);
                var currentRow = dataGridViewPerson.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].Country : "";
            }
            set
            {

            }
        }
        public string City
        {
            get
            {
                var dataSource = (List<IPersonView>)(dataGridViewPerson.DataSource);
                var currentRow = dataGridViewPerson.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].City : "";
            }
            set
            {

            }
        }
        public string Role
        {
            get
            {
                var dataSource = (List<IPersonView>)(dataGridViewPerson.DataSource);
                var currentRow = dataGridViewPerson.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].Role : "";
            }
            set
            {

            }
        }
        public int RoleId
        {
            get
            {
                var dataSource = (List<IPersonView>)(dataGridViewPerson.DataSource);
                var currentRow = dataGridViewPerson.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].RoleId : -1;
            }
            set
            {

            }
        }
        #endregion

        #region Class variables.
        private SettingPlayerTeamForm _settingPlayerTeamForm = null;
        private SettingMatchForm _settingMatchForm = null;
        private bool _isEdit = false;
        private RoleType _roleType;
        internal bool IsBtnOkClicked { get => _isBtnOkClicked; private set => _isBtnOkClicked = value; }
        private bool _isBtnOkClicked = false;
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

        public PersonForm(SettingMatchForm settingMatchForm, RoleType roleType)
        {
            InitializeComponent();

            _settingMatchForm = settingMatchForm;
            _roleType = roleType;

            UpdateTable();
        }

        private void UpdateTable()
        {
            PersonPresenter presenter = new PersonPresenter(this);
            dataGridViewPerson.DataSource = presenter.GetView();
        }

        private void buttonInsertPerson_Click(object sender, EventArgs e)
        {
            SettingPersonForm form = new SettingPersonForm(this);
            form.Show();
            form.FormClosing += (s, ev) =>
            {
                if (form.IsBtnOkClicked && this != null)
                {
                    UpdateTable();
                }
            };
        }

        private void buttonChangePerson_Click(object sender, EventArgs e)
        {
            SettingPersonForm form = new SettingPersonForm(this, true);
            form.Show();
            form.FormClosing += (s, ev) =>
            {
                if (form.IsBtnOkClicked && this != null)
                {
                    UpdateTable();
                }
            };
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
            if (_settingMatchForm != null && (int)_roleType != RoleId)
            {
                MessageBox.Show(
                    "Выберите человека, соответствующий роли " +
                    DictionaryRoles.Dic[_roleType] +
                    " Если его нету, добавьте человека с токой ролью.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            _isBtnOkClicked = true;

            this.Close();
        }

        /// <summary>
        /// Return full name current cell person from datasource in datagridview.
        /// </summary>
        /// <returns></returns>
        internal string GetFullNamePerson()
        {
            return string.Format("{0} {1} {2}", FirstName, LastName, MiddleName);
        }
    }
}
