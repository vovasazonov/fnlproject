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
