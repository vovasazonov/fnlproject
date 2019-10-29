using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FNL.Enums;
using FNL.Presenters;
using FNL.Views;

namespace FNL.Forms
{
    public partial class MatchPlayers : Form, IMatchPlayersView
    {
        public MatchPlayers()
        {
            InitializeComponent();
        }

        public MatchPlayers(MatchTableForm matchesForm)
        {
            InitializeComponent();

            _matchesForm = matchesForm;
            UpdateView();
        }

        private MatchTableForm _matchesForm;

        public int IdPerson { get; set; }
        public int Number { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string MiddleName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Role { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Amplua { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsSpare { get; set; }

        public void UpdateView()
        {
            // Update tables
            MatchPlayersPresenter presenter = new MatchPlayersPresenter(this);
            // Set table with data from database.
            dataGridActors.DataSource = presenter.GetViews(PersonAccessory.FaceMatch, _matchesForm.MatchId);
            dataGridHomePlayers.DataSource = presenter.GetViews(PersonAccessory.HomeTeam, _matchesForm.MatchId);
            dataGridGuestPlayers.DataSource = presenter.GetViews(PersonAccessory.GuestTeam, _matchesForm.MatchId);
        }

        public void InsertData(PersonAccessory category, bool isPair = false)
        {

            //if (category != CategoryTable.Actor)
            //{
            //    MatchPlayersPresenter presenter = new MatchPlayersPresenter(this);
            //    //DialogResult result = MessageBox.Show(
            //    //   "Данный игрок запасной?",
            //    //   "Сообщение",
            //    //   MessageBoxButtons.YesNo,
            //    //   MessageBoxIcon.Information,
            //    //   MessageBoxDefaultButton.Button1,
            //    //   MessageBoxOptions.DefaultDesktopOnly);

            //    //if (result == DialogResult.Yes)
            //    //    IsSpare = true;
            //    IsSpare = IsSpare;
            //    presenter.InsertModelDB(category, _matchesForm.MatchId);

            //}
            //else
            //{

            //}
            MatchPlayersPresenter presenter = new MatchPlayersPresenter(this);
            IsSpare = isPair;
            presenter.InsertModelDB(category, _matchesForm.MatchId);

            UpdateView();
        }

        private void buttonAddPlayerHome_Click(object sender, EventArgs e)
        {
            //IdPerson = ((List<IMatchPlayersView>)(dataGridHomePlayers.DataSource))[dataGridHomePlayers.CurrentRow.Index].IdPerson;
            //PersonForm personForm = new PersonForm(this, CategoryTable.HomeTeam);
            InsertMatchPlayers personForm = new InsertMatchPlayers(this, PersonAccessory.HomeTeam, _matchesForm.MatchId);
            personForm.Show();

        }

        private void buttonDeletePlayerHome_Click(object sender, EventArgs e)
        {
            IdPerson = ((List<IMatchPlayersView>)(dataGridHomePlayers.DataSource))[dataGridHomePlayers.CurrentRow.Index].IdPerson;
            MatchPlayersPresenter presenter = new MatchPlayersPresenter(this);
            presenter.DeleteModelDB(PersonAccessory.HomeTeam, _matchesForm.MatchId);
            UpdateView();
        }

        private void buttonAddPlayerGuest_Click(object sender, EventArgs e)
        {
            //IdPerson = ((List<IMatchPlayersView>)(dataGridGuestPlayers.DataSource))[dataGridGuestPlayers.CurrentRow.Index].IdPerson;
            //PersonForm personForm = new PersonForm(this, CategoryTable.GuestTeam);
            //personForm.Show();
            InsertMatchPlayers personForm = new InsertMatchPlayers(this, PersonAccessory.GuestTeam, _matchesForm.MatchId);
            personForm.Show();
        }

        private void buttonDeletePlayerGuest_Click(object sender, EventArgs e)
        {
            IdPerson = ((List<IMatchPlayersView>)(dataGridGuestPlayers.DataSource))[dataGridGuestPlayers.CurrentRow.Index].IdPerson;
            MatchPlayersPresenter presenter = new MatchPlayersPresenter(this);
            presenter.DeleteModelDB(PersonAccessory.GuestTeam, _matchesForm.MatchId);
            UpdateView();
        }

        private void buttonAddActor_Click(object sender, EventArgs e)
        {
            //IdPerson = ((List<IMatchPlayersView>)(dataGridActors.DataSource))[dataGridActors.CurrentRow.Index].IdPerson;
            //PersonForm personForm = new PersonForm(this, CategoryTable.Actor);
            //personForm.Show();
        }

        private void buttonDeleteActor_Click(object sender, EventArgs e)
        {
            //IdPerson = ((List<IMatchPlayersView>)(dataGridActors.DataSource))[dataGridActors.CurrentRow.Index].IdPerson;
            //MatchPlayersPresenter presenter = new MatchPlayersPresenter(this);
            //presenter.DeleteModelDB(CategoryTable.Actor, _matchesForm.MatchId);
            //UpdateView();
        }
    }
}
