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
    public partial class MatchPlayersForm : Form, IMatchPlayersView
    {
        #region View variables.
        public int PersonId { get; set; }
        public int Number { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string MiddleName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Role { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Amplua { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsSpare { get; set; }
        public string PhotoPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Country { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RoleId { get; set; }
        public int AmpluaId { get; set; }
        public int TeamId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region Class variables.
        private MatchForm _matchesForm = null;
        #endregion

        public MatchPlayersForm()
        {
            InitializeComponent();
        }

        public MatchPlayersForm(MatchForm matchesForm)
        {
            InitializeComponent();

            _matchesForm = matchesForm;

            UpdateView();
        }


        internal void UpdateView()
        {
            MatchPlayersPresenter presenter = new MatchPlayersPresenter(this);

            // Set table with data from database.
            dataGridHomePlayers.DataSource = presenter.GetViews(PersonCategoryType.HomeTeam, _matchesForm.MatchId);
            dataGridGuestPlayers.DataSource = presenter.GetViews(PersonCategoryType.GuestTeam, _matchesForm.MatchId);
        }

        public void InsertData(PersonCategoryType category, bool isPair = false)
        {
            MatchPlayersPresenter presenter = new MatchPlayersPresenter(this);
            IsSpare = isPair;
            presenter.InsertModelDB(category, _matchesForm.MatchId);

            UpdateView();
        }

        private void buttonAddPlayerHome_Click(object sender, EventArgs e)
        {
            InsertMatchPlayersForm personForm = new InsertMatchPlayersForm(this, PersonCategoryType.HomeTeam, _matchesForm.MatchId);
            personForm.Show();

        }

        private void buttonDeletePlayerHome_Click(object sender, EventArgs e)
        {
            var dataSource = (List<IMatchPlayersView>)(dataGridHomePlayers.DataSource);
            var currentRow = dataGridHomePlayers.CurrentRow;
            PersonId = currentRow != null ? dataSource[currentRow.Index].PersonId : -1;

            MatchPlayersPresenter presenter = new MatchPlayersPresenter(this);
            presenter.DeleteModelDB(PersonCategoryType.HomeTeam, _matchesForm.MatchId);

            UpdateView();
        }

        private void buttonAddPlayerGuest_Click(object sender, EventArgs e)
        {
            InsertMatchPlayersForm form = new InsertMatchPlayersForm(this, PersonCategoryType.GuestTeam, _matchesForm.MatchId);
            form.Show();
        }

        private void buttonDeletePlayerGuest_Click(object sender, EventArgs e)
        {
            var dataSource = (List<IMatchPlayersView>)(dataGridGuestPlayers.DataSource);
            var currentRow = dataGridGuestPlayers.CurrentRow;
            PersonId = currentRow != null ? dataSource[currentRow.Index].PersonId : -1;

            MatchPlayersPresenter presenter = new MatchPlayersPresenter(this);
            presenter.DeleteModelDB(PersonCategoryType.GuestTeam, _matchesForm.MatchId);

            UpdateView();
        }
    }
}
