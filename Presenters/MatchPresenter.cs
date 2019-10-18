using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Views;
using ModelLayer;
using ModelLayer.Models;

namespace FNL.Presenters
{
    public class MatchPresenter
    {
        private IMatchView _view;

        public MatchPresenter(IMatchView view)
        {
            _view = view;
        }

        public void ShowView()
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var query = db.Matches.Where(t => t.MatchId == _view.MatchId).FirstOrDefault();
                _view.NameMatch = query.Name;
                _view.NameGuest = query.TeamGuest != null ? string.Format("{0} ({1})", query.TeamGuest.NameFull, query.TeamGuest.NameShort) :"";
                _view.NameHome = query.TeamOwner != null ? string.Format("{0} ({1})", query.TeamOwner.NameFull, query.TeamOwner.NameShort): "";
                _view.ColorGuest = query.TeamGuest != null ? Color.FromArgb(query.TeamGuest.Color) : new Color();
                _view.ColorHome = query.TeamOwner != null ? Color.FromArgb(query.TeamOwner.Color) : new Color();
                //_view.TimeMatch = 
                //_view.NumberTime = 
            }
        }
    }
}
