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
        private ISettingTeamView _settingTeamView;

        public SettingTeamPresenter(ISettingTeamView teamView)
        {
            this._settingTeamView = teamView;
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
                model.LogotypePath = _settingTeamView.PathTeamLogo;
                model.NameFull = _settingTeamView.NameTeamFull;
                model.NameShort = _settingTeamView.NameTeamShort;
            }

            return model;
        }

        public void UpdateTeam()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                try
                {
                    Team teamModel = GetModelTeamFromView();

                    // Say to database that this model is consist and changed.
                    db.Entry(teamModel).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
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

        /// <summary>
        /// Return data from database.
        /// </summary>
        /// <returns>matches.</returns>
        public void ShowTeamInView(int idTeam)
        {

            using (DbFnlContext db = new DbFnlContext())
            {
                Team team = (from m in db.Teams
                             where m.TeamId == idTeam
                             select m).FirstOrDefault();

                _settingTeamView.IdTeam = team.TeamId;
                _settingTeamView.ColorTeam = Color.FromArgb(team.Color);
                _settingTeamView.NameTeamFull = team.NameFull;
                _settingTeamView.NameTeamShort = team.NameShort;
                _settingTeamView.PathTeamLogo = team.LogotypePath;

                _settingTeamView.IdsPlayers = db.TeamPlayers.Where(t => t.TeamId == team.TeamId).Select(t => t.PersonId).ToList();
            }
        }

        /// <summary>
        /// Return data from database.
        /// </summary>
        /// <returns></returns>
        public List<ITablePlayerTeamView> GetPlayersTeam()
        {
            List<ITablePlayerTeamView> playersView = new List<ITablePlayerTeamView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var playersTeam = db.TeamPlayers.Where(t => t.TeamId == _settingTeamView.IdTeam);

                // Get data drom database.
                foreach (var player in playersTeam)
                {
                    ITablePlayerTeamView playerView = new ClassSettingPlayerTeamView();

                    playerView.IdPerson = player.PersonId;
                    playerView.Number = (int)player.NumberPlayer;
                    playerView.FirstName = player.Person.FirstName;
                    playerView.LastName = player.Person.LastName;
                    playerView.MiddleName = player.Person.MiddleName;
                    playerView.Role = player.Person.Role != null ? player.Person.Role.Name : "";
                    playerView.Amplua = player.Amplua != null ? player.Amplua.Name : "";

                    playersView.Add(playerView);
                }
            }

            return playersView;
        }

        public void DeletePlayerTeamFromDatabase(int idPerson)
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var query = from m in db.TeamPlayers
                            where m.PersonId == idPerson
                            where m.TeamId == _settingTeamView.IdTeam
                            select m;

                db.TeamPlayers.Remove(query.FirstOrDefault());

                db.SaveChanges();
            }
        }

    }
}
