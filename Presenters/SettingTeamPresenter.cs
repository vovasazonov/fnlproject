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
    internal class SettingTeamPresenter
    {
        private ISettingTeamView _view;

        internal SettingTeamPresenter(ISettingTeamView view)
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
        /// Return views converted from records of database.
        /// </summary>
        /// <returns></returns>
        internal List<IPlayerTeamView> GetViews()
        {
            List<IPlayerTeamView> playersView = new List<IPlayerTeamView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var players = db.TeamPlayers.Where(t => t.TeamId == _view.TeamId).Select(t => t.Person);

                // Get data drom database.
                foreach (var player in players)
                {
                    IPlayerTeamView playerView = new CSettingPlayerTeamView();

                    playerView.PersonId = player.PersonId;
                    var playerTeam = player.TeamPlayers != null ? player.TeamPlayers.Where(t => t.PersonId == player.PersonId).FirstOrDefault() : null;
                    playerView.Number = player.TeamPlayers != null ? playerTeam != null ? (int)playerTeam.NumberPlayer : 0 : 0;
                    playerView.FirstName = player.FirstName;
                    playerView.LastName = player.LastName;
                    playerView.MiddleName = player.MiddleName;
                    playerView.Role = player.Role != null ? player.Role.Name : "";
                    var teamplayer = player.TeamPlayers != null ? player.TeamPlayers.Where(t => t.PersonId == player.PersonId).FirstOrDefault() : null;
                    var amplua = teamplayer != null ? teamplayer.Amplua : null;
                    playerView.Amplua = amplua != null ? amplua.Name : "";

                    playersView.Add(playerView);
                }
            }

            return playersView;
        }

        /// <summary>
        /// Update record in database. Take data from view.
        /// </summary>
        /// <returns>Restult operation.</returns>
        public bool UpdateModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Team teamModel = GetModelFromView();
                try
                {
                    // Say to database that this model is consist and changed.
                    db.Entry(teamModel).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Logger.Log.Error("Error database operation", ex);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Insert record to Team in database. Take data from view.
        /// </summary>
        /// <returns>Restult operation.</returns>
        public bool InsertModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Team teamModel = GetModelFromView();

                try
                {
                    db.Teams.Add(teamModel);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Logger.Log.Error("Error database operation", ex);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Take record from database and show in view.
        /// </summary>
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
