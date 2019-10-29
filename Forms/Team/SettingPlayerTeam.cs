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
    public partial class SettingPlayerTeam : Form, ISettingPlayerTeamView, ITablePlayerTeamView
    {
        public SettingPlayerTeam(SettingTeam settingTeamForm, bool isEdit = false)
        {
            InitializeComponent();

            this._isEdit = isEdit;
            this._settingTeam = settingTeamForm;

            IdTeam = _settingTeam.IdTeam;

            // Prepare combobox amplua
            comboBoxAmplua.Items.AddRange(DictionaryAmpluas.Dic.Values.ToArray());
            comboBoxAmplua.SelectedIndex = 0;

            SettingPlayerTeamPresenter presenterPlayerTeam = new SettingPlayerTeamPresenter(this);

            // Load only current person to table.
            if (_isEdit)
            {
                IdPerson = _settingTeam.IdPerson;

                TablePlayerTeamPresenter tablePresenter = new TablePlayerTeamPresenter(this);
                dataGridViewAllPlayers.DataSource = tablePresenter.GetView(IdTeam, IdPerson);
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

        private bool _isEdit;
        private SettingTeam _settingTeam;

        private int _idPerson;
        public int IdPerson
        {
            get
            {
                var dataSource = ((List<ITablePlayerTeamView>)(dataGridViewAllPlayers.DataSource));
                _idPerson = dataGridViewAllPlayers.CurrentRow != null ? dataSource[dataGridViewAllPlayers.CurrentRow.Index].IdPerson : 0;

                return _idPerson;
            }
            set
            {
                _idPerson = value;
            }
        }
        public int Number { get => (int)number.Value; set => number.Value = value; }
        public string AmpluaName { get => comboBoxAmplua.Text; set => comboBoxAmplua.Text = value; }
        public string TeamName { get => comboBoxTeam.Text; set => comboBoxTeam.Text = value; }
        public int IdTeam { get; set; }
        public int? IdAmplua
        {
            get
            {
                AmpluaType id = AmpluaType.Goalkeeper;

                foreach (var item in DictionaryAmpluas.Dic)
                {
                    if (item.Value == Amplua)
                    {
                        id = item.Key;
                    }
                }
                return (int)id;
            }
            set
            {

            }
        }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string MiddleName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Role { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Amplua { get => comboBoxAmplua.Text; set => comboBoxAmplua.Text = value; }

        public void UpdateTable()
        {
            TablePlayerTeamPresenter tablePresenter = new TablePlayerTeamPresenter(this);
            dataGridViewAllPlayers.DataSource = tablePresenter.GetViews();//dataGridViewAllPlayers.DataSource = tablePresenter.GetViews(IdTeam);
            SettingPlayerTeamPresenter presenterPlayerTeam = new SettingPlayerTeamPresenter(this);
            presenterPlayerTeam.ShowPlayerInView();
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            PersonForm personForm = new PersonForm(this);
            personForm.Show();
        }

        private void buttonChangePerson_Click(object sender, EventArgs e)
        {
            PersonForm personForm = new PersonForm(this, true);
            personForm.Show();
            personForm.FormClosed += PersonForm_FormClosed;
        }

        private void PersonForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this != null)
            {
                UpdateTable();

            }
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
                presenter.UpdateModelDB(_settingTeam.IdPerson);
            }
            else
            {
                presenter.InsertModelDB();
            }

            if (_settingTeam != null)
            {
                _settingTeam.UpdateTable();
            }

            this.Close();
        }
    }
}
