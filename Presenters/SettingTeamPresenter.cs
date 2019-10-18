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
                model.TeamId = _view.IdTeam;
                model.Color = _view.ColorTeam.ToArgb();
                model.NameFull = _view.NameTeamFull;
                model.NameShort = _view.NameTeamShort;
                model.LogotypePath = _view.PathTeamLogo;
                //model.TeamPlayers = db.TeamPlayers.Where(tp=>tp.per)
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

                //foreach (var idPerson in _view.IdsPlayers)
                //{
                //    TeamPlayer teamPlayer = db.TeamPlayers.Where(tp => tp.TeamId == teamModel.TeamId && tp.PersonId == idPerson).FirstOrDefault();
                //    if (teamPlayer != null)
                //    {
                //        teamModel.TeamPlayers.Add(teamPlayer);
                //    }
                //}

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
        public void ShowModelInView(int idTeam)
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Team team = (from m in db.Teams
                             where m.TeamId == idTeam
                             select m).FirstOrDefault();

                _view.IdTeam = team.TeamId;
                _view.ColorTeam = Color.FromArgb(team.Color);
                _view.NameTeamFull = team.NameFull;
                _view.NameTeamShort = team.NameShort;
                _view.PathTeamLogo = team.LogotypePath;

                _view.IdsPlayers = db.TeamPlayers.Where(t => t.TeamId == team.TeamId).Select(t => t.PersonId).ToList();
            }
        }


    }
}
