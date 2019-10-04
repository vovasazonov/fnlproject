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
        public List<IMatchView> GetMatchesFromDatabase()
        {
            List<IMatchView> matchesView = new List<IMatchView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var matches = db.Matches;

                // Get data drom database.
                foreach (var match in matches)
                {
                    HelperMatchView matchView = new HelperMatchView();

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

                    matchView.Date = match.Date;

                    //matchView.GoalsGuest = match.Statistics.
                    //matchView.GoalsOwner = match.Statistics.

                    matchView.MatchId = match.MatchId;

                    matchView.NameMatch = match.Name;

                    matchView.NameSeason = match.Season.Name;

                    matchView.NameStadium = match.Stadium.Name;

                    matchView.NameTeamGuest = string.Format("{0} ({1})", match.TeamGuest.NameFull, match.TeamGuest.NameShort);

                    matchView.NameTeamOwner = string.Format("{0} ({1})", match.TeamOwner.NameFull, match.TeamOwner.NameShort);

                    matchesView.Add(matchView);
                }
            }

            return matchesView;
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
