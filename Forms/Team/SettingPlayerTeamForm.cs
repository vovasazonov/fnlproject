using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FNL.Dictionarys;
using FNL.Enums;
using FNL.Presenters;
using FNL.Views;

namespace FNL.Forms
{
    public partial class SettingPlayerTeamForm : Form, ISettingPlayerTeamView
    {
        #region View variables.
        public int PersonId
        {
            get
            {
                var dataSource = ((List<IPlayerTeamView>)(dataGridViewAllPlayers.DataSource));
                var currnetRow = dataGridViewAllPlayers.CurrentRow;
                _idPerson = currnetRow != null ? dataSource[currnetRow.Index].PersonId : _idPerson;

                return _idPerson;
            }
            set
            {
                _idPerson = value;
            }
        }
        private int _idPerson;
        public int Number { get => (int)number.Value; set => number.Value = value; }
        public string Amplua { get => comboBoxAmplua.Text; set => comboBoxAmplua.Text = value; }
        public string Team { get => comboBoxTeam.Text; set => comboBoxTeam.Text = value; }
        public int TeamId { get; set; }
        public int AmpluaId
        {
            get
            {
                AmpluaType type = DictionaryAmpluas.Dic.FirstOrDefault(x => x.Value == Amplua).Key;
                _ = !DictionaryAmpluas.Dic.TryGetValue(type, out string f) ? type = AmpluaType.WithoutAmplua : _ = type;
                return DictionaryAmpluas.GetId(type);
            }
            set
            {

            }
        }
        public string FirstName
        {
            get
            {
                var dataSource = ((List<IPlayerTeamView>)(dataGridViewAllPlayers.DataSource));
                var currnetRow = dataGridViewAllPlayers.CurrentRow;
                return currnetRow != null ? dataSource[currnetRow.Index].FirstName : "";
            }
            set
            {

            }
        }
        public string LastName
        {
            get
            {
                var dataSource = ((List<IPlayerTeamView>)(dataGridViewAllPlayers.DataSource));
                var currnetRow = dataGridViewAllPlayers.CurrentRow;
                return currnetRow != null ? dataSource[currnetRow.Index].LastName : "";
            }
            set
            {

            }
        }
        public string MiddleName
        {
            get
            {
                var dataSource = ((List<IPlayerTeamView>)(dataGridViewAllPlayers.DataSource));
                var currnetRow = dataGridViewAllPlayers.CurrentRow;
                return currnetRow != null ? dataSource[currnetRow.Index].MiddleName : "";
            }
            set
            {

            }
        }
        public string Role
        {
            get
            {
                var dataSource = ((List<IPlayerTeamView>)(dataGridViewAllPlayers.DataSource));
                var currnetRow = dataGridViewAllPlayers.CurrentRow;
                return currnetRow != null ? dataSource[currnetRow.Index].Role : "";
            }
            set
            {

            }
        }
        public int RoleId { get; set; }
        public string PhotoPath
        {
            get
            {
                var dataSource = ((List<IPlayerTeamView>)(dataGridViewAllPlayers.DataSource));
                var currnetRow = dataGridViewAllPlayers.CurrentRow;
                return currnetRow != null ? dataSource[currnetRow.Index].PhotoPath : "";
            }
            set
            {

            }
        }
        public string Country
        {
            get
            {
                var dataSource = ((List<IPlayerTeamView>)(dataGridViewAllPlayers.DataSource));
                var currnetRow = dataGridViewAllPlayers.CurrentRow;
                return currnetRow != null ? dataSource[currnetRow.Index].Country : "";
            }
            set
            {

            }
        }
        public string City
        {
            get
            {
                var dataSource = ((List<IPlayerTeamView>)(dataGridViewAllPlayers.DataSource));
                var currnetRow = dataGridViewAllPlayers.CurrentRow;
                return currnetRow != null ? dataSource[currnetRow.Index].City : "";
            }
            set
            {

            }
        }
        #endregion

        #region Class variables.
        private bool _isEdit = false;
        private SettingTeamForm _settingTeamForm = null;
        internal bool IsBtnOkClicked { get => _isBtnOkClicked; private set => _isBtnOkClicked = value; }
        private bool _isBtnOkClicked = false;
        #endregion

        public SettingPlayerTeamForm(SettingTeamForm settingTeamForm, bool isEdit = false)
        {
            InitializeComponent();

            this._isEdit = isEdit;
            this._settingTeamForm = settingTeamForm;

            TeamId = _settingTeamForm.TeamId;

            // Prepare combobox amplua
            comboBoxAmplua.Items.AddRange(DictionaryAmpluas.Dic.Values.ToArray());
            comboBoxAmplua.SelectedIndex = 0;

            SettingPlayerTeamPresenter presenterPlayerTeam = new SettingPlayerTeamPresenter(this);

            // Load only current person to table.
            if (_isEdit)
            {
                PersonId = _settingTeamForm.PersonId;

                PlayerTeamPresenter tablePresenter = new PlayerTeamPresenter(this);
                dataGridViewAllPlayers.DataSource = tablePresenter.GetView();
            }
            // Load all people.
            else
            {
                UpdateTable();
            }

            presenterPlayerTeam.ShowPlayerInView();

            dataGridViewAllPlayers.CellValueChanged += DataGridViewAllPlayers_CellValueChanged;

        }

        private void DataGridViewAllPlayers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SettingPlayerTeamPresenter presenter = new SettingPlayerTeamPresenter(this);
            presenter.ShowPlayerInView();
        }


        private void UpdateTable()
        {
            PlayerTeamPresenter tablePresenter = new PlayerTeamPresenter(this);
            dataGridViewAllPlayers.DataSource = tablePresenter.GetViews();

            SettingPlayerTeamPresenter presenterPlayerTeam = new SettingPlayerTeamPresenter(this);
            presenterPlayerTeam.ShowPlayerInView();
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            PersonForm personForm = new PersonForm(this);
            personForm.Show();
            personForm.FormClosing += (s, ev) =>
            {
                if (personForm.IsBtnOkClicked && this != null)
                {
                    UpdateTable();
                }
            };
        }

        private void buttonChangePerson_Click(object sender, EventArgs e)
        {
            PersonForm personForm = new PersonForm(this, true);
            personForm.Show();
            personForm.FormClosing += (s, ev) =>
            {
                if (personForm.IsBtnOkClicked && this != null)
                {
                    UpdateTable();
                }
            };
        }

        private void buttonDeletePerson_Click(object sender, EventArgs e)
        {
            SettingPlayerTeamPresenter presenter = new SettingPlayerTeamPresenter(this);
            presenter.DeleteModelDB();

            UpdateTable();
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SettingPlayerTeamPresenter presenter = new SettingPlayerTeamPresenter(this);

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
    }
}
