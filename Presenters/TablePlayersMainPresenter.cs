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
    public class TablePlayersMainPresenter
    {

        public List<ITablePlayersMainView> GetViews(int matchId, CategoryTable category, bool isSpare)
        {
            if (category == CategoryTable.Actor)
            {
                return null;
            }

            List<ITablePlayersMainView> playersView = new List<ITablePlayersMainView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var currentMatch = db.Matches.Where(m => m.MatchId == matchId).FirstOrDefault();
                int? idTeam = category == CategoryTable.GuestTeam ? currentMatch.TeamGuestId : currentMatch.TeamOwnerId;

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
    }
}
