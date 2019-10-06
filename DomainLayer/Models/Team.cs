using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required]
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public string LogotypePath { get; set; }
        public int Color { get; set; }

        public List<TeamPlayer> TeamPlayers { get; set; }
        public List<Match> Matches { get; set; }
        public List<PlayerMatch> PlayersMatches {get;set;}
	}
}
