using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public MatchPlayers(MatchesForm matchesForm)
        {
            InitializeComponent();

            _matchesForm = matchesForm;
            UpdateView();
        }

        private MatchesForm _matchesForm;

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
            dataGridActors.DataSource = presenter.GetViews(CategoryTable.Actor, _matchesForm.MatchId);
            dataGridHomePlayers.DataSource = presenter.GetViews(CategoryTable.HomeTeam, _matchesForm.MatchId);
            dataGridGuestPlayers.DataSource = presenter.GetViews(CategoryTable.GuestTeam, _matchesForm.MatchId);
        }

        public void InsertData(CategoryTable category)
        {
            MatchPlayersPresenter presenter = new MatchPlayersPresenter(this);

            if (category != CategoryTable.Actor)
            {
                DialogResult result = MessageBox.Show(
                   "Данный игрок запасной?",
                   "Сообщение",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes)
                    IsSpare = true;

            }
            presenter.InsertModelDB(category, _matchesForm.MatchId);
            UpdateView();
        }

        private void buttonAddPlayerHome_Click(object sender, EventArgs e)
        {
            //IdPerson = ((List<IMatchPlayersView>)(dataGridHomePlayers.DataSource))[dataGridHomePlayers.CurrentRow.Index].IdPerson;
            PersonForm personForm = new PersonForm(this, CategoryTable.HomeTeam);
            personForm.Show();

        }

        private void buttonDeletePlayerHome_Click(object sender, EventArgs e)
        {
            IdPerson = ((List<IMatchPlayersView>)(dataGridHomePlayers.DataSource))[dataGridHomePlayers.CurrentRow.Index].IdPerson;
            MatchPlayersPresenter presenter = new MatchPlayersPresenter(this);
            presenter.DeleteModelDB(CategoryTable.HomeTeam, _matchesForm.MatchId);
            UpdateView();
        }

        private void buttonAddPlayerGuest_Click(object sender, EventArgs e)
        {
            //IdPerson = ((List<IMatchPlayersView>)(dataGridGuestPlayers.DataSource))[dataGridGuestPlayers.CurrentRow.Index].IdPerson;
            PersonForm personForm = new PersonForm(this, CategoryTable.GuestTeam);
            personForm.Show();
        }

        private void buttonDeletePlayerGuest_Click(object sender, EventArgs e)
        {
            IdPerson = ((List<IMatchPlayersView>)(dataGridGuestPlayers.DataSource))[dataGridGuestPlayers.CurrentRow.Index].IdPerson;
            MatchPlayersPresenter presenter = new MatchPlayersPresenter(this);
            presenter.DeleteModelDB(CategoryTable.GuestTeam, _matchesForm.MatchId);
            UpdateView();
        }

        private void buttonAddActor_Click(object sender, EventArgs e)
        {
            //IdPerson = ((List<IMatchPlayersView>)(dataGridActors.DataSource))[dataGridActors.CurrentRow.Index].IdPerson;
            PersonForm personForm = new PersonForm(this, CategoryTable.Actor);
            personForm.Show();
        }

        private void buttonDeleteActor_Click(object sender, EventArgs e)
        {
            IdPerson = ((List<IMatchPlayersView>)(dataGridActors.DataSource))[dataGridActors.CurrentRow.Index].IdPerson;
            MatchPlayersPresenter presenter = new MatchPlayersPresenter(this);
            presenter.DeleteModelDB(CategoryTable.Actor, _matchesForm.MatchId);
            UpdateView();
        }
    }
}
