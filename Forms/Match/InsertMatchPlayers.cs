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
    public partial class InsertMatchPlayers : Form, IInsertMatchPlayersView
    {
        //public InsertMatchPlayers()
        //{
        //    InitializeComponent();
        //}

        public InsertMatchPlayers(MatchPlayers matchPlayersForm, TablePersonType category, int matchId)
        {
            InitializeComponent();

            _matchPlayersForm = matchPlayersForm;
            _categoryTable = category;
            _matchId = matchId;

            UpdateTable();
        }

        private MatchPlayers _matchPlayersForm;
        private TablePersonType _categoryTable;
        private int _matchId;

        public int PersonId { get=> ((List<ITablePlayersMainView>)(dataGridPlayers.DataSource))[dataGridPlayers.CurrentRow.Index].PersonId; set => throw new NotImplementedException(); }
        public bool IsPair { get => radioButtonIsPair.Checked; set => throw new NotImplementedException(); }
        public int NumberTrainers { get => throw new NotImplementedException(); set => textBoxTrainers.Text = value.ToString(); }
        public int NumberPlayers { get => throw new NotImplementedException(); set => textBoxNotPairs.Text = value.ToString(); }
        public int NumberPairsPlayers { get => throw new NotImplementedException(); set => textBoxPairs.Text = value.ToString(); }

        public void UpdateTable()
        {
            TablePlayersMainPresenter presenter = new TablePlayersMainPresenter();
            dataGridPlayers.DataSource = presenter.GetViewsNotChosed(_matchId, _categoryTable);
        }

        private void buttonAddPlayerTeam_Click(object sender, EventArgs e)
        {
            _matchPlayersForm.IdPerson = PersonId;
            _matchPlayersForm.InsertData(_categoryTable,IsPair);

            UpdateTable();
        }
    }
}
