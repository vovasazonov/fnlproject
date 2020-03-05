/*  Файл окна интерфейса.
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */
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
using FNL.Extensions;

namespace FNL.Forms
{
    public partial class SettingTeamForm : Form, ISettingTeamView, IPlayerTeamView
    {
        #region View variables
        public int TeamId { get; set; }
        public Color Color { get => btnColor.BackColor; set => btnColor.BackColor = value; }
        public string NameFull { get => textNameFullTeam.Text; set => textNameFullTeam.Text = value; }
        public string NameShort { get => textNameShortTeam.Text; set => textNameShortTeam.Text = value; }
        public string PathLogo { get => comboBoxPathLogo.Text; set => comboBoxPathLogo.Text = value; }

        public int PersonId
        {
            get
            {
                var dataSource = (List<IPlayerTeamView>)(dataGridViewPlayersTeam.DataSource);
                var currentRow = dataGridViewPlayersTeam.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].PersonId : 0;
            }
            set
            {

            }
        }
        public int RoleId
        {
            get
            {
                var dataSource = (List<IPlayerTeamView>)(dataGridViewPlayersTeam.DataSource);
                var currentRow = dataGridViewPlayersTeam.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].RoleId : 0;
            }
            set
            {

            }
        }
        public int AmpluaId
        {
            get
            {
                var dataSource = (List<IPlayerTeamView>)(dataGridViewPlayersTeam.DataSource);
                var currentRow = dataGridViewPlayersTeam.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].AmpluaId : 0;
            }
            set
            {

            }
        }
        public int Number
        {
            get
            {
                var dataSource = (List<IPlayerTeamView>)(dataGridViewPlayersTeam.DataSource);
                var currentRow = dataGridViewPlayersTeam.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].Number : 0;
            }
            set
            {

            }
        }
        public string FirstName
        {
            get
            {
                var dataSource = (List<IPlayerTeamView>)(dataGridViewPlayersTeam.DataSource);
                var currentRow = dataGridViewPlayersTeam.CurrentRow;
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
                var dataSource = (List<IPlayerTeamView>)(dataGridViewPlayersTeam.DataSource);
                var currentRow = dataGridViewPlayersTeam.CurrentRow;
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
                var dataSource = (List<IPlayerTeamView>)(dataGridViewPlayersTeam.DataSource);
                var currentRow = dataGridViewPlayersTeam.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].MiddleName : "";
            }
            set
            {

            }
        }
        public string Role
        {
            get
            {
                var dataSource = (List<IPlayerTeamView>)(dataGridViewPlayersTeam.DataSource);
                var currentRow = dataGridViewPlayersTeam.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].Role : "";
            }
            set
            {

            }
        }
        public string Amplua
        {
            get
            {
                var dataSource = (List<IPlayerTeamView>)(dataGridViewPlayersTeam.DataSource);
                var currentRow = dataGridViewPlayersTeam.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].Amplua : "";
            }
            set
            {

            }
        }

        public string PhotoPath
        {
            get
            {
                var dataSource = (List<IPlayerTeamView>)(dataGridViewPlayersTeam.DataSource);
                var currentRow = dataGridViewPlayersTeam.CurrentRow;
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
                var dataSource = (List<IPlayerTeamView>)(dataGridViewPlayersTeam.DataSource);
                var currentRow = dataGridViewPlayersTeam.CurrentRow;
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
                var dataSource = (List<IPlayerTeamView>)(dataGridViewPlayersTeam.DataSource);
                var currentRow = dataGridViewPlayersTeam.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].City : "";
            }
            set
            {

            }
        }
        #endregion

        #region Class variables.
        private TeamForm _teamForm = null;
        private bool _isEdit = false;
        internal bool IsBtnOkClicked { get => _isBtnOkClicked; private set => _isBtnOkClicked = value; }
        private bool _isBtnOkClicked = false;
        #endregion

        public SettingTeamForm()
        {
            InitializeComponent();
        }

        public SettingTeamForm(TeamForm teamForm, bool isEdit = false)
        {
            InitializeComponent();

            this._isEdit = isEdit;
            this._teamForm = teamForm;

            if (_isEdit)
            {
                // Set the id team, from antoher form, that have to change.
                TeamId = _teamForm.TeamId;

                // Update view.
                SettingTeamPresenter presenter = new SettingTeamPresenter(this);
                presenter.ShowModelInView();

                UpdateTable();
            }
            else
            {
                // Hide buttons
                buttonAddPlayer.Enabled = false;
                buttonChangePlayer.Enabled = false;
            }
        }

        private void UpdateTable()
        {
            SettingTeamPresenter presenter = new SettingTeamPresenter(this);
            // Set table with data from database.
            dataGridViewPlayersTeam.DataSource = presenter.GetViews();
        }

        private void buttonSetTeamOk_Click(object sender, EventArgs e)
        {
            SettingTeamPresenter presenter = new SettingTeamPresenter(this);

            if (_isEdit)
            {
                if (!presenter.UpdateModelDB()) MessageBoxFNL.MessageErrorDb();
            }
            else
            {
                if (!presenter.InsertModelDB()) MessageBoxFNL.MessageErrorDb();
            }

            _isBtnOkClicked = true;

            this.Close();
        }

        private void buttonAddPlayer_Click(object sender, EventArgs e)
        {
            SettingPlayerTeamForm form = new SettingPlayerTeamForm(this);
            form.Show();
            form.FormClosing += (s, ev) =>
            {
                if (form.IsBtnOkClicked && this != null)
                {
                    UpdateTable();
                }
            };
        }

        private void buttonDeletePlayer_Click(object sender, EventArgs e)
        {
            PlayerTeamPresenter presenter = new PlayerTeamPresenter(this);
            if (!presenter.DeleteModelDB()) MessageBoxFNL.MessageErrorDb();

            UpdateTable();
        }

        private void buttonChangePlayer_Click(object sender, EventArgs e)
        {
            SettingPlayerTeamForm form = new SettingPlayerTeamForm(this, true);
            form.Show();
            form.FormClosing += (s, ev) =>
            {
                if (form.IsBtnOkClicked && this != null)
                {
                    UpdateTable();
                }
            };
        }

        private void comboBoxPathLogo_Click(object sender, EventArgs e)
        {
            string folderName = "";

            OpenFileDialog folderBrowserDialog1 = new OpenFileDialog();

            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                folderName = folderBrowserDialog1.FileName;
            }

            comboBoxPathLogo.Text = folderName;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            this.Color = (new Color()).ChoseColorDialog();
        }
    }
}
