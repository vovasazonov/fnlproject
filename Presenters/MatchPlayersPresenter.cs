using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Views;
using ModelLayer.Models;
using ModelLayer;
using FNL.Enums;

namespace FNL.Presenters
{
    internal class MatchPlayersPresenter
    {
        private IMatchPlayersView _view;

        internal MatchPlayersPresenter(IMatchPlayersView matchPlayersView)
        {
            _view = matchPlayersView;
        }

        internal List<IMatchPlayersView> GetViews(PersonCategoryType category, int idMatch)
        {
            List<IMatchPlayersView> playersView = new List<IMatchPlayersView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                Match currentMatch = db.Matches.Where(i => i.MatchId == idMatch).FirstOrDefault();

                var queryOwnerTeam = currentMatch.PlayersMatch.Where(t => t.TeamId == currentMatch.TeamOwnerId).Select(p => p.Person);
                var queryGuestTeam = currentMatch.PlayersMatch.Where(t => t.TeamId == currentMatch.TeamGuestId).Select(p => p.Person);
                var queryActors = db.FacesMatches.Where(t => t.MatchId == idMatch).Select(p => p.Person);
                var quertytest = db.FacesMatches.ToList();
                IEnumerable<Person> people = new List<Person>();
                switch (category)
                {
                    case PersonCategoryType.FaceMatch:
                        people = queryActors;
                        break;
                    case PersonCategoryType.HomeTeam:
                        people = queryOwnerTeam;
                        break;
                    case PersonCategoryType.GuestTeam:
                        people = queryGuestTeam;
                        break;
                    default:
                        break;
                }

                // Get data drom database.
                foreach (var person in people)
                {
                    IMatchPlayersView playerView = new CMatchPlayersView();

                    playerView.PersonId = person.PersonId;
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

        internal void DeleteModelDB(PersonCategoryType category, int idMatch)
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Match currentMatch = db.Matches.Where(i => i.MatchId == idMatch).FirstOrDefault();

                switch (category)
                {
                    case PersonCategoryType.FaceMatch:
                        var query1 = db.FacesMatches.Where(t => t.MatchId == idMatch && t.PersonId == _view.PersonId);
                        db.FacesMatches.Remove(query1.FirstOrDefault());
                        break;
                    case PersonCategoryType.HomeTeam:
                        var query2 = db.PlayersMatches.Where(t => t.TeamId == currentMatch.TeamOwnerId && t.PersonId == _view.PersonId);
                        db.PlayersMatches.Remove(query2.FirstOrDefault());
                        break;
                    case PersonCategoryType.GuestTeam:
                        var query3 = db.PlayersMatches.Where(t => t.TeamId == currentMatch.TeamGuestId && t.PersonId == _view.PersonId);
                        db.PlayersMatches.Remove(query3.FirstOrDefault());
                        break;
                    default:
                        break;
                }

                db.SaveChanges();
            }

        }

        internal void InsertModelDB(PersonCategoryType category, int idMatch)
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Match currentMatch = db.Matches.Where(i => i.MatchId == idMatch).FirstOrDefault();

                switch (category)
                {
                    case PersonCategoryType.FaceMatch:
                         FaceMatch model = new FaceMatch { MatchId = idMatch, PersonId = _view.PersonId };
                        db.FacesMatches.Add(model);
                        break;
                    case PersonCategoryType.HomeTeam:
                        if (currentMatch.TeamOwnerId != null)
                        {
                            PlayerMatch playerHome = new PlayerMatch { MatchId = idMatch, TeamId = (int)currentMatch.TeamOwnerId, PersonId = _view.PersonId, IsSpare = _view.IsSpare };
                            db.PlayersMatches.Add(playerHome);

                        }

                        break;
                    case PersonCategoryType.GuestTeam:
                        if (currentMatch.TeamGuestId != null)
                        {
                            PlayerMatch playerGuest = new PlayerMatch { MatchId = idMatch, TeamId = (int)currentMatch.TeamGuestId, PersonId = _view.PersonId, IsSpare = _view.IsSpare };
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
}
