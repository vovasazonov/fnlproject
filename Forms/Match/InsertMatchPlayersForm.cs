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
    public partial class InsertMatchPlayersForm : Form, IInsertMatchPlayersView
    {
        #region View variables.
        public int PersonId
        {
            get
            {
                var dataSource = (List<ITablePlayersMainView>)(dataGridPlayers.DataSource);
                var currentRow = dataGridPlayers.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].PersonId : 0;
            }
            set
            {

            }
        }

        public bool IsPair { get => radioButtonIsPair.Checked; set => throw new NotImplementedException(); }
        public int NumberTrainers { get => throw new NotImplementedException(); set => textBoxTrainers.Text = value.ToString(); }
        public int NumberPlayers { get => throw new NotImplementedException(); set => textBoxNotPairs.Text = value.ToString(); }
        public int NumberPairsPlayers { get => throw new NotImplementedException(); set => textBoxPairs.Text = value.ToString(); }

        #endregion

        #region Class variables.
        private MatchPlayersForm _matchPlayersForm = null;
        private PersonCategoryType _categoryTable;
        private int _matchId;
        #endregion

        public InsertMatchPlayersForm(MatchPlayersForm matchPlayersForm, PersonCategoryType category, int matchId)
        {
            InitializeComponent();

            _matchPlayersForm = matchPlayersForm;
            _categoryTable = category;
            _matchId = matchId;

            UpdateView();
        }

        internal void UpdateView()
        {
            UpdateTable();
        }

        private void UpdateTable()
        {
            TablePlayersMainPresenter presenter = new TablePlayersMainPresenter();
            dataGridPlayers.DataSource = presenter.GetViewsNotChosed(_matchId, _categoryTable);
        }

        private void buttonAddPlayerTeam_Click(object sender, EventArgs e)
        {
            if (_matchPlayersForm != null)
            {
                _matchPlayersForm.PersonId = PersonId;
                _matchPlayersForm.InsertData(_categoryTable,IsPair);
            }

            UpdateView();
        }
    }
}
