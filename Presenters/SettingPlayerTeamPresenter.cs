using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using ModelLayer.Models;
using FNL.Views;

namespace FNL.Presenters
{
    public class SettingPlayerTeamPresenter
    {
        private ITablePlayerTeamView settingPlayerTeamView;

        public SettingPlayerTeamPresenter(ITablePlayerTeamView settingPlayerTeamView)
        {
            this.settingPlayerTeamView = settingPlayerTeamView;
        }

    }
}
