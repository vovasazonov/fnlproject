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
        private ISettingMatchView _settingMatchView;

        public SettingMatchPresenter(ISettingMatchView settingMatchView)
        {
            this._settingMatchView = settingMatchView;
        }

        private Match GetMatchFromView()
        {
            Match matchModel = new Match
            {
                Name = _settingMatchView.NameMatch,
                Date = _settingMatchView.DateTime,
                MatchId = _settingMatchView.MatchId != null ? (int)_settingMatchView.MatchId : 0,
                SeasonId = _settingMatchView.SeasonId,
                StadiumId = _settingMatchView.StadiumId,
                TeamGuestId = _settingMatchView.GuestTeamId,
                TeamOwnerId = _settingMatchView.OwnerTeamId
            };

            return matchModel;
        }

        private void SetCommentatorsFromView(ref Match matchModel)
        {
            matchModel.CommentatorsMatch = new List<CommentatorMatch>();

            // Add commentators to match.
            if (_settingMatchView.CommentatorPerson1Id != null)
            {
                matchModel.CommentatorsMatch.Add(new CommentatorMatch { MatchId = matchModel.MatchId, PersonId = (int)_settingMatchView.CommentatorPerson1Id });
            }
            if (_settingMatchView.CommentatorPerson2Id != null)
            {
                matchModel.CommentatorsMatch.Add(new CommentatorMatch { MatchId = matchModel.MatchId, PersonId = (int)_settingMatchView.CommentatorPerson2Id });
            }
        }

        public void InsertMatch()
        {

            using (DbFnlContext db = new DbFnlContext())
            {
                // Add model to db.
                Match matchModel = GetMatchFromView();
                db.Matches.Add(matchModel);
                db.SaveChanges();

                // Add commentators to match.
                SetCommentatorsFromView(ref matchModel);

                db.SaveChanges();
            }

        }

        public void UpdateMatch()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Match matchModel = GetMatchFromView();
                // Add commentators to match.
                SetCommentatorsFromView(ref matchModel);

                // Say to database that this model is consist and changed.
                db.Entry(matchModel).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Return data from database.
        /// </summary>
        /// <returns>matches.</returns>
        public void ShowMatchInView(int idMatch)
        {

            using (DbFnlContext db = new DbFnlContext())
            {
                Match match = (from m in db.Matches
                               where m.MatchId == idMatch
                               select m).FirstOrDefault();

                _settingMatchView.MatchId = match.MatchId;
                _settingMatchView.StadiumId = match.StadiumId;
                _settingMatchView.GuestTeamId = match.TeamGuestId;
                _settingMatchView.OwnerTeamId = match.TeamOwnerId;
                _settingMatchView.SeasonId = match.SeasonId;
                List<CommentatorMatch> commentators = db.CommentatorsMatches.Where(c => c.MatchId == match.MatchId).ToList();
                _settingMatchView.CommentatorPerson1Id = commentators != null ? commentators.Count > 0 ? (int?)commentators[0].CommentatorMatchId : null : null;
                _settingMatchView.CommentatorPerson2Id = commentators != null ? commentators.Count > 1 ? (int?)commentators[1].CommentatorMatchId : null : null;

                _settingMatchView.NameMatch = match.Name;
                _settingMatchView.NameStadium = match.StadiumId != null ? db.Stadiums.Where(s => s.StadiumId == match.StadiumId).Select(s => s.Name).FirstOrDefault() : "";
                _settingMatchView.NameGuestTeam = match.TeamGuestId != null ? db.Teams.Where(s => s.TeamId == match.TeamGuestId).Select(s => s.NameFull).FirstOrDefault() : "";
                _settingMatchView.NameOwnerTeam = match.TeamOwnerId != null ? db.Teams.Where(s => s.TeamId == match.TeamOwnerId).Select(s => s.NameFull).FirstOrDefault() : "";
                _settingMatchView.NameSeason = match.SeasonId != null ? db.Seasons.Where(s => s.SeasonId == match.SeasonId).Select(s => s.Name).FirstOrDefault() : "";
                _settingMatchView.DateTime = match.Date;
                _settingMatchView.NameCommentator1 = _settingMatchView.CommentatorPerson1Id != null ? db.People.Where(s => s.PersonId == _settingMatchView.CommentatorPerson1Id).Select(s => s.LastName + " " + s.FirstName + " " + s.MiddleName).FirstOrDefault() : "";
                _settingMatchView.NameCommentator2 = _settingMatchView.CommentatorPerson2Id != null ? db.People.Where(s => s.PersonId == _settingMatchView.CommentatorPerson2Id).Select(s => s.LastName + " " + s.FirstName + " " + s.MiddleName).FirstOrDefault() : "";
            }
        }
    }


}
