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
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string MiddleName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PhotoPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Country { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Role { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PersonForm()
        {
            InitializeComponent();

            UpdateTable();
        }

        public void UpdateTable()
        {
            PersonPresenter newPerson = new PersonPresenter(this);
            dataGridViewPerson.DataSource = newPerson.GetPeople();
        }

        private void buttonInsertPerson_Click(object sender, EventArgs e)
        {
            SettingPerson settingPersonForm = new SettingPerson(this);
            settingPersonForm.Show();
        }

        private void buttonChangePerson_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeletePerson_Click(object sender, EventArgs e)
        {
            int idPerson = 0;
            try
            {
                idPerson = Convert.ToInt32(dataGridViewPerson.CurrentRow.Cells[0].Value);

                PersonPresenter person = new PersonPresenter(this);
                person.DeletePersonFromDatabase(idPerson);
                dataGridViewPerson.DataSource = person.GetPeople();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
