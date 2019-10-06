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
    public partial class SettingTeam : Form,ISettingTeamView
    {
        public SettingTeam()
        {
            InitializeComponent();
        }

        public SettingTeam(TeamsForm teamForm)
        {
            InitializeComponent();

            this.isEdit = isEdit;
            this.teamForm = teamForm;
            this.idTeam = idTeam;

            if (isEdit)
            {
                //SettingTeamPresenter settingTeamPresenter = new SettingTeamPresenter(this);
                //settingTeamPresenter.ShowTeamInView(this.idTeam);
            }
        }


        TeamsForm teamForm = new TeamsForm();
        bool isEdit = false;
        int idTeam = -1;

        public int IdTeam { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Color ColorTeam { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NameTeamFull { get => textNameFullTeam.Text; set => textNameFullTeam.Text = value; }
        public string NameTeamShort { get => textNameShortTeam.Text; set => textNameShortTeam.Text = value; }
        public string PathTeamLogo { get => comboBoxPathLogo.Text; set => comboBoxPathLogo.Text = value; }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void buttonSetTeamOk_Click(object sender, EventArgs e)
        {
            SettingTeamPresenter settingTeamPresenter = new SettingTeamPresenter(this);

            if (isEdit)
            {
                //settingMatchPresenter.UpdateMatch(idMatch);
            }
            else
            {
                settingTeamPresenter.InsertTeam();
            }

            teamForm.UpdateTable();

            this.Close();
        }
    }
}
