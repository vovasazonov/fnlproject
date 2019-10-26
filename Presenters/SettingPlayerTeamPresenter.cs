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
    public class SettingPlayerTeamPresenter
    {
        private ISettingPlayerTeamView _view;

        public SettingPlayerTeamPresenter(ISettingPlayerTeamView view)
        {
            this._view = view;
        }

        public void ShowPlayerInView()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                TeamPlayer teamPlayer = db.TeamPlayers.Where(t => t.PersonId == _view.IdPerson).FirstOrDefault() ?? new TeamPlayer();


                _view.Number = teamPlayer.NumberPlayer ?? 0;
                //_view.IdTeam = teamPlayer.TeamId;
                _view.TeamName = teamPlayer.Team != null ? teamPlayer.Team.NameFull : "";
                _view.IdAmplua = teamPlayer.AmpluaId;
                _view.AmpluaName = teamPlayer.Amplua != null ? teamPlayer.Amplua.Name : "";
            }
        }

        /// <summary>
        /// Delete person from database.
        /// </summary>
        public void DeleteModelDB()
        {
            using (var db = new DbFnlContext())
            {
                Person model = db.People.Where(t => t.PersonId == _view.IdPerson).FirstOrDefault();
                db.People.Remove(model);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Update info of player in team.
        /// </summary>
        public void UpdateModelDB()
        {
            TeamPlayer model = GetModelFromView();

            using (var db = new DbFnlContext())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                CheckAmplua();

                db.SaveChanges();
            }
        }
        /// <summary>
        /// Insert new player to team.
        /// </summary>
        public void InsertModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                TeamPlayer model = GetModelFromView();
                CheckAmplua();
                db.TeamPlayers.Add(model);
                db.SaveChanges();
            }
        }

        private void CheckAmplua()
        {
            using (var db = new DbFnlContext())
            {
                var ampluaId = _view.IdAmplua;

                if (!db.Ampluas.Where(t => t.AmpluaId == ampluaId).Any())
                {
                    // Add role to database first.
                    db.Ampluas.Add(new Amplua { AmpluaId = (int)ampluaId, Name = DictionaryAmpluas.AmpluaDic[(DictionaryAmpluas.Ampluas)ampluaId] ?? "" });
                    db.SaveChanges();
                }
            }
        }

        private TeamPlayer GetModelFromView()
        {
            TeamPlayer model = new TeamPlayer();

            using (DbFnlContext db = new DbFnlContext())
            {
                model = db.TeamPlayers.Where(t => t.TeamId == _view.IdTeam && t.PersonId == _view.IdPerson).FirstOrDefault();
                model = model != null ? model : new TeamPlayer();
                model.AmpluaId = _view.IdAmplua;
                model.NumberPlayer = _view.Number;
                model.PersonId = _view.IdPerson;
                model.TeamId = _view.IdTeam;
            }

            return model;
        }
    }
}
