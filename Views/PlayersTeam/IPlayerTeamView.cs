using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface IPlayerTeamView : IPlayerView
    {
        new int Number { get; set; }
        new string FirstName { get; set; }
        new string LastName { get; set; }
        new string MiddleName { get; set; }
        new string Amplua { get; set; }
    }

    public class CSettingPlayerTeamView : IPlayerTeamView
    {
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Role { get; set; }
        public string Amplua { get; set; }
        public int PersonId { get; set; }
        public int TeamId { get; set; }
        public int AmpluaId { get; set; }
        public int RoleId { get; set; }
        public string PhotoPath {get;set;}
        public string Country {get;set;}
        public string City {get;set;}
    }
}
