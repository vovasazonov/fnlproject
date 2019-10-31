using System;
using System.Collections.Generic;
using System.Drawing;
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
        private ISettingTeamView _view;

        public SettingTeamPresenter(ISettingTeamView view)
        {
            this._view = view;
        }

        /// <summary>
        /// Convert view to model.
        /// </summary>
        /// <returns></returns>
        private Team GetModelFromView()
        {
            Team model = new Team();

            using (DbFnlContext db = new DbFnlContext())
            {
                model = db.Teams.Where(t => t.TeamId == _view.TeamId).FirstOrDefault() ?? new Team();
                model.Color = _view.Color.ToArgb();
                model.NameFull = _view.NameFull;
                model.NameShort = _view.NameShort;
                model.LogotypePath = _view.PathLogo;
            }

            return model;
        }

        /// <summary>
        /// Update record in database. Take data from view.
        /// </summary>
        public void UpdateModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Team teamModel = GetModelFromView();

                // Say to database that this model is consist and changed.
                db.Entry(teamModel).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Insert record to Team in database. Take data from view.
        /// </summary>
        public void InsertModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Team teamModel = GetModelFromView();
                db.Teams.Add(teamModel);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Take record from database and show in view.
        /// </summary>
        /// <returns></returns>
        public void ShowModelInView()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Team team = db.Teams.Where(t => t.TeamId == _view.TeamId).FirstOrDefault() ?? new Team();

                _view.TeamId = team.TeamId;
                _view.Color = Color.FromArgb(team.Color);
                _view.NameFull = team.NameFull;
                _view.NameShort = team.NameShort;
                _view.PathLogo = team.LogotypePath;
            }
        }


    }
}
