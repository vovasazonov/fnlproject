using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Enums;
using FNL.Views;
using ModelLayer;
using ModelLayer.Models;

namespace FNL.Presenters
{
    public class TablePlayersMainPresenter
    {

        public List<ITablePlayersMainView> GetViews(int matchId, PersonAccessory category, bool isSpare)
        {
            if (category == PersonAccessory.FaceMatch)
            {
                return null;
            }

            List<ITablePlayersMainView> playersView = new List<ITablePlayersMainView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var currentMatch = db.Matches.Where(m => m.MatchId == matchId).FirstOrDefault();
                int? idTeam = category == PersonAccessory.GuestTeam ? currentMatch.TeamGuestId : currentMatch.TeamOwnerId;

                if (idTeam == null)
                {
                    return null;
                }

                //var playersTeam = db.TeamPlayers.Where(t => t.TeamId == idTeam);
                var playersMatch = db.PlayersMatches.Where(t => t.MatchId == matchId && t.TeamId == idTeam && t.IsSpare == isSpare);

                // Get data drom database.
                foreach (var player in playersMatch)
                {
                    ITablePlayersMainView playerView = new ClassTablePlayersMainView();

                    playerView.PersonId = player.PersonId;
                    var playerTeam = db.TeamPlayers.Where(t => t.PersonId == player.PersonId).FirstOrDefault();
                    playerView.N = playerTeam != null ? (int)playerTeam.NumberPlayer : 0;
                    playerView.LastName = player.Person.LastName;
                    playerView.FirstName = player.Person.FirstName;
                    playerView.R = player.Person.Role != null ? player.Person.Role.Name : "";
                    //playerView.K = 
                    playerView.A = playerTeam != null ? playerTeam.Amplua != null ? playerTeam.Amplua.Name : "" : "";

                    playersView.Add(playerView);
                }
            }

            return playersView;
        }

        /// <summary>
        /// Chose only views that not contains in match players.
        /// </summary>
        /// <param name="matchId"></param>
        /// <param name="category"></param>
        /// <param name="isSpare"></param>
        /// <returns></returns>
        public List<ITablePlayersMainView> GetViewsNotChosed(int matchId, PersonAccessory category)
        {
            List<ITablePlayersMainView> views = new List<ITablePlayersMainView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                // ---------------------------------
                var currentMatch = db.Matches.Where(m => m.MatchId == matchId).FirstOrDefault();
                int? idTeam = category == PersonAccessory.GuestTeam ? currentMatch.TeamGuestId : currentMatch.TeamOwnerId;

                if (idTeam == null)
                {
                    return null;
                }

                var playersTeam = db.TeamPlayers.Where( t=> t.TeamId == idTeam);

                // Get data drom database.
                foreach (var player in playersTeam)
                {
                    ITablePlayersMainView playerView = new ClassTablePlayersMainView();

                    playerView.PersonId = player.PersonId;
                    var playerTeam = db.TeamPlayers.Where(t => t.PersonId == player.PersonId).FirstOrDefault();
                    playerView.N = playerTeam != null ? (int)playerTeam.NumberPlayer : 0;
                    playerView.LastName = player.Person.LastName;
                    playerView.FirstName = player.Person.FirstName;
                    playerView.R = player.Person.Role != null ? player.Person.Role.Name : "";
                    //playerView.K = 
                    playerView.A = playerTeam != null ? playerTeam.Amplua != null ? playerTeam.Amplua.Name : "" : "";

                    views.Add(playerView);
                }
                // ---------------------------------
                var match = db.Matches.Where(t => t.MatchId == matchId).FirstOrDefault();

                var chosedPlayers = match != null ? match.PlayersMatch : null;

                var idsPlayers = chosedPlayers != null ? chosedPlayers.Select(i => i.PersonId) : null;

                List<ITablePlayersMainView> tempView = new List<ITablePlayersMainView>();
                foreach (var view in views)
                {
                    if (idsPlayers != null)
                    {
                        if (idsPlayers.Contains(view.PersonId))
                        {
                            tempView.Add(view);
                        }
                    }
                }
                foreach (var view in tempView)
                {
                    views.Remove(view);
                }
            }

            return views;

        }
    }
}
