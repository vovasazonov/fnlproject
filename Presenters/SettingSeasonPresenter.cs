/*  Файл представителя (паттерн Model View Presenter).
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */
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
    internal class SettingSeasonPresenter
    {
        private ISettingSeasonView _view;

        internal SettingSeasonPresenter(ISettingSeasonView view)
        {
            _view = view;
        }

        /// <summary>
        /// Convert view to model.
        /// </summary>
        /// <returns></returns>
        private Season GetModelFromView()
        {
            Season model = new Season();

            using (DbFnlContext db = new DbFnlContext())
            {
                model.SeasonId = _view.SeasonId;
                model.Name = _view.SeasonName;
            }

            return model;
        }

        /// <summary>
        /// Update record in database. Take data from view.
        /// </summary>
        /// <returns>Result operation</returns>
        internal bool UpdateModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var model = GetModelFromView();

                try
                {
                    // Say to database that this model is consist and changed.
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
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
        /// Insert record to Team in database. Take data from view.
        /// </summary>
        /// <returns>Result operation</returns>
        internal bool InsertModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var model = GetModelFromView();

                try
                {
                    db.Seasons.Add(model);
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
        /// Take record from database and show in view.
        /// </summary>
        /// <returns></returns>
        internal void ShowModelInView()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var season = (from m in db.Seasons
                              where m.SeasonId == _view.SeasonId
                              select m).FirstOrDefault() ?? new Season();

                _view.SeasonId = season.SeasonId;
                _view.SeasonName = season.Name;
            }
        }
    }
}
