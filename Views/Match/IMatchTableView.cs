using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{

    public interface IMatchTableView
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
        string MainJudje { get; set; }
        string HelperJudje1 { get; set; }
        string HelperJudje2 { get; set; }
        string PairJudje { get; set; }
        string Inspector { get; set; }
        string Delegat { get; set; }
    }

    /// <summary>
    /// Helper class for to create exemplar of interface via class.
    /// </summary>
    public class CMatchTableView : IMatchTableView
    {
        int IMatchTableView.MatchId { get; set; }
        string IMatchTableView.NameMatch { get; set; }
        DateTime IMatchTableView.Date { get; set; }
        string IMatchTableView.NameStadium { get; set; }
        string IMatchTableView.NameSeason { get; set; }
        string IMatchTableView.NameTeamGuest { get; set; }
        int IMatchTableView.GoalsGuest { get; set; }
        string IMatchTableView.NameTeamOwner { get; set; }
        int IMatchTableView.GoalsOwner { get; set; }
        string IMatchTableView.CommentatorsMatch1 { get; set; }
        string IMatchTableView.CommentatorsMatch2 { get; set; }
        string IMatchTableView.MainJudje { get; set; }
        string IMatchTableView.HelperJudje1 { get; set; }
        string IMatchTableView.HelperJudje2 { get; set; }
        string IMatchTableView.PairJudje { get; set; }
        string IMatchTableView.Inspector { get; set; }
        string IMatchTableView.Delegat { get; set; }
    }

}
