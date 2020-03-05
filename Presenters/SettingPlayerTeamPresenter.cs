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
using ModelLayer;
using ModelLayer.Models;
using FNL.Views;
using FNL.Dictionarys;
using FNL.Enums;

namespace FNL.Presenters
{
    internal class SettingPlayerTeamPresenter
    {
        private ISettingPlayerTeamView _view;

        internal SettingPlayerTeamPresenter(ISettingPlayerTeamView view)
        {
            this._view = view;
        }

        internal void ShowPlayerInView()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                TeamPlayer teamPlayer = db.TeamPlayers.Where(t => t.PersonId == _view.PersonId).FirstOrDefault() ?? new TeamPlayer();


                _view.Number = teamPlayer.NumberPlayer ?? 0;
                //_view.IdTeam = teamPlayer.TeamId;
                _view.Team = teamPlayer.Team != null ? teamPlayer.Team.NameFull : "";
                _view.AmpluaId = teamPlayer.AmpluaId ?? 0;
                _view.Amplua = teamPlayer.Amplua != null ? teamPlayer.Amplua.Name : "";
            }
        }

        /// <summary>
        /// Delete person from database.
        /// </summary>
        /// <returns>Result operation.</returns>
        internal bool DeleteModelDB()
        {
            using (var db = new DbFnlContext())
            {
                Person model = db.People.Where(t => t.PersonId == _view.PersonId).FirstOrDefault();

                try
                {
                    db.People.Remove(model);
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
        /// Update info of player in team.
        /// </summary>
        /// <returns>Result operation.</returns>
        internal bool UpdateModelDB()
        {
            using (var db = new DbFnlContext())
            {

                try
                {
                    TeamPlayer model = model = db.TeamPlayers.Where(t => t.TeamId == _view.TeamId && t.PersonId == _view.PersonId).FirstOrDefault();
                    model.NumberPlayer = _view.Number;
                    model.AmpluaId = DictionaryAmpluas.Dic.Keys.Contains((AmpluaType)_view.AmpluaId) ? _view.AmpluaId : DictionaryAmpluas.GetId(AmpluaType.WithoutAmplua);
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
        /// Insert new player to team.
        /// </summary>
        /// <returns>Result operation.</returns>
        internal bool InsertModelDB()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                TeamPlayer model = GetModelFromView();

                try
                {
                    db.TeamPlayers.Add(model);
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


        private TeamPlayer GetModelFromView()
        {
            TeamPlayer model = new TeamPlayer();

            using (DbFnlContext db = new DbFnlContext())
            {
                model = db.TeamPlayers.Where(t => t.TeamId == _view.TeamId && t.PersonId == _view.PersonId).FirstOrDefault();
                model = model != null ? model : new TeamPlayer();
                model.AmpluaId = DictionaryAmpluas.Dic.Keys.Contains((AmpluaType)_view.AmpluaId) ? _view.AmpluaId : DictionaryAmpluas.GetId(AmpluaType.WithoutAmplua);
                model.NumberPlayer = _view.Number;
                model.PersonId = _view.PersonId;
                model.TeamId = _view.TeamId;
            }

            return model;
        }
    }
}
