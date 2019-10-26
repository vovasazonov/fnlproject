﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Forms;
using FNL.Views;
using ModelLayer;
using ModelLayer.Models;

namespace FNL.Presenters
{
    public class InsertMatchPlayersPresenter
    {
        private InsertMatchPlayers _view;

        public InsertMatchPlayersPresenter(InsertMatchPlayers view)
        {
            _view = view;
        }

        /// <summary>
        /// Return data from database converted to view.
        /// </summary>
        /// <returns>matches.</returns>
        public List<IPersonView> GetView()
        {
            List<IPersonView> personView = new List<IPersonView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var people = db.People;

                // Get data drom database.
                foreach (var person in people)
                {
                    IPersonView view = new ClassPersonView();

                    view.IdPerson = person.PersonId;

                    view.FirstName = person.FirstName;
                    view.LastName = person.LastName;
                    view.MiddleName = person.MiddleName;

                    var Role = db.Roles.Where(i => i.RoleId == person.RoleId).FirstOrDefault();
                    view.Role = Role != null ? Role.Name : "";
                    view.City = person.Address != null ? person.Address.City : "";
                    view.Country = person.Address != null ? person.Address.Country : "";
                    view.PhotoPath = person.PhotoPath;
                    

                    personView.Add(view);
                }
            }

            return personView;
        }
    }
}
