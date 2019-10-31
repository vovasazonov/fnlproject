using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FNL.Views;
using ModelLayer;
using ModelLayer.Models;
using System.Drawing;

namespace FNL.Presenters
{
    public class TeamPresenter
    {
        private ITeamView _view;

        public TeamPresenter(ITeamView view)
        {
            this._view = view;
        }

        /// <summary>
        /// Return data from database and set to views.
        /// </summary>
        /// <returns>Views</returns>
        public List<ITeamView> GetViews()
        {
            List<ITeamView> views = new List<ITeamView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var teams = db.Teams;

                foreach (var team in teams)
                {
                    CTeamView teamView = new CTeamView();

                    teamView.TeamId = team.TeamId;
                    teamView.Color = Color.FromArgb(team.Color);
                    teamView.NameFull = team.NameFull != null ? team.NameFull : "";
                    teamView.NameShort = team.NameShort != null ? team.NameShort : "";
                    teamView.PathLogo = team.LogotypePath != null ? team.LogotypePath : "";

                    views.Add(teamView);
                }
            }

            return views;
        }

        /// <summary>
        /// Delete record in database.
        /// </summary>
        /// <param name="idTeam"></param>
        public void DeleteModelDB()
        {
            int idTeam = _view.TeamId;
            using (DbFnlContext db = new DbFnlContext())
            {
                var query = from t in db.Teams
                            where t.TeamId == idTeam
                            select t;

                db.Teams.Remove(query.FirstOrDefault());

                db.SaveChanges();
            }
        }

    }
}
