using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;
using ModelLayer;
using FNL.Views;
using FNL.Enums;
using FNL.Dictionarys;

namespace FNL.Presenters
{
    internal class SettingMatchPresenter
    {
        private ISettingMatchView _view;

        internal SettingMatchPresenter(ISettingMatchView view)
        {
            this._view = view;
        }

        /// <summary>
        /// Convert view to model WITHOUT faces match.
        /// </summary>
        /// <returns></returns>
        private Match GetModelFromView()
        {
            Match matchModel;
            using (var db = new DbFnlContext())
            {
                matchModel = new Match
                {
                    Name = _view.NameMatch,
                    Date = _view.Date,
                    MatchId = _view.MatchId,
                    SeasonId = db.Seasons.Any(t => t.SeasonId == _view.SeasonId) ? (int?)_view.SeasonId : null,
                    StadiumId = db.Stadiums.Any(t => t.StadiumId == _view.StadiumId) ? (int?)_view.StadiumId : null,
                    TeamGuestId = db.Teams.Any(t => t.TeamId == _view.GuestTeamId) ? (int?)_view.GuestTeamId : null,
                    TeamOwnerId = db.Teams.Any(t => t.TeamId == _view.OwnerTeamId) ? (int?)_view.OwnerTeamId : null,
                };
            }

            return matchModel;
        }

        /// <summary>
        /// Add to model faces but first delete old.
        /// </summary>
        /// <param name="matchModel"></param>
        private void SetFacesFromView(ref Match matchModel)
        {
            using (var db = new DbFnlContext())
            {
                if (matchModel.FaceMatch != null)
                {
                    // Delete old faces.
                    db.FacesMatches.RemoveRange(matchModel.FaceMatch);
                    db.SaveChanges();
                }

                InsertFaceDB(_view.Commentator1Id, matchModel.MatchId);
                InsertFaceDB(_view.Commentator2Id, matchModel.MatchId);
                InsertFaceDB(_view.DelegatId, matchModel.MatchId);
                InsertFaceDB(_view.HelperJudje1Id, matchModel.MatchId);
                InsertFaceDB(_view.HelperJudje2Id, matchModel.MatchId);
                InsertFaceDB(_view.InspectorId, matchModel.MatchId);
                InsertFaceDB(_view.MainJudjeId, matchModel.MatchId);
                InsertFaceDB(_view.PairJudjeId, matchModel.MatchId);

                void InsertFaceDB(int idFace, int idMatch)
                {
                    bool hasPerson = db.People.Any(t => t.PersonId == idFace);
                    bool hasMatch = db.Matches.Any(t => t.MatchId == idMatch);

                    if (hasPerson && hasMatch)
                    {
                        db.FacesMatches.Add(new FaceMatch { MatchId = idMatch, PersonId = idFace });
                        db.SaveChanges();
                    }

                }
            }
        }

        /// <summary>
        /// Insert record to database. Data take from view.
        /// </summary>
        internal bool InsertModelDB()
        {

            using (DbFnlContext db = new DbFnlContext())
            {

                try
                {
                    // Add model to db.
                    Match matchModel = GetModelFromView();
                    db.Matches.Add(matchModel);
                    db.SaveChanges();

                    // Add commentators to match.
                    SetFacesFromView(ref matchModel);

                    db.SaveChanges();

                }
                catch (Exception ex)
                {
                    Logger.Log.Error("Error database operation", ex);
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Update record in databse. Take data from view.
        /// </summary>
        internal bool UpdateModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {

                try
                {
                    Match matchModel = GetModelFromView();
                    // Add commentators to match.
                    SetFacesFromView(ref matchModel);

                    // Say to database that this model is consist and changed.
                    db.Entry(matchModel).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();

                }
                catch (Exception ex)
                {
                    Logger.Log.Error("Error database operation", ex);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Show model in view.
        /// </summary>
        /// <returns>matches.</returns>
        internal void SetModelToView()
        {

            using (DbFnlContext db = new DbFnlContext())
            {
                Match match = (from m in db.Matches
                               where m.MatchId == _view.MatchId
                               select m).FirstOrDefault();

                var faces = db.FacesMatches.Where(c => c.MatchId == match.MatchId);

                _view.MatchId = match.MatchId;
                _view.StadiumId = db.Stadiums.Where(t => t.StadiumId == match.StadiumId).Any() ? (int)match.StadiumId : -1;
                _view.GuestTeamId = db.Teams.Where(t => t.TeamId == match.TeamGuestId).Any() ? (int)match.TeamGuestId : -1;
                _view.OwnerTeamId = db.Teams.Where(t => t.TeamId == match.TeamOwnerId).Any() ? (int)match.TeamOwnerId : -1;
                _view.SeasonId = db.Seasons.Where(t => t.SeasonId == match.SeasonId).Any() ? (int)match.SeasonId : -1;
                if (faces != null)
                {
                    _view.Commentator1Id = SetIdOfFaceToView(RoleType.Commentator);
                    _view.Commentator2Id = SetIdOfFaceToView(RoleType.Commentator);
                    _view.DelegatId = SetIdOfFaceToView(RoleType.Delegat);
                    _view.HelperJudje1Id = SetIdOfFaceToView(RoleType.HelperJudje);
                    _view.HelperJudje2Id = SetIdOfFaceToView(RoleType.HelperJudje);
                    _view.InspectorId = SetIdOfFaceToView(RoleType.Inspector);
                    _view.MainJudjeId = SetIdOfFaceToView(RoleType.MainJudje);
                    _view.PairJudjeId = SetIdOfFaceToView(RoleType.PairJudje);

                    int SetIdOfFaceToView(RoleType roleType)
                    {
                        int varToSet;
                        int idRole = DictionaryRoles.GetId(roleType);
                        try
                        {
                            varToSet = faces.Select(t => t.Person).
                            Where(t => t.RoleId == idRole).
                            Select(t => t.PersonId).FirstOrDefault();
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        return varToSet;
                    }



                }

                _view.NameMatch = match.Name;
                _view.NameStadium = match.StadiumId != null ? db.Stadiums.Where(s => s.StadiumId == match.StadiumId).Select(s => s.Name).FirstOrDefault() : "";
                _view.NameTeamGuest = match.TeamGuestId != null ? db.Teams.Where(s => s.TeamId == match.TeamGuestId).Select(s => s.NameFull).FirstOrDefault() : "";
                _view.NameTeamHome = match.TeamOwnerId != null ? db.Teams.Where(s => s.TeamId == match.TeamOwnerId).Select(s => s.NameFull).FirstOrDefault() : "";
                _view.NameSeason = match.SeasonId != null ? db.Seasons.Where(s => s.SeasonId == match.SeasonId).Select(s => s.Name).FirstOrDefault() : "";
                _view.Date = match.Date;
                if (faces != null)
                {
                    _view.Commentators1 = SetNamesOfFaceToView(_view.Commentator1Id);
                    _view.Commentators2 = SetNamesOfFaceToView(_view.Commentator2Id);
                    _view.Delegat = SetNamesOfFaceToView(_view.DelegatId);
                    _view.HelperJudje1 = SetNamesOfFaceToView(_view.HelperJudje1Id);
                    _view.HelperJudje2 = SetNamesOfFaceToView(_view.HelperJudje2Id);
                    _view.Inspector = SetNamesOfFaceToView(_view.InspectorId);
                    _view.MainJudje = SetNamesOfFaceToView(_view.MainJudjeId);
                    _view.PairJudje = SetNamesOfFaceToView(_view.PairJudjeId);

                    string SetNamesOfFaceToView(int idPerson)
                    {
                        string varToSet = "";
                        try
                        {
                            varToSet = faces.Where(t => t.PersonId == idPerson).
                        Select(s => s.Person.FirstName + " " + s.Person.FirstName + " " + s.Person.MiddleName).
                        FirstOrDefault();
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        return varToSet;
                    }

                }
            }
        }
    }


}
