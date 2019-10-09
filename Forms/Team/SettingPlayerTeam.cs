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
    public partial class SettingPlayerTeam : Form
    {
        public SettingPlayerTeam(SettingTeam settingTeam, bool isEdit = false)
        {
            InitializeComponent();

            this._isEdit = isEdit;
            this._settingTeam = settingTeam;

            if (_isEdit)
            {
                SettingPlayerTeamPresenter settingPlayerTeamPresenter = new SettingPlayerTeamPresenter(this);
                SettingPlayerTeamPresenter.ShowPlayerInView(IdPerson);
                UpdateTable();
            }
        }

        private bool _isEdit;
        private SettingTeam _settingTeam;

        public int IdPerson { get; set; }
        public int Number { get => (int)number.Value; set => number.Value = value; }
    }
}
