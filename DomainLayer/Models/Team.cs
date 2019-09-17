using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
	public class Team
	{
		public int TeamId { get; set; }
		public string NameFull { get; set; }
		public string NameShort { get; set; }
		public string LogotypePath { get; set; }
		public int Color { get; set; }

		// Relation 0..*
		public List<TeamPlayer> TeamPlayers { get; set; }
		// Relation 0..*
		public List<Match> Matches { get; set; }
	}
}
