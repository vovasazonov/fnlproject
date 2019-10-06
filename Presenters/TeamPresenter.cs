using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Svt.Caspar;
using FNL.Views;
using ModelLayer;
using ModelLayer.Models;
using System.Drawing;

namespace FNL.Presenters
{
	public class TeamPresenter
	{
		ITeamView teamView;

		public TeamPresenter(ITeamView teamView)
		{
			this.teamView = teamView;

            
		}

        /// <summary>
        /// Update color in database and in server caspar. ??????????? Need to update data in database
        /// </summary>
        /// <param name="_cgData">Data caspar</param>
        /// <param name="_caspar_">Device</param>
        public void UpdateColor(CasparCGDataCollection _cgData, CasparDevice _caspar_)
		{
			try
			{
				// Clear old data
				_cgData.Clear();

				// build data
				_cgData.SetData("team1Color", teamView.ColorTeam.ToArgb().ToString());
				_cgData.SetData("team2Color", teamView.ColorTeam.ToArgb().ToString());
			}
			catch
			{

			}
			finally
			{
				if (_caspar_.IsConnected && _caspar_.Channels.Count > 0)
				{
					_caspar_.Channels[Properties.Settings.Default.CasparChannel].CG.Update(Properties.Settings.Default.GraphicsLayerClock, _cgData);
				}
			}
		}

		/// <summary>
		/// Show color dialog to choose color of team.
		/// </summary>
		/// <returns>DialogResult.OK is true</returns>
		public bool ChoseNewColor()
		{
			ColorDialog MyDialog = new ColorDialog
			{
				// Keeps the user from selecting a custom color.
				AllowFullOpen = true,
				// Allows the user to get help. (The default is false.)
				ShowHelp = true,
				// Sets the initial color select to the current text color.
				Color = teamView.ColorTeam
			};

			// Update the text box color if the user clicks OK 
			if (MyDialog.ShowDialog() == DialogResult.OK)
			{
				teamView.ColorTeam = MyDialog.Color;
				return true;
			}

			return false;
		}

        /// <summary>
        /// Return data from database.
        /// </summary>
        /// <returns>matches.</returns>
        public List<ITeamView> GetTeams()
        {
            List<ITeamView> matchesView = new List<ITeamView>();

            using (DbFnlContext db = new DbFnlContext())
            {
                var teams = db.Teams;

                // Get data drom database.
                foreach (var team in teams)
                {
                    HelperTeamView teamView = new HelperTeamView();

                    teamView.IdTeam = team.TeamId;
                    teamView.ColorTeam = Color.FromArgb(team.Color);
                    teamView.NameTeamFull = team.NameFull != null ? team.NameFull : "";
                    teamView.NameTeamShort = team.NameShort != null ? team.NameShort : "";
                    teamView.PathTeamLogo = team.LogotypePath != null ? team.LogotypePath : "";

                    matchesView.Add(teamView);
                }
            }

            return matchesView;
        }

        public void DeleteTeamFromDatabase(int idTeam)
        {
            using (DbFnlContext db = new DbFnlContext())
            {
                var query = from t in db.Teams
                            where t.TeamId == idTeam
                            select t;

                db.Teams.Remove(query.FirstOrDefault());

                db.SaveChanges();
            }
        }

        class HelperTeamView : ITeamView
        {
            public Color ColorTeam { get; set; }
            public string NameTeamFull {get;set;}
            public string NameTeamShort {get;set;}
            public string PathTeamLogo {get;set;}
            public int IdTeam {get;set;}
        }


    }
}
