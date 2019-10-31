using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface IMainView// : IMatchDataValues, IMatchDataIds
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
        int NumberHalfTime { get;set; }
        string SeasonName { get; set; }

        // Counts of each event
        string GoalsGuest { get; set; }
        string TotalShotGuest { get; set; }
        string ShotTargetGuest { get; set; }
        string CornerGuest { get; set; }
        string OffsideGuest { get; set; }
        string PassGuest { get; set; }
        string AccuratePassGuest { get; set; }
        string FoulGuest { get; set; }
        string YellowTicketGuest { get; set; }
        string RedTicketGuest { get; set; }
        string ChangeGuest { get; set; }

        string GoalsHome { get; set; }
        string TotalShotHome { get; set; }
        string ShotTargetHome { get; set; }
        string CornerHome { get; set; }
        string OffsideHome { get; set; }
        string PassHome { get; set; }
        string AccuratePassHome { get; set; }
        string FoulHome { get; set; }
        string YellowTicketHome { get; set; }
        string RedTicketHome { get; set; }
        string ChangeHome { get; set; }

    }
}
