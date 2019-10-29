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
    public class SettingPersonPresenter
    {
        ISettingPersonView _view;

        public SettingPersonPresenter(ISettingPersonView view)
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
                try
                {
                    personModel.Address = new Address();
                    personModel.Address.City = _view.City;
                    personModel.Address.Country = _view.Country;
                    personModel.FirstName = _view.FirstName;
                    personModel.LastName = _view.LastName;
                    personModel.MiddleName = _view.MiddleName;
                    personModel.RoleId = _view.RoleId;

                }
                catch (Exception)
                {

                    throw;
                }
            }

            return personModel;
        }
        /// <summary>
        /// Add record to database.
        /// </summary>
        public void InsertModelDB()
        {
            CheckRole();

            using (DbFnlContext db = new DbFnlContext())
            {
                Person pernosModel = GetModelFromView();


                db.People.Add(pernosModel);
                db.SaveChanges();

            }

        }

        private void CheckRole()
        {
            using (var db = new DbFnlContext())
            {
                var roleId = _view.RoleId;

                if (!db.Roles.Where(t => t.RoleId == roleId).Any())
                {
                    // Add role to database first.
                    db.Roles.Add(new Role { RoleId = roleId, Name = DictionaryRoles.Dic[(RoleType)roleId] ?? "" });
                    var f = db.Roles.ToList();
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Update model in database. Take data from view.
        /// </summary>
        /// <param name="idPerson"></param>
        public void UpdateModelDB(int idPerson)
        {

        }

        /// <summary>
        /// Show model in view. Data takes from database.
        /// </summary>
        /// <returns></returns>
        public void ShowModelInView(int idPerson)
        {

            using (DbFnlContext db = new DbFnlContext())
            {

            }
        }
    }
}
