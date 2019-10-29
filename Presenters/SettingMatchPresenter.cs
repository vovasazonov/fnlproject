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
        private ISettingMatchView _view;

        public SettingMatchPresenter(ISettingMatchView view)
        {
            this._view = view;
        }

        /// <summary>
        /// Convert view to model WITHOUT commentators.
        /// </summary>
        /// <returns></returns>
        private Match GetModelFromView()
        {
            Match matchModel = new Match
            {
                Name = _view.NameMatch,
                Date = _view.DateTime,
                MatchId = _view.MatchId != null ? (int)_view.MatchId : 0,
                SeasonId = _view.SeasonId,
                StadiumId = _view.StadiumId,
                TeamGuestId = _view.GuestTeamId,
                TeamOwnerId = _view.OwnerTeamId,
            };

            return matchModel;
        }

        /// <summary>
        /// Add to model commentators.
        /// </summary>
        /// <param name="matchModel"></param>
        private void SetCommentatorsFromView(ref Match matchModel)
        {
            matchModel.FaceMatch = new List<FaceMatch>();

            // Add commentators to match.
            if (_view.CommentatorPerson1Id != null)
            {
                matchModel.FaceMatch.Add(new FaceMatch { MatchId = matchModel.MatchId, PersonId = (int)_view.CommentatorPerson1Id });
            }
            if (_view.CommentatorPerson2Id != null)
            {
                matchModel.FaceMatch.Add(new FaceMatch { MatchId = matchModel.MatchId, PersonId = (int)_view.CommentatorPerson2Id });
            }
        }

        /// <summary>
        /// Insert record to database. Data take from view.
        /// </summary>
        public void InserModelDB()
        {

            using (DbFnlContext db = new DbFnlContext())
            {
                // Add model to db.
                Match matchModel = GetModelFromView();
                db.Matches.Add(matchModel);
                db.SaveChanges();

                // Add commentators to match.
                SetCommentatorsFromView(ref matchModel);

                db.SaveChanges();
            }

        }
        /// <summary>
        /// Update record in databse. Take data from view.
        /// </summary>
        public void UpdateModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Match matchModel = GetModelFromView();
                // Add commentators to match.
                SetCommentatorsFromView(ref matchModel);

                // Say to database that this model is consist and changed.
                db.Entry(matchModel).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Show model in view.
        /// </summary>
        /// <returns>matches.</returns>
        public void ShowModelInView(int idMatch)
        {

            using (DbFnlContext db = new DbFnlContext())
            {
                Match match = (from m in db.Matches
                               where m.MatchId == idMatch
                               select m).FirstOrDefault();

                _view.MatchId = match.MatchId;
                _view.StadiumId = match.StadiumId;
                _view.GuestTeamId = match.TeamGuestId;
                _view.OwnerTeamId = match.TeamOwnerId;
                _view.SeasonId = match.SeasonId;
                List<FaceMatch> commentators = db.FacesMatches.Where(c => c.MatchId == match.MatchId).ToList();
                _view.CommentatorPerson1Id = commentators != null ? commentators.Count > 0 ? (int?)commentators[0].FaceMatchId : null : null;
                _view.CommentatorPerson2Id = commentators != null ? commentators.Count > 1 ? (int?)commentators[1].FaceMatchId : null : null;

                _view.NameMatch = match.Name;
                _view.NameStadium = match.StadiumId != null ? db.Stadiums.Where(s => s.StadiumId == match.StadiumId).Select(s => s.Name).FirstOrDefault() : "";
                _view.NameGuestTeam = match.TeamGuestId != null ? db.Teams.Where(s => s.TeamId == match.TeamGuestId).Select(s => s.NameFull).FirstOrDefault() : "";
                _view.NameOwnerTeam = match.TeamOwnerId != null ? db.Teams.Where(s => s.TeamId == match.TeamOwnerId).Select(s => s.NameFull).FirstOrDefault() : "";
                _view.NameSeason = match.SeasonId != null ? db.Seasons.Where(s => s.SeasonId == match.SeasonId).Select(s => s.Name).FirstOrDefault() : "";
                _view.DateTime = match.Date;
                _view.NameCommentator1 = _view.CommentatorPerson1Id != null ? db.People.Where(s => s.PersonId == _view.CommentatorPerson1Id).Select(s => s.LastName + " " + s.FirstName + " " + s.MiddleName).FirstOrDefault() : "";
                _view.NameCommentator2 = _view.CommentatorPerson2Id != null ? db.People.Where(s => s.PersonId == _view.CommentatorPerson2Id).Select(s => s.LastName + " " + s.FirstName + " " + s.MiddleName).FirstOrDefault() : "";
            }
        }
    }


}
