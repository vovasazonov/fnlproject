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
    public class SettingMatchPresenter
    {
        ISettingMatchView settingMatchView;

        public SettingMatchPresenter(ISettingMatchView settingMatchView)
        {
            this.settingMatchView = settingMatchView;
        }

        public void InsertMatchToDatabase()
        {
            Match matchModel = new Match();

            using (DbFnlContext db = new DbFnlContext())
            {
                matchModel.Date = settingMatchView.DateTime;
                matchModel.Name = settingMatchView.NameMatch;
                matchModel.Season = db.Seasons.Where(s => s.Name == settingMatchView.NameSeason).FirstOrDefault();
                matchModel.Stadium = db.Stadiums.Where(s => s.Name == settingMatchView.NameStadium).FirstOrDefault();
                matchModel.TeamGuest = db.Teams.Where(t => t.NameFull == settingMatchView.NameGuestTeam).FirstOrDefault();
                matchModel.TeamOwner = db.Teams.Where(t => t.NameFull == settingMatchView.NameOwnerTeam).FirstOrDefault();
                matchModel.CommentatorsMatch = new List<CommentatorMatch>();
                //matchModel.CommentatorsMatch = new List<CommentatorMatch>();
                //matchModel.CommentatorsMatch.Add(Ise)

                db.Matches.Add(matchModel);
            }

        }
    }
}
