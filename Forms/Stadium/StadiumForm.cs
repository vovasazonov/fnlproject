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

namespace FNL.Forms
{
    public partial class StadiumForm : Form, IStadiumView
    {
        #region View variables.
        public string StadiumName
        {
            get
            {
                var dataSource = (List<IStadiumView>)(dataGridViewStadium.DataSource);
                var currentRow = dataGridViewStadium.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].StadiumName : "";
            }
            set
            {

            }
        }
        public int StadiumId
        {
            get
            {
                var dataSource = (List<IStadiumView>)(dataGridViewStadium.DataSource);
                var currentRow = dataGridViewStadium.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].StadiumId : -1;
            }
            set
            {

            }
        }
        public string CountryName
        {
            get
            {
                var dataSource = (List<IStadiumView>)(dataGridViewStadium.DataSource);
                var currentRow = dataGridViewStadium.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].CountryName : "";
            }
            set
            {

            }
        }
        public string CityName
        {
            get
            {
                var dataSource = (List<IStadiumView>)(dataGridViewStadium.DataSource);
                var currentRow = dataGridViewStadium.CurrentRow;
                return currentRow != null ? dataSource[currentRow.Index].CityName : "";
            }
            set
            {

            }
        }
        #endregion

        #region Class variables.
        private SettingMatchForm _settingMatchForm = null;
        internal bool IsBtnOkClicked { get => _isBtnOkClicked; private set => _isBtnOkClicked = value; }

        private bool _isBtnOkClicked = false;
        #endregion

        public StadiumForm()
        {
            InitializeComponent();
        }

        public StadiumForm(SettingMatchForm settingMatchForm)
        {
            InitializeComponent();

            _settingMatchForm = settingMatchForm;

            UpdateTable();
        }

        /// <summary>
        /// Update the data in gridView.
        /// </summary>
        private void UpdateTable()
        {
            StadiumPresenter presenter = new StadiumPresenter(this);
            // Set table with data from database.
            dataGridViewStadium.DataSource = presenter.GetViews();
        }

        private void buttonInsertStadium_Click(object sender, EventArgs e)
        {
            SettingStadium form = new SettingStadium(this);
            form.Show();
            form.FormClosing += (s, ev) =>
            {
                if (form.IsBtnOkClicked && this != null)
                {
                    UpdateTable();
                }
            };
        }

        private void buttonChangeStadium_Click(object sender, EventArgs e)
        {
            SettingStadium form = new SettingStadium(this, true);
            form.Show();
            form.FormClosing += (s, ev) =>
            {
                if (form.IsBtnOkClicked && this != null)
                {
                    UpdateTable();
                }
            };
        }

        private void buttonDeleteStadium_Click(object sender, EventArgs e)
        {
            StadiumPresenter presenter = new StadiumPresenter(this);
            if (!presenter.DeleteModelDB()) MessageBoxFNL.MessageErrorDb();

            UpdateTable();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (_settingMatchForm != null)
            {
                _settingMatchForm.NameStadium = StadiumName;
                _settingMatchForm.StadiumId = StadiumId;
            }

            _isBtnOkClicked = true;

            this.Close();
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
