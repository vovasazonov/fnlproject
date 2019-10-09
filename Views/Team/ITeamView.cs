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

    public class ClassTeamView : ITeamView
    {
        public int IdTeam { get; set; }
        public Color ColorTeam { get; set; }
        public string NameTeamFull { get; set; }
        public string NameTeamShort { get; set; }
        public string PathTeamLogo { get; set; }
    }
}
