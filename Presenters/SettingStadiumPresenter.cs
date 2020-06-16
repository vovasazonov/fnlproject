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
    internal class SettingStadiumPresenter
    {
        private ISettingStadiumView _view;

        internal SettingStadiumPresenter(ISettingStadiumView view)
        {
            _view = view;
        }

        /// <summary>
        /// Convert view to model.
        /// </summary>
        /// <returns></returns>
        private Stadium GetModelFromView()
        {
            Stadium model = new Stadium();

            using (DbFnlContext db = new DbFnlContext())
            {
                model.StadiumId = _view.StadiumId;
                model.Name = _view.StadiumName;
                model.Address = new Address();
                model.Address.City = _view.CityName;
                model.Address.Country = _view.CountryName;
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
                    db.Stadiums.Add(model);
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
                var stadium = (from m in db.Stadiums
                              where m.StadiumId == _view.StadiumId
                              select m).FirstOrDefault() ?? new Stadium();

                _view.StadiumId = stadium.StadiumId;
                _view.StadiumName = stadium.Name;
                _view.CountryName = stadium.Address != null ? stadium.Address.Country : "";
                _view.CityName = stadium.Address != null ? stadium.Address.City : "";
            }
        }
    }
}
