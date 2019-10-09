using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface ITablePlayerTeamView
    {
        int IdPerson { get; set; }
        int Number { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string Role { get; set; }
        string Amplua { get; set; }
    }

    public class ClassSettingPlayerTeamView : ITablePlayerTeamView
    {
        int ITablePlayerTeamView.IdPerson {get;set;}
        int ITablePlayerTeamView.Number {get;set;}
        string ITablePlayerTeamView.FirstName {get;set;}
        string ITablePlayerTeamView.LastName {get;set;}
        string ITablePlayerTeamView.MiddleName {get;set;}
        string ITablePlayerTeamView.Role { get; set; }
        string ITablePlayerTeamView.Amplua {get;set;}
    }
}
