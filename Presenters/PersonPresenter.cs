using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Views;
using ModelLayer;

namespace FNL.Presenters
{
    internal class PersonPresenter
    {
        private IPersonView _view;

        internal PersonPresenter(IPersonView view)
        {
            this._view = view;
        }

        /// <summary>
        /// Return data from database converted to view.
        /// </summary>
        /// <returns>matches.</returns>
        internal List<IPersonView> GetView()
        {
            List<IPersonView> personView = new List<IPersonView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var people = db.People;

                // Get data drom database.
                foreach (var person in people)
                {
                    IPersonView view = new CPersonView();

                    view.PersonId = person.PersonId;

                    view.FirstName = person.FirstName;
                    view.LastName = person.LastName;
                    view.MiddleName = person.MiddleName;

                    var Role = db.Roles.Where(i => i.RoleId == person.RoleId).FirstOrDefault();
                    view.Role = Role != null ? Role.Name : "";
                    view.RoleId = Role != null ? Role.RoleId : 0;
                    view.City = person.Address != null ? person.Address.City : "";
                    view.Country = person.Address != null ? person.Address.Country : "";
                    view.PhotoPath = person.PhotoPath;

                    personView.Add(view);
                }
            }

            return personView;
        }

        /// <summary>
        /// Delete recored from database. 
        /// </summary>
        /// <param name="idPerson"></param>
        internal void DeleteModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var query = from p in db.People
                            where p.PersonId == _view.PersonId
                            select p;

                if (query.FirstOrDefault() != null)
                {
                    db.People.Remove(query.FirstOrDefault());

                    db.SaveChanges();

                }
            }
        }

    }
}
