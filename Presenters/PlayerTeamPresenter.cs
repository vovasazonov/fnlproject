using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using ModelLayer.Models;
using FNL.Views;

namespace FNL.Presenters
{
    internal class PlayerTeamPresenter
    {
        private IPlayerTeamView _view;

        internal PlayerTeamPresenter(IPlayerTeamView view)
        {
            _view = view;
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
                var players = db.People;

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
        /// Delete record from database.
        /// </summary>
        internal void DeleteModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var query = from m in db.TeamPlayers
                            where m.PersonId == _view.PersonId
                            where m.TeamId == _view.TeamId
                            select m;

                db.TeamPlayers.Remove(query.FirstOrDefault());

                db.SaveChanges();
            }
        }

    }
}
