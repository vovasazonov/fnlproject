/*  Файл представителя (паттерн Model View Presenter).
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Dictionarys;
using FNL.Enums;
using FNL.Views;
using ModelLayer;
using ModelLayer.Models;

namespace FNL.Presenters
{
    internal class MainPresenter
    {
        private IMainView _view;

        internal MainPresenter(IMainView view)
        {
            _view = view;
        }

        internal void ShowView()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var query = db.Matches.Where(t => t.MatchId == _view.MatchId).FirstOrDefault();
                _view.NameMatch = query.Name;
                _view.NameGuest = query.TeamGuest != null ? /*string.Format("{0} ({1})", query.TeamGuest.NameFull,*/ query.TeamGuest.NameShort/*)*/ : "";
                _view.NameHome = query.TeamOwner != null ? /*string.Format("{0} ({1})", query.TeamOwner.NameFull,*/ query.TeamOwner.NameShort/*)*/ : "";
                _view.ColorGuest = query.TeamGuest != null ? Color.FromArgb(query.TeamGuest.Color) : new Color();
                _view.ColorHome = query.TeamOwner != null ? Color.FromArgb(query.TeamOwner.Color) : new Color();
                _view.SeasonName = query.Season != null ? query.Season.Name : "";
                _view.StadiumName = query.Stadium != null ? query.Stadium.Name : "";
                //_view.TimeMatch = 
                //_view.NumberTime = 
            }

            ShowMatchFaces();
        }

        internal string GetFullNameTeam(bool isGuest)
        {
            string name = "";

            using (var db = new DbFnlContext())
            {
                var thisMatch = db.Matches.Where(t => t.MatchId == _view.MatchId).FirstOrDefault() ?? new Match();


                if (isGuest)
                {
                    name = thisMatch.TeamGuest != null ? thisMatch.TeamGuest.NameFull : "";
                }
                else
                {
                    name = thisMatch.TeamOwner != null ? thisMatch.TeamOwner.NameFull : "";
                }
            }

            return name;
        }

        internal string GetLogoPathTeam(bool isGuest)
        {
            string logoPath = "";

            using (var db = new DbFnlContext())
            {
                var thisMatch = db.Matches.Where(t => t.MatchId == _view.MatchId).FirstOrDefault() ?? new Match();


                if (isGuest)
                {
                    logoPath = thisMatch.TeamGuest != null ? thisMatch.TeamGuest.LogotypePath : "";
                }
                else
                {
                    logoPath = thisMatch.TeamOwner != null ? thisMatch.TeamOwner.LogotypePath : "";
                }
            }

            return logoPath;
        }

        internal void SetPlayerPair(bool isGuest)
        {
            var idPlayer = isGuest ? _view.GuestPlayerId : _view.HomePlayerId;

            using (var db = new DbFnlContext())
            {
                db.PlayersMatches.Where(t => t.MatchId == _view.MatchId && t.PersonId == idPlayer).FirstOrDefault().IsSpare = true;
                db.SaveChanges();
            }

        }

        internal void Replacement(bool isGuest)
        {
            var idPlayer = isGuest ? _view.GuestPlayerId : _view.HomePlayerId;
            var idPair = isGuest ? _view.PairGuestPlayerId : _view.PairHomePlayerId;

            using (var db = new DbFnlContext())
            {
                // Check if the players have own statistic current match. If not, create.
                if (!db.StatisticsPlayersMatches.Where(t => t.MatchId == _view.MatchId && t.PersonId == idPlayer).Any())
                {
                    db.StatisticsPlayersMatches.Add(new StatisticPlayerMatch { MatchId = _view.MatchId, PersonId = idPlayer });
                    db.SaveChanges();
                }
                if (!db.StatisticsPlayersMatches.Where(t => t.MatchId == _view.MatchId && t.PersonId == idPair).Any())
                {
                    db.StatisticsPlayersMatches.Add(new StatisticPlayerMatch { MatchId = _view.MatchId, PersonId = idPair });
                    db.SaveChanges();
                }

                // Add statistic about replacement to players.
                db.EventsStatistics.Add(new EventStatistic
                {
                    HalfMatch = _view.NumberHalfTime,
                    Time = DateTime.Now,
                    StatisticPlayerMatchId = db.StatisticsPlayersMatches.Where(t => t.MatchId == _view.MatchId && t.PersonId == idPlayer).FirstOrDefault().StatisticPlayerMatchId,
                    EventId = DictionaryEvents.GetEventId(EventMatchType.Replacement)
                });

                db.SaveChanges();

                db.EventsStatistics.Add(new EventStatistic
                {
                    HalfMatch = _view.NumberHalfTime,
                    Time = DateTime.Now,
                    StatisticPlayerMatchId = db.StatisticsPlayersMatches.Where(t => t.MatchId == _view.MatchId && t.PersonId == idPair).FirstOrDefault().StatisticPlayerMatchId,
                    EventId = DictionaryEvents.GetEventId(EventMatchType.Replacement)
                });

                db.SaveChanges();

                // Change pair value of each players in match.
                db.PlayersMatches.Where(t => t.MatchId == _view.MatchId && t.PersonId == idPlayer).FirstOrDefault().IsSpare = true;
                db.PlayersMatches.Where(t => t.MatchId == _view.MatchId && t.PersonId == idPair).FirstOrDefault().IsSpare = false;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete one event from season current player.
        /// </summary>
        /// <param name="isGuest"></param>
        /// <param name="typeEvent"></param>
        internal void MinEventSeasonDb(bool isGuest, EventMatchType typeEvent)
        {
            var idPlayer = isGuest ? _view.GuestPlayerId : _view.HomePlayerId;

            int idEvent = DictionaryEvents.GetEventId(typeEvent);

            try
            {
                using (var db = new DbFnlContext())
                {

                    var matches = db.Matches.
                        Where(t => t.MatchId == _view.MatchId).
                        Select(t => t.Season).FirstOrDefault().Matches;

                    List<StatisticPlayerMatch> statistics = new List<StatisticPlayerMatch>();

                    foreach (var match in matches)
                    {
                        statistics.AddRange(match.Statistics.Where(t => t.PersonId == idPlayer));
                    }

                    foreach (var statistc in statistics)
                    {
                        foreach (var eventP in statistc.EventStatistics)
                        {
                            if (eventP.EventId == idEvent)
                            {
                                var es = db.EventsStatistics.Where(t => t.EventStatisticId == eventP.EventStatisticId).FirstOrDefault();
                                db.EventsStatistics.Remove(es);
                                db.SaveChanges();

                                return;
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
#if DEBUG
                throw;
#endif
                Logger.Log.Error(ex);
            }
        }
        internal void AddEventToDb(bool isGuest, EventMatchType eventMatch)
        {
            var idPlayer = isGuest ? _view.GuestPlayerId : _view.HomePlayerId;

            using (var db = new DbFnlContext())
            {
                // Check if the players have own statistic current match. If not, create.
                if (!db.StatisticsPlayersMatches.Where(t => t.MatchId == _view.MatchId && t.PersonId == idPlayer).Any())
                {
                    db.StatisticsPlayersMatches.Add(new StatisticPlayerMatch { MatchId = _view.MatchId, PersonId = idPlayer });
                    db.SaveChanges();
                }

                // Add statistic about replacement to players.
                db.EventsStatistics.Add(new EventStatistic
                {
                    HalfMatch = _view.NumberHalfTime,
                    Time = DateTime.Now,
                    StatisticPlayerMatchId = db.StatisticsPlayersMatches.Where(t => t.MatchId == _view.MatchId && t.PersonId == idPlayer).FirstOrDefault().StatisticPlayerMatchId,
                    EventId = DictionaryEvents.GetEventId(eventMatch)
                }); ;

                db.SaveChanges();
            }
        }


        internal int GetEventInSeason(int idPlayer, EventMatchType eventMatch)
        {
            int amount = 0;
            int idEvent = DictionaryEvents.GetEventId(eventMatch);

            try
            {
                using (var db = new DbFnlContext())
                {

                    var matches = db.Matches.
                        Where(t => t.MatchId == _view.MatchId).
                        Select(t => t.Season).FirstOrDefault().Matches;

                    List<StatisticPlayerMatch> statistics = new List<StatisticPlayerMatch>();

                    foreach (var match in matches)
                    {
                        statistics.AddRange(match.Statistics.Where(t => t.PersonId == idPlayer));
                    }

                    foreach (var statistc in statistics)
                    {
                        foreach (var eventP in statistc.EventStatistics)
                        {
                            if (eventP.EventId == idEvent)
                            {
                                amount++;
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
#if DEBUG
                throw;
#endif
                Logger.Log.Error(ex);
                amount = 0;
            }

            return amount;
        }


        internal void ShowViewEvents()
        {
            using (var db = new DbFnlContext())
            {
                _view.GoalsGuest = GetEventInSeason(_view.GuestPlayerId, EventMatchType.Goal).ToString();
                //_view.TotalShotGuest { get; set; }
                //_view.ShotTargetGuest { get; set; }
                //_view.CornerGuest { get; set; }
                //_view.OffsideGuest { get; set; }
                //_view.PassGuest { get; set; }
                //_view.AccuratePassGuest { get; set; }
                //_view.FoulGuest { get; set; }
                _view.YellowTicketGuest = GetEventInSeason(_view.GuestPlayerId, EventMatchType.YellowCard).ToString();
                _view.RedTicketGuest = GetEventInSeason(_view.GuestPlayerId, EventMatchType.RedCard).ToString();
                _view.ChangeGuest = db.EventsStatistics.Where(t => t.EventId == (int)EventMatchType.Replacement && t.StatisticPlayerMatch.PersonId == _view.GuestPlayerId).Count().ToString();

                _view.GoalsHome = GetEventInSeason(_view.HomePlayerId, EventMatchType.Goal).ToString();
                //_view.TotalShotHome { get; set; }
                //_view.ShotTargetHome { get; set; }
                //_view.CornerHome { get; set; }
                //_view.OffsideHome { get; set; }
                //_view.PassHome { get; set; }
                //_view.AccuratePassHome { get; set; }
                //_view.FoulHome { get; set; }
                _view.YellowTicketHome = GetEventInSeason(_view.HomePlayerId, EventMatchType.YellowCard).ToString();
                _view.RedTicketHome = GetEventInSeason(_view.HomePlayerId, EventMatchType.RedCard).ToString();
                _view.ChangeHome = db.EventsStatistics.Where(t => t.EventId == (int)EventMatchType.Replacement && t.StatisticPlayerMatch.PersonId == _view.HomePlayerId).Count().ToString();
            }
        }

        /// <summary>
        /// Show faces in view.
        /// </summary>
        /// <returns></returns>
        private void ShowMatchFaces()
        {
            IFacesView view = _view;

            try
            {
                using (var db = new DbFnlContext())
                {
                    var people = db.FacesMatches.Where(t => t.MatchId == _view.MatchId).Select(t => t.Person);

                    bool settedHelper1 = false;
                    bool settedComment1 = false;

                    foreach (var person in people)
                    {
                        RoleType roleType = (RoleType)((int)person.RoleId);

                        switch (roleType)
                        {
                            case RoleType.MainJudje:
                                view.NameMainJudje = string.Format("{0} {1}", person.FirstName, person.LastName);
                                view.CityMainJudje = person.Address.City;
                                break;
                            case RoleType.HelperJudje:
                                if (!settedHelper1)
                                {
                                    view.NameHelperJudje1 = string.Format("{0} {1}", person.FirstName, person.LastName);
                                    view.CityHelperJudje1 = person.Address.City;

                                    settedHelper1 = true;
                                }
                                else
                                {
                                    view.NameHelperJudje2 = string.Format("{0} {1}", person.FirstName, person.LastName);
                                    view.CityHelperJudje2 = person.Address.City;
                                }
                                break;
                            case RoleType.Commentator:
                                if (!settedComment1)
                                {
                                    view.NameCommentator1 = string.Format("{0} {1}", person.FirstName, person.LastName);
                                    view.CityCommentator1 = person.Address.City;

                                    settedComment1 = true;
                                }
                                else
                                {
                                    view.NameCommentator2 = string.Format("{0} {1}", person.FirstName, person.LastName);
                                    view.CityCommentator2 = person.Address.City;
                                }
                                break;
                            case RoleType.PairJudje:
                                view.NamePairJudje = string.Format("{0} {1}", person.FirstName, person.LastName);
                                view.CityPairJudje = person.Address.City;
                                break;
                            case RoleType.Inspector:
                                view.NameInsepcotor = string.Format("{0} {1}", person.FirstName, person.LastName);
                                view.CityInsepcotor = person.Address.City;
                                break;
                            case RoleType.Delegat:
                                view.NameDelegat = string.Format("{0} {1}", person.FirstName, person.LastName);
                                view.CityDelegat = person.Address.City;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
            }
        }
    }
}
