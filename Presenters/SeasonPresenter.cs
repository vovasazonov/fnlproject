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
    internal class SeasonPresenter
    {
        private ISeasonView _view;

        internal SeasonPresenter(ISeasonView view)
        {
            _view = view;
        }

        internal List<ISeasonView> GetViews()
        {
            List<ISeasonView> views = new List<ISeasonView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var seasons = db.Seasons;

                // Get data drom database.
                foreach (var season in seasons)
                {
                    CSeasonView view = new CSeasonView();

                    view.SeasonId = season.SeasonId;
                    view.SeasonName = season.Name;

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
            int id = _view.SeasonId;
            using (DbFnlContext db = new DbFnlContext())
            {
                try
                {
                    var query = from t in db.Seasons
                                where t.SeasonId == id
                                select t;
                    if (query.FirstOrDefault() != null)
                    {
                        db.Seasons.Remove(query.FirstOrDefault());

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
