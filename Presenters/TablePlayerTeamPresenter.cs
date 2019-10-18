using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using ModelLayer.Models;
using FNL.Views;

namespace FNL.Presenters
{
    public class TablePlayerTeamPresenter
    {
        private ITablePlayerTeamView _view;

        public TablePlayerTeamPresenter(ITablePlayerTeamView view)
        {
            _view = view;
        }

        /// <summary>
        /// Return views converted from records of database.
        /// </summary>
        /// <returns></returns>
        public List<ITablePlayerTeamView> GetViews(int idTeam)
        {
            List<ITablePlayerTeamView> playersView = new List<ITablePlayerTeamView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var playersTeam = db.TeamPlayers.Where(t => t.TeamId == idTeam);

                // Get data drom database.
                foreach (var player in playersTeam)
                {
                    ITablePlayerTeamView playerView = new ClassSettingPlayerTeamView();

                    playerView.IdPerson = player.PersonId;
                    playerView.Number = (int)player.NumberPlayer;
                    playerView.FirstName = player.Person.FirstName;
                    playerView.LastName = player.Person.LastName;
                    playerView.MiddleName = player.Person.MiddleName;
                    playerView.Role = player.Person.Role != null ? player.Person.Role.Name : "";
                    playerView.Amplua = player.Amplua != null ? player.Amplua.Name : "";

                    playersView.Add(playerView);
                }
            }

            return playersView;
        }

        /// <summary>
        /// Return views converted from records of database.
        /// </summary>
        /// <returns></returns>
        public List<ITablePlayerTeamView> GetViews()
        {
            List<ITablePlayerTeamView> playersView = new List<ITablePlayerTeamView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var players = db.People;

                // Get data drom database.
                foreach (var player in players)
                {
                    ITablePlayerTeamView playerView = new ClassSettingPlayerTeamView();

                    playerView.IdPerson = player.PersonId;
                    var playerTeam = player.TeamPlayers != null ? player.TeamPlayers.Where(t => t.PersonId == player.PersonId).FirstOrDefault() : null;
                    playerView.Number = player.TeamPlayers != null ? playerTeam != null ? (int)playerTeam.NumberPlayer : 0 : 0;
                    playerView.FirstName = player.FirstName;
                    playerView.LastName = player.LastName;
                    playerView.MiddleName = player.MiddleName;
                    playerView.Role = player.Role != null ? player.Role.Name : "";
                    var teamplayer = player.TeamPlayers != null ? player.TeamPlayers.Where(t => t.PersonId == player.PersonId).FirstOrDefault() : null;
                    var amplua = teamplayer != null ? teamplayer.Amplua : null;
                    playerView.Amplua = amplua != null ? amplua.Name : "";

                    playersView.Add(playerView);
                }
            }

            return playersView;
        }
        /// <summary>
        /// Return views converted from records of database.
        /// </summary>
        /// <returns></returns>
        public ITablePlayerTeamView GetView(int idTeam, int idPerson)
        {
            List<ITablePlayerTeamView> playersView = GetViews(idTeam);

            return playersView.Where(i => i.IdPerson == idPerson).FirstOrDefault();
        }

        public ITablePlayerTeamView GetView()
        {
            List<ITablePlayerTeamView> playersView = GetViews();

            return playersView.FirstOrDefault();
        }

        /// <summary>
        /// Delete record from in database.
        /// </summary>
        /// <param name="idPerson"></param>
        /// <param name="idTeam"></param>
        public void DeleteModelDB(int idPerson, int idTeam)
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var query = from m in db.TeamPlayers
                            where m.PersonId == idPerson
                            where m.TeamId == idTeam
                            select m;

                db.TeamPlayers.Remove(query.FirstOrDefault());

                db.SaveChanges();
            }
        }

    }
}
