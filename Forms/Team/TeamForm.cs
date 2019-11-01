using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FNL.Forms;
using FNL.Presenters;
using FNL.Views;

namespace FNL.Forms
{
    public partial class TeamForm : Form, ITeamView
    {
        #region Views variable.
        public int TeamId
        {
            get
            {
                var dataSource = (List<ITeamView>)(dataGridViewTeams.DataSource);
                var currentRow = dataGridViewTeams.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].TeamId : 0;
            }
            set
            {

            }
        }
        public Color Color
        {
            get
            {
                var dataSource = (List<ITeamView>)(dataGridViewTeams.DataSource);
                var currentRow = dataGridViewTeams.CurrentRow;
                return currentRow != null ?dataSource[currentRow.Index].Color: new Color();
            }
            set
            {

            }
        }
        public string NameFull
        {
            get
            {
                var dataSource = (List<ITeamView>)(dataGridViewTeams.DataSource);
                var currentRow = dataGridViewTeams.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].NameFull : "";
            }
            set
            {

            }
        }
        public string NameShort
        {
            get
            {
                var dataSource = (List<ITeamView>)(dataGridViewTeams.DataSource);
                var currentRow = dataGridViewTeams.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].NameShort : "";
            }
            set
            {

            }
        }
        public string PathLogo
        {
            get
            {
                var dataSource = (List<ITeamView>)(dataGridViewTeams.DataSource);
                var currentRow = dataGridViewTeams.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].PathLogo : "";
            }
            set
            {

            }
        }
        #endregion

        #region Class variable.
        private SettingMatchForm _settingMatchForm = null;
        private bool _isGuestSender = false;
        internal bool IsBtnOkClicked { get => _isBtnOkClicked; private set => _isBtnOkClicked = value; }
        private bool _isBtnOkClicked = false;
        #endregion

        public TeamForm()
        {
            InitializeComponent();
            UpdateTable();
        }

        public TeamForm(SettingMatchForm settingMatch, bool isGuestSender)
        {
            InitializeComponent();
            UpdateTable();

            this._settingMatchForm = settingMatch;
            this._isGuestSender = isGuestSender;
        }

        /// <summary>
        /// Update the data in gridView.
        /// </summary>
        private void UpdateTable()
        {
            TeamPresenter presenter = new TeamPresenter(this);
            // Set table with data from database.
            dataGridViewTeams.DataSource = presenter.GetViews();
        }

        private void btnInsertTeam_Click(object sender, EventArgs e)
        {
            SettingTeamForm form = new SettingTeamForm(this);
            form.Show();
            form.FormClosing += (s, ev) =>
            {
                if (form.IsBtnOkClicked && this != null)
                {
                    UpdateTable();
                }
            };
        }

        private void buttonDeleteTeam_Click(object sender, EventArgs e)
        {
            TeamPresenter presenter = new TeamPresenter(this);
            presenter.DeleteModelDB();

            UpdateTable();
        }

        private void buttonTeamOk_Click(object sender, EventArgs e)
        {
            _isBtnOkClicked = true;

            this.Close();
        }

        private void buttonTeamCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonChangeTeam_Click(object sender, EventArgs e)
        {
            SettingTeamForm form = new SettingTeamForm(this, true);
            form.Show();
            form.FormClosing += (s, ev) =>
            {
                if (form.IsBtnOkClicked && this != null)
                {
                    UpdateTable();
                }
            };
        }

        private void dataGridViewTeams_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBoxLogo.Image = Image.FromFile(PathLogo);
                pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                Logger.Log.Warn("Изображение команды не нашлось или не удалось загрузить!", ex);

                // Show error image.
                pictureBoxLogo.Image = pictureBoxLogo.ErrorImage;
                pictureBoxLogo.SizeMode = PictureBoxSizeMode.Normal;
            }
        }
    }
}
