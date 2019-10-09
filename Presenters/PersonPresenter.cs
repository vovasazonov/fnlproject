using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Views;
using ModelLayer;

namespace FNL.Presenters
{
    public class PersonPresenter
    {
        IPersonView personView;

        public PersonPresenter(IPersonView personView)
        {
            this.personView = personView;
        }

        /// <summary>
        /// Return data from database.
        /// </summary>
        /// <returns>matches.</returns>
        public List<IPersonView> GetPeople()
        {
            List<IPersonView> personView = new List<IPersonView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var people = db.People;

                // Get data drom database.
                foreach (var person in people)
                {
                    HelperPersonView helperPersonView = new HelperPersonView();

                    helperPersonView.Id = person.PersonId;

                    helperPersonView.FirstName = person.FirstName;
                    helperPersonView.LastName = person.LastName;
                    helperPersonView.MiddleName = person.MiddleName;

                    helperPersonView.Role = db.Roles.Where(i => i.RoleId == person.RoleId).FirstOrDefault().Name;
                    helperPersonView.City = person.Address.City;
                    helperPersonView.Country = person.Address.Country;
                    helperPersonView.PhotoPath = person.PhotoPath;

                    personView.Add(helperPersonView);
                }
            }

            return personView;
        }

        public void DeletePersonFromDatabase(int idPerson)
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var query = from p in db.People
                            where p.PersonId == idPerson
                            select p;

                db.People.Remove(query.FirstOrDefault());

                db.SaveChanges();
            }
        }

        class HelperPersonView : IPersonView
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName {get;set;}
            public string MiddleName{get;set;}
            public string PhotoPath {get;set;}
            public string Country {get;set;}
            public string City {get;set;}
            public string Role {get;set;}
        }
    }
}
