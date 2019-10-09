using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Views;
using ModelLayer;

namespace FNL.Presenters
{
    public class MatchPresenter
    {
        private IMatchView _matchView;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="matchView"></param>
        public MatchPresenter(IMatchView matchView)
        {
            this._matchView = matchView;
        }

        /// <summary>
        /// Return data from database.
        /// </summary>
        /// <returns></returns>
        public List<IMatchView> GetMatches()
        {
            List<IMatchView> matchesView = new List<IMatchView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var matches = db.Matches;

                // Get data drom database.
                foreach (var match in matches)
                {
                    IMatchView matchView = new ClassMatchView();

                    if (match.CommentatorsMatch != null)
                    {
                        if (match.CommentatorsMatch.Count > 0)
                        {
                            matchView.CommentatorsMatch1 = string.Format("{0} {1} {2}",
                                match.CommentatorsMatch[0].Person.LastName,
                                match.CommentatorsMatch[0].Person.FirstName,
                                match.CommentatorsMatch[0].Person.MiddleName);
                        }

                        if (match.CommentatorsMatch.Count > 1)
                        {
                            matchView.CommentatorsMatch2 = string.Format("{0} {1} {2}",
                                match.CommentatorsMatch[1].Person.LastName,
                                match.CommentatorsMatch[1].Person.FirstName,
                                match.CommentatorsMatch[1].Person.MiddleName);
                        }
                    }
                    matchView.Date = match.Date;
                    //matchView.GoalsGuest = match.Statistics.
                    //matchView.GoalsOwner = match.Statistics.
                    matchView.MatchId = match.MatchId;
                    matchView.NameMatch = match.Name;
                    matchView.NameSeason = match.Season != null ? match.Season.Name : "";
                    matchView.NameStadium = match.Stadium != null ? match.Stadium.Name : "";
                    matchView.NameTeamGuest = match.TeamGuestId != null ? db.Teams.Where(i => i.TeamId == match.TeamGuestId).FirstOrDefault().NameFull : "";
                    matchView.NameTeamOwner = match.TeamOwnerId != null ? db.Teams.Where(i => i.TeamId == match.TeamOwnerId).FirstOrDefault().NameFull : "";

                    matchesView.Add(matchView);
                }
            }

            return matchesView;
        }

        public void DeleteMatchFromDatabase(int idMatch)
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var query = from m in db.Matches
                            where m.MatchId == idMatch
                            select m;

                db.Matches.Remove(query.FirstOrDefault());

                db.SaveChanges();
            }
        }

    }
}
