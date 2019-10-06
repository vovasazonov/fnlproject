using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;
using ModelLayer;
using FNL.Views;

namespace FNL.Presenters
{
    public class SettingMatchPresenter
    {
        ISettingMatchView settingMatchView;

        public SettingMatchPresenter(ISettingMatchView settingMatchView)
        {
            this.settingMatchView = settingMatchView;
        }

        private Match GetModelMatchFromView()
        {
            Match matchModel = new Match();

            using (DbFnlContext db = new DbFnlContext())
            {
                try
                {
                    matchModel.Date = settingMatchView.DateTime;
                    matchModel.Name = settingMatchView.NameMatch;
                    //matchModel.SeasonId = db.Seasons.Where(s => s.Name == settingMatchView.NameSeason).FirstOrDefault().SeasonId;
                    //matchModel.StadiumId = db.Stadiums.Where(s => s.Name == settingMatchView.NameStadium).FirstOrDefault().StadiumId;
                    matchModel.TeamGuestId = db.Teams.Where(t => t.NameFull == settingMatchView.NameGuestTeam).FirstOrDefault().TeamId;
                    matchModel.TeamOwnerId = db.Teams.Where(t => t.NameFull == settingMatchView.NameOwnerTeam).FirstOrDefault().TeamId;
                    //matchModel.CommentatorsMatch = new List<CommentatorMatch>();
                    //matchModel.CommentatorsMatch = new List<CommentatorMatch>();
                    //matchModel.CommentatorsMatch.Add(Ise)
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return matchModel;
        }
        public void InsertMatch()
        {
           
            using (DbFnlContext db = new DbFnlContext())
            {
                Match matchModel = GetModelMatchFromView();

                try
                {
                    db.Matches.Add(matchModel);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public void UpdateMatch(int idMatch)
        {

        }

        /// <summary>
        /// Return data from database.
        /// </summary>
        /// <returns>matches.</returns>
        public void ShowMatchInView(int idMatch)
        {

            using (DbFnlContext db = new DbFnlContext())
            {
                Match match = (from theMatch in db.Matches
                            where theMatch.MatchId == idMatch
                            select theMatch).FirstOrDefault();


                //if (match.CommentatorsMatch != null)
                //{
                //    if (match.CommentatorsMatch.Count > 0)
                //    {
                //        matchView.NameCommentator1 = string.Format("{0} {1} {2}",
                //            match.CommentatorsMatch[0].Person.LastName,
                //            match.CommentatorsMatch[0].Person.FirstName,
                //            match.CommentatorsMatch[0].Person.MiddleName);
                //    }

                //    if (match.CommentatorsMatch.Count > 1)
                //    {
                //        matchView.CommentatorsMatch2 = string.Format("{0} {1} {2}",
                //            match.CommentatorsMatch[1].Person.LastName,
                //            match.CommentatorsMatch[1].Person.FirstName,
                //            match.CommentatorsMatch[1].Person.MiddleName);
                //    }
                //}

                settingMatchView.DateTime = match.Date;

                //matchView.GoalsGuest = match.Statistics.
                //matchView.GoalsOwner = match.Statistics.

                settingMatchView.NameMatch = match.Name;
                settingMatchView.NameSeason = match.Season != null ? match.Season.Name : "";
                settingMatchView.NameStadium = match.Stadium != null ? match.Stadium.Name : "";
                settingMatchView.NameGuestTeam = match.TeamGuest != null ? string.Format("{0} ({1})", match.TeamGuest.NameFull, match.TeamGuest.NameShort) : "";
                settingMatchView.NameOwnerTeam = match.TeamOwner != null ? string.Format("{0} ({1})", match.TeamOwner.NameFull, match.TeamOwner.NameShort) : "";

            }
        }
    }

    
}
