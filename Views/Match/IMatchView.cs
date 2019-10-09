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

    /// <summary>
    /// Helper class for to create exemplar of interface via class.
    /// </summary>
    public class ClassMatchView : IMatchView
    {
        int IMatchView.MatchId { get; set; }
        string IMatchView.NameMatch         {get;set;}
        DateTime IMatchView.Date            {get;set;}
        string IMatchView.NameStadium       {get;set;}
        string IMatchView.NameSeason        {get;set;}
        string IMatchView.NameTeamGuest     {get;set;}
        int IMatchView.GoalsGuest           {get;set;}
        string IMatchView.NameTeamOwner     {get;set;}
        int IMatchView.GoalsOwner           {get;set;}
        string IMatchView.CommentatorsMatch1{get;set;}
        string IMatchView.CommentatorsMatch2{get;set;}
    }

}
