using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface IMatchView
    {
        int MatchId { get; set; }
        int GuestPlayerId { get; set; }
        int PairGuestPlayerId { get; set; }
        int HomePlayerId { get; set; }
        int PairHomePlayerId { get; set; }

        string NameMatch { get; set; }
        string NameGuest { get; set; }
        string NameHome { get; set; }
        Color ColorGuest { get; set; }
        Color ColorHome { get; set; }
        DateTime TimeMatch { get; set; }
        int NumberTime { get;set; }

    }
}
