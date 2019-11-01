using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Views;
using ModelLayer;
using ModelLayer.Models;
using FNL.Enums;
using FNL.Dictionarys;

namespace FNL.Presenters
{
    internal class MatchPresenter
    {
        private IMatchView _view;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="view"></param>
        internal MatchPresenter(IMatchView view)
        {
            this._view = view;
        }

        /// <summary>
        /// Return data from database.
        /// </summary>
        /// <returns></returns>
        internal List<IMatchView> GetViews()
        {
            List<IMatchView> views = new List<IMatchView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var matches = db.Matches;

                // Get data drom database.
                foreach (var match in matches)
                {
                    IMatchView view = new CMatchTableView();

                    view.MatchId = match.MatchId;
                    view.NameMatch = match.Name;
                    view.Date = match.Date;
                    view.NameStadium = match.Stadium != null ? match.Stadium.Name : "";
                    view.NameSeason = match.Season != null ? match.Season.Name : "";
                    view.NameTeamGuest = match.TeamGuestId != null ? db.Teams.Where(i => i.TeamId == match.TeamGuestId).FirstOrDefault().NameFull : "";
                    //matchView.GoalsGuest { get; set; }
                    view.NameTeamHome = match.TeamOwnerId != null ? db.Teams.Where(i => i.TeamId == match.TeamOwnerId).FirstOrDefault().NameFull : "";
                    //matchView.GoalsOwner { get; set; }

                    bool isFirstHelperJudje = true;
                    bool isFirstCommentator = true;
                    foreach (var face in match.FaceMatch)
                    {
                        switch ((RoleType)(face.Person.RoleId))
                        {
                            case RoleType.Commentator:
                                // Should be 2 commentators.
                                if (isFirstCommentator)
                                {
                                    view.Commentators1 = SetNamePersonToView(face.Person);
                                    isFirstCommentator = false;
                                }
                                else
                                {
                                    view.Commentators2 = SetNamePersonToView(face.Person);
                                }
                                break;
                            case RoleType.MainJudje:
                                view.Delegat = SetNamePersonToView(face.Person);
                                break;
                            case RoleType.HelperJudje:
                                // Should be 2 helpers judje.
                                if (isFirstHelperJudje)
                                {
                                    view.HelperJudje1 = SetNamePersonToView(face.Person);
                                    isFirstHelperJudje = false;
                                }
                                else
                                {
                                    view.HelperJudje2 = SetNamePersonToView(face.Person);
                                }
                                break;
                            case RoleType.PairJudje:
                                view.Delegat = SetNamePersonToView(face.Person);
                                break;
                            case RoleType.Inspector:
                                view.Delegat = SetNamePersonToView(face.Person);
                                break;
                            case RoleType.Delegat:
                                view.Delegat = SetNamePersonToView(face.Person);
                                break;
                            default:
                                break;
                        }

                        string SetNamePersonToView(Person peroson)
                        {
                            return string.Format("{0} {1} {2}", peroson.LastName, peroson.FirstName, peroson.MiddleName);
                        }
                    }

                    views.Add(view);
                }
            }

            return views;
        }

        /// <summary>
        /// Delete record from data base.
        /// </summary>
        internal void DeleteModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var query = from m in db.Matches
                            where m.MatchId == _view.MatchId
                            select m;

                if (query.FirstOrDefault()!=null)
                {
                    db.Matches.Remove(query.FirstOrDefault());
                    db.SaveChanges();
                }
            }
        }

    }
}
