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
    public class SettingPersonPresenter
    {
        ISettingPersonView _settingPersonView;

        public SettingPersonPresenter(ISettingPersonView settingPersonView)
        {
            this._settingPersonView = settingPersonView;
        }

        private Person GetModelPersonFromView()
        {
            Person personModel = new Person();

            using (DbFnlContext db = new DbFnlContext())
            {
                try
                {
                    personModel.Address.City = _settingPersonView.City;
                    personModel.Address.Country = _settingPersonView.Country;
                    personModel.FirstName = _settingPersonView.FirstName;
                    personModel.LastName = _settingPersonView.LastName;
                    personModel.MiddleName = _settingPersonView.MiddleName;
                    
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return personModel;
        }
        public void InsertPerson()
        {

            using (DbFnlContext db = new DbFnlContext())
            {
                Person pernosModel = GetModelPersonFromView();

                try
                {
                    db.People.Add(pernosModel);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public void UpdatePerson(int idMatch)
        {

        }

        /// <summary>
        /// Return data from database.
        /// </summary>
        /// <returns>matches.</returns>
        public void ShowPersonInView(int idMatch)
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

                //_settingPersonView.DateTime = match.Date;

                ////matchView.GoalsGuest = match.Statistics.
                ////matchView.GoalsOwner = match.Statistics.

                //_settingPersonView.NameMatch = match.Name;
                //_settingPersonView.NameSeason = match.Season != null ? match.Season.Name : "";
                //_settingPersonView.NameStadium = match.Stadium != null ? match.Stadium.Name : "";
                //_settingPersonView.NameGuestTeam = match.TeamGuest != null ? string.Format("{0} ({1})", match.TeamGuest.NameFull, match.TeamGuest.NameShort) : "";
                //_settingPersonView.NameOwnerTeam = match.TeamOwner != null ? string.Format("{0} ({1})", match.TeamOwner.NameFull, match.TeamOwner.NameShort) : "";

            }
        }
    }
}
