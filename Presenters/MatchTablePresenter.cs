using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Views;
using ModelLayer;

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
        public List<IMatchTableView> GetView()
        {
            List<IMatchTableView> views = new List<IMatchTableView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var matches = db.Matches;

                // Get data drom database.
                foreach (var match in matches)
                {
                    IMatchTableView matchView = new ClassMatchTableView();

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
