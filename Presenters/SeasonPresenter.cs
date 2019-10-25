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
    public class SeasonPresenter
    {
        private ISeasonView _view;

        public SeasonPresenter(ISeasonView view)
        {
            _view = view;
        }

        public List<ISeasonView> GetViews()
        {
            List<ISeasonView> views = new List<ISeasonView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var seasons = db.Seasons;

                // Get data drom database.
                foreach (var season in seasons)
                {
                    ClassSeasonView view = new ClassSeasonView();

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
        public void DeleteModelDB()
        {
            int id = _view.SeasonId;
            using (DbFnlContext db = new DbFnlContext())
            {
                var query = from t in db.Seasons
                            where t.SeasonId == id
                            select t;

                db.Seasons.Remove(query.FirstOrDefault());

                db.SaveChanges();
            }
        }

    }
}
