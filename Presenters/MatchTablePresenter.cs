using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Views;
using ModelLayer;
using ModelLayer.Models;
using FNL.Enums;

namespace FNL.Presenters
{
    public class MatchTablePresenter
    {
        private IMatchTableView _view;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="view"></param>
        public MatchTablePresenter(IMatchTableView view)
        {
            this._view = view;
        }

        /// <summary>
        /// Return data from database.
        /// </summary>
        /// <returns></returns>
        public List<IMatchTableView> GetViews()
        {
            List<IMatchTableView> views = new List<IMatchTableView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var matches = db.Matches;

                // Get data drom database.
                foreach (var match in matches)
                {
                    IMatchTableView matchView = new CMatchTableView();

                    matchView.MatchId = match.MatchId;
                    matchView.NameMatch = match.Name;
                    matchView.Date = match.Date;
                    matchView.NameStadium = match.Stadium != null ? match.Stadium.Name : "";
                    matchView.NameSeason = match.Season != null ? match.Season.Name : "";
                    matchView.NameTeamGuest = match.TeamGuestId != null ? db.Teams.Where(i => i.TeamId == match.TeamGuestId).FirstOrDefault().NameFull : "";
                    //matchView.GoalsGuest { get; set; }
                    matchView.NameTeamOwner = match.TeamOwnerId != null ? db.Teams.Where(i => i.TeamId == match.TeamOwnerId).FirstOrDefault().NameFull : "";
                    //matchView.GoalsOwner { get; set; }
                    foreach (var face in match.FaceMatch)
                    {
                        switch ((RoleType)(face.Person.RoleId))
                        {
                            case RoleType.Commentator:
                                // Should be 2 commentators.
                                break;
                            case RoleType.MainJudje:
                                break;
                            case RoleType.HelperJudje:
                                // Should be 2 helpers judje.
                                break;
                            case RoleType.PairJudje:
                                break;
                            case RoleType.Inspector:
                                break;
                            case RoleType.Delegat:
                                break;
                            default:
                                break;
                        }
                    }

                    //matchView.CommentatorsMatch1 = match.CommentatorsMatch.Where(t=>t.)
                    //matchView.CommentatorsMatch2 { get; set; }
                    //matchView.MainJudje = match.FaceMatch.Where(t=>t.)
                    //matchView.HelperJudje1 { get; set; }
                    //matchView.HelperJudje2 { get; set; }
                    //matchView.PairJudje { get; set; }
                    //matchView.Inspector { get; set; }
                    //matchView.Delegat { get; set; }


                    views.Add(matchView);
                }
            }

            return views;
        }

        /// <summary>
        /// Delete record from data base.
        /// </summary>
        /// <param name="idMatch"></param>
        public void DelteModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var query = from m in db.Matches
                            where m.MatchId == _view.MatchId
                            select m;

                db.Matches.Remove(query.FirstOrDefault());

                db.SaveChanges();
            }
        }

    }
}
