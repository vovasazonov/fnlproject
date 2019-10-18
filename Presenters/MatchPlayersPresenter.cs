using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Views;
using ModelLayer.Models;
using ModelLayer;

namespace FNL.Presenters
{
    public class MatchPlayersPresenter
    {
        private IMatchPlayersView _view;

        public MatchPlayersPresenter(IMatchPlayersView matchPlayersView)
        {
            _view = matchPlayersView;
        }

        public List<IMatchPlayersView> GetViews(CategoryTable category, int idMatch)
        {
            List<IMatchPlayersView> playersView = new List<IMatchPlayersView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                Match currentMatch = db.Matches.Where(i => i.MatchId == idMatch).FirstOrDefault();

                var queryOwnerTeam = currentMatch.PlayersMatch.Where(t => t.TeamId == currentMatch.TeamOwnerId).Select(p => p.Person);
                var queryGuestTeam = currentMatch.PlayersMatch.Where(t => t.TeamId == currentMatch.TeamGuestId).Select(p => p.Person);
                var queryActors = db.CommentatorsMatches.Where(t => t.MatchId == idMatch).Select(p => p.Person);
                var quertytest = db.CommentatorsMatches.ToList();
                IEnumerable<Person> people = new List<Person>();
                switch (category)
                {
                    case CategoryTable.Actor:
                        people = queryActors;
                        break;
                    case CategoryTable.HomeTeam:
                        people = queryOwnerTeam;
                        break;
                    case CategoryTable.GuestTeam:
                        people = queryGuestTeam;
                        break;
                    default:
                        break;
                }

                // Get data drom database.
                foreach (var person in people)
                {
                    IMatchPlayersView playerView = new ClassMatchPlayersView();

                    playerView.IdPerson = person.PersonId;
                    var playerTeam = db.TeamPlayers.Where(t => t.PersonId == person.PersonId).FirstOrDefault();
                    playerView.Number = playerTeam != null ? (int)playerTeam.NumberPlayer : 0;
                    playerView.FirstName = person.FirstName;
                    playerView.LastName = person.LastName;
                    playerView.MiddleName = person.MiddleName;
                    playerView.Role = person.Role != null ? person.Role.Name : "";
                    playerView.Amplua = playerTeam != null ? playerTeam.Amplua != null ? playerTeam.Amplua.Name : "" : "";
                    var matchPlayer = db.PlayersMatches.Where(t => t.PersonId == person.PersonId && t.MatchId == idMatch).FirstOrDefault();
                    playerView.IsSpare = matchPlayer != null ? matchPlayer.IsSpare : false;

                    playersView.Add(playerView);
                }
            }

            return playersView;
        }

        public void DeleteModelDB(CategoryTable category, int idMatch)
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Match currentMatch = db.Matches.Where(i => i.MatchId == idMatch).FirstOrDefault();

                switch (category)
                {
                    case CategoryTable.Actor:
                        var query1 = db.CommentatorsMatches.Where(t => t.MatchId == idMatch && t.PersonId == _view.IdPerson);
                        db.CommentatorsMatches.Remove(query1.FirstOrDefault());
                        break;
                    case CategoryTable.HomeTeam:
                        var query2 = db.PlayersMatches.Where(t => t.TeamId == currentMatch.TeamOwnerId && t.PersonId == _view.IdPerson);
                        db.PlayersMatches.Remove(query2.FirstOrDefault());
                        break;
                    case CategoryTable.GuestTeam:
                        var query3 = db.PlayersMatches.Where(t => t.TeamId == currentMatch.TeamGuestId && t.PersonId == _view.IdPerson);
                        db.PlayersMatches.Remove(query3.FirstOrDefault());
                        break;
                    default:
                        break;
                }

                db.SaveChanges();
            }

        }

        public void InsertModelDB(CategoryTable category, int idMatch)
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Match currentMatch = db.Matches.Where(i => i.MatchId == idMatch).FirstOrDefault();

                switch (category)
                {
                    case CategoryTable.Actor:
                         CommentatorMatch model = new CommentatorMatch { MatchId = idMatch, PersonId = _view.IdPerson };
                        db.CommentatorsMatches.Add(model);
                        break;
                    case CategoryTable.HomeTeam:
                        if (currentMatch.TeamOwnerId != null)
                        {
                            PlayerMatch playerHome = new PlayerMatch { MatchId = idMatch, TeamId = (int)currentMatch.TeamOwnerId, PersonId = _view.IdPerson, IsSpare = _view.IsSpare };
                            db.PlayersMatches.Add(playerHome);

                        }

                        break;
                    case CategoryTable.GuestTeam:
                        if (currentMatch.TeamGuestId != null)
                        {
                            PlayerMatch playerGuest = new PlayerMatch { MatchId = idMatch, TeamId = (int)currentMatch.TeamGuestId, PersonId = _view.IdPerson, IsSpare = _view.IsSpare };
                            db.PlayersMatches.Add(playerGuest);

                        }

                        break;
                    default:
                        break;
                }

                db.SaveChanges();

            }

        }

    }

    public enum CategoryTable
    {
        Actor,
        HomeTeam,
        GuestTeam
    }
}
