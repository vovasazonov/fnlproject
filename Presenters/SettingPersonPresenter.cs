using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;
using ModelLayer;
using FNL.Views;
using FNL.Dictionarys;
using FNL.Enums;

namespace FNL.Presenters
{
    internal class SettingPersonPresenter
    {
        ISettingPersonView _view;

        internal SettingPersonPresenter(ISettingPersonView view)
        {
            this._view = view;
        }

        /// <summary>
        /// Return model converted from view.
        /// </summary>
        /// <returns></returns>
        private Person GetModelFromView()
        {
            Person personModel = new Person();

            using (DbFnlContext db = new DbFnlContext())
            {
                personModel.PersonId = _view.PersonId;
                personModel.Address = new Address();
                personModel.Address.City = _view.City;
                personModel.Address.Country = _view.Country;
                personModel.FirstName = _view.FirstName;
                personModel.LastName = _view.LastName;
                personModel.MiddleName = _view.MiddleName;
                personModel.RoleId = _view.RoleId;
            }

            return personModel;
        }
        /// <summary>
        /// Add record to database.
        /// </summary>
        internal void InsertModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                Person pernosModel = GetModelFromView();


                db.People.Add(pernosModel);
                db.SaveChanges();

            }

        }

        /// <summary>
        /// Update model in database. Take data from view.
        /// </summary>
        /// <param name="idPerson"></param>
        internal void UpdateModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var model = GetModelFromView();

                // Say to database that this model is consist and changed.
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Show model in view. Data takes from database.
        /// </summary>
        /// <returns></returns>
        internal void ShowModelInView()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var model = db.People.Where(t => t.PersonId == _view.PersonId).FirstOrDefault() ?? new Person();

                _view.LastName = model.LastName;
                _view.FirstName = model.FirstName;
                _view.MiddleName = model.MiddleName;
                _view.PhotoPath = model.PhotoPath;
                string nameRole = "";
                DictionaryRoles.Dic.TryGetValue((RoleType)(model.RoleId != null ? (int)model.RoleId : 0), out nameRole);
                _view.Role = nameRole;
                _view.City = model.Address != null ? model.Address.City : "";
                _view.Country = model.Address != null ? model.Address.Country : "";
            }
        }
    }
}
