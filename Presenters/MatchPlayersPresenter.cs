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
    public class MatchPlayersPresenter
    {
        private IMatchPlayersView _view;

        public MatchPlayersPresenter(IMatchPlayersView matchPlayersView)
        {
            _view = matchPlayersView;
        }

        public List<IMatchPlayersView> GetViews(PersonAccessory category, int idMatch)
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
                    case PersonAccessory.FaceMatch:
                        people = queryActors;
                        break;
                    case PersonAccessory.HomeTeam:
                        people = queryOwnerTeam;
                        break;
                    case PersonAccessory.GuestTeam:
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

        public void DeleteModelDB(PersonAccessory category, int idMatch)
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Match currentMatch = db.Matches.Where(i => i.MatchId == idMatch).FirstOrDefault();

                switch (category)
                {
                    case PersonAccessory.FaceMatch:
                        var query1 = db.FacesMatches.Where(t => t.MatchId == idMatch && t.PersonId == _view.IdPerson);
                        db.FacesMatches.Remove(query1.FirstOrDefault());
                        break;
                    case PersonAccessory.HomeTeam:
                        var query2 = db.PlayersMatches.Where(t => t.TeamId == currentMatch.TeamOwnerId && t.PersonId == _view.IdPerson);
                        db.PlayersMatches.Remove(query2.FirstOrDefault());
                        break;
                    case PersonAccessory.GuestTeam:
                        var query3 = db.PlayersMatches.Where(t => t.TeamId == currentMatch.TeamGuestId && t.PersonId == _view.IdPerson);
                        db.PlayersMatches.Remove(query3.FirstOrDefault());
                        break;
                    default:
                        break;
                }

                db.SaveChanges();
            }

        }

        public void InsertModelDB(PersonAccessory category, int idMatch)
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Match currentMatch = db.Matches.Where(i => i.MatchId == idMatch).FirstOrDefault();

                switch (category)
                {
                    case PersonAccessory.FaceMatch:
                         FaceMatch model = new FaceMatch { MatchId = idMatch, PersonId = _view.IdPerson };
                        db.FacesMatches.Add(model);
                        break;
                    case PersonAccessory.HomeTeam:
                        if (currentMatch.TeamOwnerId != null)
                        {
                            PlayerMatch playerHome = new PlayerMatch { MatchId = idMatch, TeamId = (int)currentMatch.TeamOwnerId, PersonId = _view.IdPerson, IsSpare = _view.IsSpare };
                            db.PlayersMatches.Add(playerHome);

                        }

                        break;
                    case PersonAccessory.GuestTeam:
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
}
