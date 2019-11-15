using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Views;
using ModelLayer;
using ModelLayer.Models;

namespace FNL.Presenters
{
    internal class StadiumPresenter
    {
        private IStadiumView _view;

        internal StadiumPresenter(IStadiumView view)
        {
            _view = view;
        }

        internal List<IStadiumView> GetViews()
        {
            List<IStadiumView> views = new List<IStadiumView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var stadiums = db.Stadiums;

                // Get data drom database.
                foreach (var stadium in stadiums)
                {
                    CStadiumView view = new CStadiumView();

                    view.StadiumId = stadium.StadiumId;
                    view.StadiumName = stadium.Name;
                    view.CityName = stadium.Address != null ? stadium.Address.City : "";
                    view.CountryName = stadium.Address != null ? stadium.Address.Country : "";

                    views.Add(view);
                }
            }

            return views;
        }

        /// <summary>
        /// Delete record in database.
        /// </summary>
        internal bool DeleteModelDB()
        {
            int id = _view.StadiumId;
            using (DbFnlContext db = new DbFnlContext())
            {
                try
                {
                    var query = from t in db.Stadiums
                                where t.StadiumId == id
                                select t;
                    if (query.FirstOrDefault() != null)
                    {
                        db.Stadiums.Remove(query.FirstOrDefault());

                        db.SaveChanges();
                    }

                }
                catch (Exception ex)
                {
                    Logger.Log.Error("Error database operation", ex);
                    return false;
                }
            }

            return true;
        }
    }
}
