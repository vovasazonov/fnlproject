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
        public int IdPerson { get => ((List<IPersonView>)(dataGridViewPerson.DataSource))[dataGridViewPerson.CurrentRow.Index].IdPerson; set => throw new NotImplementedException(); }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string MiddleName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PhotoPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Country { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Role { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private SettingPlayerTeam _settingPlayerTeamForm;
        //private MatchPlayers _matchPlayersForm;
        //private CategoryTable _categoryTable;
        private bool _isEdit;

        public PersonForm()
        {
            InitializeComponent();

            UpdateTable();
        }

        public PersonForm(SettingPlayerTeam settingPlayerTeamForm, bool isEdit = false)
        {
            InitializeComponent();

            _isEdit = isEdit;
            _settingPlayerTeamForm = settingPlayerTeamForm;

            UpdateTable();
        }

        //public PersonForm(MatchPlayers matchPlayersForm, CategoryTable category)
        //{
        //    InitializeComponent();

        //    _matchPlayersForm = matchPlayersForm;
        //    _categoryTable = category;

        //    UpdateTable();
        //}


        public void UpdateTable()
        {
            PersonPresenter presenter = new PersonPresenter(this);
            dataGridViewPerson.DataSource = presenter.GetView();
        }

        private void buttonInsertPerson_Click(object sender, EventArgs e)
        {
            SettingPerson form = new SettingPerson(this);
            form.Show();
        }

        private void buttonChangePerson_Click(object sender, EventArgs e)
        {
            SettingPerson form = new SettingPerson(this, true);
            form.Show();
        }

        private void buttonDeletePerson_Click(object sender, EventArgs e)
        {
            try
            {
                //idPerson = Convert.ToInt32(dataGridViewPerson.CurrentRow.Cells[0].Value);

                PersonPresenter person = new PersonPresenter(this);
                person.DeleteModelDB(IdPerson);
                dataGridViewPerson.DataSource = person.GetView();
            }
            catch (Exception)
            {

                throw;
            }
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

            //if (_matchPlayersForm != null)
            //{
            //    _matchPlayersForm.IdPerson = IdPerson;
            //    _matchPlayersForm.InsertData(_categoryTable);
            //}


            this.Close();
        }
    }
}
