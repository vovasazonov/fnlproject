using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Views;
using ModelLayer;
using ModelLayer.Models;

namespace FNL.Presenters
{
    public class SettingTeamPresenter
    {
        ISettingTeamView settingTeamView;

        public SettingTeamPresenter(ISettingTeamView teamView)
        {
            this.settingTeamView = teamView;
        }

        /// <summary>
        /// Conver view to model.
        /// </summary>
        /// <returns></returns>
        private Team GetModelTeamFromView()
        {
            Team model = new Team();

            using (DbFnlContext db = new DbFnlContext())
            {
                //model.Color = settingTeamView.ColorTeam.ToArgb();
                model.LogotypePath = settingTeamView.PathTeamLogo;
                model.NameFull = settingTeamView.NameTeamFull;
                model.NameShort = settingTeamView.NameTeamShort;
            }

            return model;
        }

        public void InsertTeam()
        {

            using (DbFnlContext db = new DbFnlContext())
            {
                Team teamModel = GetModelTeamFromView();

                try
                {
                    db.Teams.Add(teamModel);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
    }
}
