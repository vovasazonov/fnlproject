using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FNL.Views
{
	public interface ITeamView
	{
        int IdTeam { get; set; }
		Color ColorTeam { get; set; }
        string NameTeamFull { get; set; }
        string NameTeamShort { get; set; }
        string PathTeamLogo { get; set; }
	}
}
