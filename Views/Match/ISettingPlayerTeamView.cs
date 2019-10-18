using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface ISettingPlayerTeamView
    {
        int Number { get; set; }
        string AmpluaName { get; set; }
        string TeamName { get; set; }

        int IdTeam { get; set; }
        int IdPerson { get; set; }
        int ? IdAmplua { get; set; }
    }
}
