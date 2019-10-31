using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface ISettingPlayerTeamView: IPlayerTeamView
    {
        string Team { get; set; }
    }
}
