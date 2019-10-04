using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface ISettingMatchView
    {
        string NameMatch { get; set; }
        string NameStadium { get; set; }
        string NameGuestTeam { get; set; }
        string NameOwnerTeam { get; set; }
        string NameSeason { get; set; }
        DateTime DateTime { get; set; }
        string NameCommentator1 { get; set; }
        string NameCommentator2 { get; set; }

    }
}
