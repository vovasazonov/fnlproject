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
        IMatchView matchView;

        public MatchPresenter(IMatchView matchView)
        {
            this.matchView = matchView;
        }

        /// <summary>
        /// Return data from database.
        /// </summary>
        /// <returns>matches.</returns>
        public List<IMatchView> GetMatches()
        {
            List<IMatchView> matchesView = new List<IMatchView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var matches = db.Matches;

                // Get data drom database.
                foreach (var match in matches)
                {
                    HelperMatchView matchView = new HelperMatchView();

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

                    matchView.NameSeason = match.SeasonId != null ? db.Seasons.Where(i=>i.SeasonId == match.SeasonId).FirstOrDefault().Name : "";

                    matchView.NameStadium = match.StadiumId != null ? db.Stadiums.Where(i => i.StadiumId == match.StadiumId).FirstOrDefault().Name : "";

                    matchView.NameTeamGuest = match.TeamGuestId != null ? db.Teams.Where(i => i.TeamId == match.TeamGuestId).FirstOrDefault().NameFull : "";

                    matchView.NameTeamOwner = match.TeamOwner != null ? db.Teams.Where(i => i.TeamId == match.TeamOwnerId).FirstOrDefault().NameFull : "";

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

        class HelperMatchView : IMatchView
        {
            public int MatchId { get; set; }
            public string NameMatch { get; set; }
            public DateTime Date { get; set; }
            public string NameStadium { get; set; }
            public string NameSeason { get; set; }
            public string NameTeamGuest { get; set; }
            public int GoalsGuest { get; set; }
            public string NameTeamOwner { get; set; }
            public int GoalsOwner { get; set; }
            public string CommentatorsMatch1 { get; set; }
            public string CommentatorsMatch2 { get; set; }
        }

    }
}
