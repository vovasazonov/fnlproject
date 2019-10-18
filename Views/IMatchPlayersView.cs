using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface IMatchPlayersView// : ITablePlayerTeamView
    {
        int IdPerson { get; set; }
        int Number { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string Role { get; set; }
        string Amplua { get; set; }
        bool IsSpare { get; set; }
    }

    public class ClassMatchPlayersView : IMatchPlayersView
    {
        int IMatchPlayersView.IdPerson {get;set;}
        int IMatchPlayersView.Number { get; set; }
        string IMatchPlayersView.FirstName {get;set;}
        string IMatchPlayersView.LastName {get;set;}
        string IMatchPlayersView.MiddleName {get;set;}
        string IMatchPlayersView.Role {get;set;}
        string IMatchPlayersView.Amplua {get;set;}
        bool IMatchPlayersView.IsSpare {get;set;}
    }
}
