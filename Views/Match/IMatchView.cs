using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface IMatchView
    {
        int MatchId { get; set; }
        string NameMatch { get; set; }
        DateTime Date { get; set; }
        String NameStadium { get; set; }
        String NameSeason { get; set; }
        String NameTeamGuest { get; set; }
        int GoalsGuest { get; set; }
        String NameTeamOwner { get; set; }
        int GoalsOwner { get; set; }
        string CommentatorsMatch1 { get; set; }
        string CommentatorsMatch2 { get; set; }
    }
}
